using System;
using System.Collections.Generic;
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
    /// Interaction logic for Prescriptions.xaml
    /// </summary>
    public partial class PrescriptionsWindow : Window
    {
        DbHelper helper = new DbHelper();
        int PID = 0;
        Patient FoundPatient;

        public PrescriptionsWindow(int _PID)
        {
            InitializeComponent();

            PID = _PID;
            FoundPatient = helper.GetPatients()[PID];
            PrescriptionBox.ItemsSource = helper.GetPrescriptions(); ;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            FoundPatient.Prescriptions.Add((Prescription)PrescriptionBox.SelectedValue);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
