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
using Medical_System.Users;

namespace Medical_System
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<Admin> adminList = new List<Admin>();
        List<Admin> tempAdminList;

        List<Doctor> docList = new List<Doctor>();
        List<Doctor> tempDocList;

        MainWindow mMain;

        //'0', if it's an administrator
        //'1' if it's a doctor
        int userType;

        public LoginWindow(MainWindow main, int userInt)
        {
            InitializeComponent();
            mMain = main;
            userType = userInt;
        }

        private void backBtn_Click_1(object sender, RoutedEventArgs e)
        {
            BackToMainWindow();
        }

        private void loginBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) && string.IsNullOrEmpty(passwordTextBox.Password))
            {
                MessageBox.Show("You didn't enter anything!");
            }
            else if(string.IsNullOrEmpty(usernameTextBox.Text))
            {
                MessageBox.Show("You didn't enter a username.");
            }
            else if (string.IsNullOrEmpty(passwordTextBox.Password))
            {
                MessageBox.Show("You didn't enter a password.");
            }
            else
            {
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
        }

        private void BackToMainWindow()
        {
            mMain.Show();
            this.Close();
        }

        private void userComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
