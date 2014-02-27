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

namespace Medical_System
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MainWindow mMain;

        // if '0', it is an administrator
        // if'1', it is a doctor
        int userType;

        public LoginWindow(MainWindow main, int user)
        {
            InitializeComponent();
            mMain = main;
            userType = user;
        }

        private void backBtn_Click_1(object sender, RoutedEventArgs e)
        {
            BackToMainWindow();
        }

        private void loginBtn_Click_1(object sender, RoutedEventArgs e)
        {
            //code to show GUI after logging in
            if (userType == 0)
            {
                // show admin GUI
            }
            else
            {
                // show doctor GUI
            }

            mMain.Close();
            this.Close();
        }

        private void BackToMainWindow()
        {
            mMain.Show();
            this.Close();
        }
    }
}
