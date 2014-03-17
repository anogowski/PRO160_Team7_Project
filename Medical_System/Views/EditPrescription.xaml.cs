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

namespace Medical_System
{
    /// <summary>
    /// Interaction logic for EditPrescription.xaml
    /// </summary>
    public partial class EditPrescription : Window
    {
        int PrescriptionID { get; set; }
        string Note { get; set; }
        DbHelper helper = new DbHelper();
        Prescription pre = new Prescription();
        public EditPrescription(int PreID = 1)
        {
            InitializeComponent();
            pre.PRE_ID = PreID;
            PrescriptionID = PreID - 1;
            DataContext = helper.GetPrescriptions()[PrescriptionID];
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
                pre.Note = Note;
                helper.updatePrescriptionNote(pre);
            Close();
        }
    }
}
