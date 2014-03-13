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

            PerscriptionsBox.ItemsSource = helper.GetPrescriptionsByPatient(ListOfPatients[ListOfPatientsBox.SelectedIndex].PID);
            PerscriptionsBox.Items.Refresh();
        }

        private void ShowPrescriptionsEditMenu(object sender, RoutedEventArgs e)
        {
            EditPrescription window = new EditPrescription();
            window.Show();
        }
    }
}