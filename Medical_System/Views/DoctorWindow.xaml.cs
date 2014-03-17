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

            MedicationsBox.ItemsSource = helper.getMedicine();
            MedicationsBox.DisplayMemberPath = "Name";

        }

        private void getListOfPatients()
        {
            ListOfPatients = new ObservableCollection<Patient>(helper.GetPatients());
        }

        private void UpdateLists(object sender, SelectionChangedEventArgs e)
        {
            Patient SelectedPatient = (Patient)helper.GetPatients()[ListOfPatientsBox.SelectedIndex];
            PrescriptionsBox.ItemsSource = helper.GetPrescriptionsByPatient(ListOfPatients[ListOfPatientsBox.SelectedIndex].PID);
            PrescriptionsBox.Items.Refresh();
            NotesBox.Content = SelectedPatient.Note;
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
            Patient selectedPatient = (Patient)ListOfPatientsBox.SelectedValue;
            PatientInfoEdit window = new PatientInfoEdit(selectedPatient.PID);
            window.Show();
        }

        private void AppointmentsAddButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow window = new AppointmentWindow();
            window.Show();
        }

        private void PrescriptionsAddButton_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)ListOfPatientsBox.SelectedValue;
            PrescriptionsWindow window = new PrescriptionsWindow(selectedPatient.PID);
            window.Show();
        }

        private void MedicationsAddButton_Click(object sender, RoutedEventArgs e)
        {
            EditMedicine window = new EditMedicine(MedicationsBox.SelectedIndex);
            window.Show();
            MedicationsBox.Items.Refresh();
        }

        private void NotesAddButton_Click(object sender, RoutedEventArgs e)
        {

            Patient SelectedPatient = (Patient)helper.GetPatients()[ListOfPatientsBox.SelectedIndex];
            EditNotes window = new EditNotes();
            window.Show();
            NotesBox.Content = SelectedPatient.Note;
            
        }

        private void CurrentSymptomsEditButton_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)ListOfPatientsBox.SelectedValue;
            EditSymptoms window = new EditSymptoms(selectedPatient.PID);
            window.Show();

            
        }

        private void ViewPatientGraphButton_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = (Patient)ListOfPatientsBox.SelectedValue;
            double[] numberList = {
                                   selectedPatient.CurrentHeight,
                                   selectedPatient.CurrentHeight * .2,
                                   selectedPatient.CurrentHeight * .4,
                                   selectedPatient.CurrentHeight * .6,
                                   selectedPatient.CurrentHeight * .8,
                                   selectedPatient.CurrentHeight * 1
                               };

            GraphWindow window = new GraphWindow();
            window.GraphData(numberList);
            window.Show();
        }
    }
}