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
    /// Interaction logic for EditMedicine.xaml
    /// </summary>
    public partial class EditMedicine : Window
    {
        int MedicineID { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        DbHelper helper = new DbHelper();
        Medicine med = new Medicine();

        public EditMedicine(int MID)
        {
            InitializeComponent();
             med.MID = MID;
            MedicineID = MID - 1;
            DataContext = helper.getMedicine()[MedicineID];
        }
         

     
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MedicineName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Name = textBox.Text;

        }

        private void MedicineNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Note = textBox.Text;

        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            med.Name = Name;
            med.Note = Note;
            helper.updateMedicine(med);
            Close();
        }
    }
}
