using Medical_System.WebMiner;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medical_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // if '0', it is an administrator
        // if'1', it is a doctor
        int userType;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void adminBtn_Click_1(object sender, RoutedEventArgs e)
        {
            userType = 0;
            ShowLoginWindow();
            this.Hide();
        }

        private void doctorBtn_Click_1(object sender, RoutedEventArgs e)
        {
            userType = 1;
            ShowLoginWindow();
            this.Hide();
        }

        private void ShowLoginWindow()
        {
            LoginWindow login = new LoginWindow(this, userType);
            login.Show();
        }
    }
}
