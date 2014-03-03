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
using System.IO;
using System.Xml.Serialization;

namespace Medical_System
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<Admin> adminList = new List<Admin>();
        List<Admin> tempAdminList;
        Admin selectedAdmin;

        List<Doctor> docList = new List<Doctor>();
        List<Doctor> tempDocList;

        MainWindow mMain;
        string mAdminUsername;
        string adminListFile;
        string adminUsername;
        string docUsername;

        //'0', if it's an administrator
        //'1' if it's a doctor
        int userType;

        public LoginWindow(MainWindow main, int userInt)
        {
            InitializeComponent();
            mMain = main;
            userType = userInt;

            adminListFile = "newUserInfo.txt.";

            LoadAdminInfoFromXml(adminListFile);

            foreach (Admin a in adminList)
            {
                userComboBox.Items.Add(a.Username);
            }
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
                    Admin newAdmin = new Admin()
                    {
                        Username = usernameTextBox.Text
                    };

                    tempAdminList = new List<Admin>();
                    bool isChecking = false;
                    if (adminList.Count == 0)
                    {
                        adminList.Add(newAdmin);
                    }
                    else
                    {
                        isChecking = CheckAdminsInfo(newAdmin, isChecking);
                    }

                    for (int i = 0; i < tempAdminList.Count; i++)
                    {
                        if (!adminList.Contains(tempAdminList[i]))
                        {
                            adminList.Add(tempAdminList[i]);
                        }
                    }
                    SaveAdminInfoToXml(adminList);
                }
                else
                {
                    // show doctor GUI

                }

                mMain.Close();
                this.Close();
            }
        }

        private bool CheckAdminsInfo(Admin newAdmin, bool isChecking)
        {
            foreach (Admin a in adminList)
            {
                if (!newAdmin.Username.Equals(a.Username))
                {
                    tempAdminList.Add(newAdmin);
                    isChecking = true;
                }
                else if (newAdmin.Username.Equals(a.Username))
                {
                    isChecking = false;
                }
            }
            return isChecking;
        }

        private void BackToMainWindow()
        {
            mMain.Show();
            this.Close();
        }

        private void userComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string currentSelection = Convert.ToString(userComboBox.SelectedItem);

            selectedAdmin = new Admin()
            {
                Username = currentSelection
            };

            adminUsername = selectedAdmin.Username;

            usernameTextBox.Text = adminUsername;

        }

        public void LoadAdminInfoFromXml(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (Stream openedFile = File.OpenRead(fileName))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Admin>));
                        List<Admin> deserialize = serializer.Deserialize(openedFile) as List<Admin>;
                        adminList = deserialize;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while deserializing");
            }
        }

        public void SaveAdminInfoToXml(List<Admin> list)
        {
            Stream adminStream;
            try
            {
                if (File.Exists(adminListFile))
                {
                    adminStream = File.OpenWrite(adminListFile);
                }
                else
                {
                    adminStream = File.Create(adminListFile);
                }
                using (adminStream)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Admin>));
                    serializer.Serialize(adminStream, list);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while serializing");
            }
        }
    }
}
