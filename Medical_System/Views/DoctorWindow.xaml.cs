using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Medical_System.Views
{
    /// <summary>
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        private ObservableCollection<Patient> ListOfPatients = new ObservableCollection<Patient>();
        private DbHelper helper = new DbHelper();

        public DoctorWindow()
        {
            InitializeComponent();

            getListOfPatients();
            ListOfPatientsBox.ItemsSource = ListOfPatients;
            ListOfPatientsBox.Items.Refresh();
        }

        private void getListOfPatients()
        {
            ListOfPatients = new ObservableCollection<Patient>(helper.GetPatients());
        }

        private void UpdateLists(object sender, SelectionChangedEventArgs e)
        {
            PrescriptionsBox.ItemsSource = helper.GetPrescriptionsByPatient(ListOfPatients[ListOfPatientsBox.SelectedIndex].PID);
            PrescriptionsBox.Items.Refresh();
        }

        private void ShowPrescriptionsEditMenu(object sender, RoutedEventArgs e)
        {
            if (PrescriptionsBox.SelectedIndex > -1)
            {
                Prescription selectedPrescription = (Prescription)PrescriptionsBox.SelectedValue;
                EditPrescription window = new EditPrescription(selectedPrescription.PRE_ID);
                window.Show();
                PrescriptionsBox.Items.Refresh();
            }
        }

        private void PatientInfoEditButton_Click(object sender, RoutedEventArgs e)
        {
            PatientInfoEdit window = new PatientInfoEdit();
            window.Show();
        }

        private void AppointmentsAddButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow window = new AppointmentWindow();
            window.Show();
        }

        private void PrescriptionsAddButton_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionsWindow window = new PrescriptionsWindow();
            window.Show();
        }

        private void MedicationsAddButton_Click(object sender, RoutedEventArgs e)
        {
            MedicationWindow window = new MedicationWindow();
            window.Show();
        }

        private void NotesAddButton_Click(object sender, RoutedEventArgs e)
        {
            NotesWindow window = new NotesWindow();
            window.Show();
        }

        private void CurrentSymptomsEditButton_Click(object sender, RoutedEventArgs e)
        {
            Patient foundPatient = (Patient)ListOfPatientsBox.SelectedValue;
            EditSymptoms window = new EditSymptoms(foundPatient.PID);
            window.Show();
        }
    }
}