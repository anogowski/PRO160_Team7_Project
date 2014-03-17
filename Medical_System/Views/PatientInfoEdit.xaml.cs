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
    /// Interaction logic for PatientInfoEdit.xaml
    /// </summary>
    public partial class PatientInfoEdit : Window
    {
        DbHelper helper = new DbHelper();
        int PID = 0;

        public PatientInfoEdit(int _PID)
        {
            InitializeComponent();

            PID = _PID;
            DataContext = helper.GetPatients()[PID];
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            Patient tempPatient = helper.GetPatients()[PID];
            tempPatient.FirstName = FirstNameBox.Text;
            tempPatient.LastName = LastNameBox.Text;
            tempPatient.CurrentHeight = Int32.Parse(HeightBox.Text);
            tempPatient.CurrentWeight = Int32.Parse(WeightBox.Text);

            helper.updatePatient(tempPatient);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}