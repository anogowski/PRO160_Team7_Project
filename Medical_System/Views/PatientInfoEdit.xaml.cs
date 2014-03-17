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
        int PatientID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int CurrentHeight { get; set; }
        double CurrentWeight { get; set; }

        Patient tempPatient = new Patient();
        public PatientInfoEdit(int PID)
        {
            InitializeComponent();

            tempPatient.PID = PID;
            PatientID = PID - 1;

            DataContext = helper.GetPatients()[PatientID];
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            tempPatient.FirstName = FirstName;
            tempPatient.LastName = LastName;
            tempPatient.CurrentHeight = CurrentHeight;
            tempPatient.CurrentWeight = CurrentWeight;

            helper.updatePatient(tempPatient);
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FirstNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            FirstName = textBox.Text;
        }

        private void LastNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            LastName = textBox.Text;
        }

        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            int height = 0;
            int.TryParse(textBox.Text, out height);
            CurrentHeight = height;
        }

        private void WeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            double weight = 0;
            double.TryParse(textBox.Text, out weight);
            CurrentWeight = weight;
            // CurrentWeight = Convert.ToDouble(textBox.Text);
        }

       



    }
}