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
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    /// 

    public partial class EditNotes : Window
    {
        int PatientID { get; set; }
        string Note { get; set; }
        DbHelper helper = new DbHelper();
        Patient pat = new Patient();

        public EditNotes(int PID = 1)
        {
            InitializeComponent();
            pat.PID = PID;
            PatientID = PID - 1;
            DataContext = helper.GetPatients()[PatientID];
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
           Note = textBox.Text;

        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            pat.Note = Note;
            helper.updatePatientSymptoms(pat);
            Close();
        }

    }
}
