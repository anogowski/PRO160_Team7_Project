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
        ObservableCollection<Perscription> Note { get; set; }
        DbHelper helper = new DbHelper();
        //Perscription pre = new Perscription();
        public EditPrescription(int PreID)

        {
            PrescriptionID = PreID;
           // help.GetPerscriptions
           // Note.Add();
            InitializeComponent();
        }

        private void getNote()
        {
            //List<Perscription> tempList = helper.GetPerscriptionsByPatient();

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
