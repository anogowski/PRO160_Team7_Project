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
        ObservableCollection<string> Note { get; set; }
        DbHelper helper = new DbHelper();
        //Perscription pre = new Perscription();
        public EditPrescription(int PreID = 1)

        {
            PrescriptionID = PreID;
           
            InitializeComponent();
        }

        private void getNote()
        {
            string notes = helper.GetPrescriptionNoteByPrescriptionId(PrescriptionID);
            Note.Add(notes);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
           
           

            Close();
        }
    }
}
