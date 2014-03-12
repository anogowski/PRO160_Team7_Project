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
using System.IO;
using System.Xml.Serialization;
using Medical_System.Views;
//using Medical_System.WebMiner;

namespace Medical_System
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //select username, psw from Administrator
        //select UserName, psw from Doctor

        #region(Variables)
        List<Administrator> adminList = new List<Administrator>();
        List<Administrator> tempAdminList;
        Administrator selectedAdmin;

        List<string> docList = new List<string>();
        List<string> tempDocList;
        Doctor selectedDoc;

        DbHelper db = new DbHelper();

        MainWindow mMain;
        string adminListFile;
        string adminUsername;
        string docListFile;
        string docUsername;
        string userName;
        string password;

        //'0', if it's an administrator
        //'1' if it's a doctor
        int userType;
        #endregion

        public LoginWindow(MainWindow main, int userInt)
        {
            InitializeComponent();
            mMain = main;
            userType = userInt;

            adminListFile = "newAdminInfo.txt";
            docListFile = "newDocInfo.txt";

            if (userType == 0)
            {
                loginLabel.Content = "Administrator";
                LoadAdminInfoFromXml(adminListFile);

                foreach (Administrator a in adminList)
                {
                    userComboBox.Items.Add(a.username);
                }
            }
            else
            {
                loginLabel.Content = "Doctor";
                LoadDocInfoFromXml(docListFile);
                foreach (string doc in docList)
                {
                    userComboBox.Items.Add(doc);
                }
            }
        }

        #region(GUI Logic)
        private void backBtn_Click_1(object sender, RoutedEventArgs e)
        {
            BackToMainWindow();
        }

        private void BackToMainWindow()
        {
            mMain.Show();
            this.Close();
        }

        private void loginBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) && string.IsNullOrEmpty(passwordTextBox.Password))
            {
                MessageBox.Show("You didn't enter anything!");
            }
            else if (string.IsNullOrEmpty(usernameTextBox.Text))
            {
                MessageBox.Show("You didn't enter a username.");
            }
            else if (string.IsNullOrEmpty(passwordTextBox.Password))
            {
                MessageBox.Show("You didn't enter a password.");
            }
            else
            {
                userName = usernameTextBox.Text;
                password = passwordTextBox.Password;

                if (userType == 0)
                {
                    // show admin GUI
                    ShowAdminGui(userName, password);
                }
                else
                {
                    // show doctor GUI
                    ShowDoctorGui(userName, password);
                }
            }
        }

        private void ShowAdminGui(string user, string pswd)
        {
            #region(Saving Admin Info)
            Administrator newAdmin = new Administrator()
            {
                username = usernameTextBox.Text
            };

            tempAdminList = new List<Administrator>();
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
            #endregion

            Administrator returnAdmin = new Administrator();
            if (db.CanAdminLogin(user, pswd, out returnAdmin))
            {
                SaveAdminInfoToXml(adminList);
                mMain.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect!");
            }
        }

        private void ShowDoctorGui(string user, string pswd)
        {
            #region(Saving Doctor Info)
            string newDoc = usernameTextBox.Text;

            tempDocList = new List<string>();
            bool isChecking = false;
            if (docList.Count == 0)
            {
                docList.Add(newDoc);
            }
            else
            {
                isChecking = CheckDocsInfo(newDoc, isChecking);
            }

            for (int i = 0; i < tempDocList.Count; i++)
            {
                if (!docList.Contains(tempDocList[i]))
                {
                    docList.Add(tempDocList[i]);
                }
            }
            SaveDocInfoToXml(docList);
            #endregion

            Doctor returnDoc = new Doctor();
            if (db.CanDoctorLogin(user, pswd, out returnDoc))
            {
                DoctorWindow window = new DoctorWindow();
                window.Show();
                mMain.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect!");
            }
        }

        private bool CheckAdminsInfo(Administrator newAdmin, bool isChecking)
        {
            foreach (Administrator a in adminList)
            {
                if (!newAdmin.username.Equals(a.username))
                {
                    tempAdminList.Add(newAdmin);
                    isChecking = true;
                }
                else if (newAdmin.username.Equals(a.username))
                {
                    isChecking = false;
                }
            }
            return isChecking;
        }

        private bool CheckDocsInfo(string newDoc, bool isChecking)
        {
            foreach (string doc in docList)
            {
                if (!newDoc.Equals(doc))
                {
                    tempDocList.Add(newDoc);
                    isChecking = true;
                }
                else if (newDoc.Equals(doc))
                {
                    isChecking = false;
                }
            }
            return isChecking;
        }

        private void userComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string currentSelection = Convert.ToString(userComboBox.SelectedItem);

            if (userType == 0)
            {
                selectedAdmin = new Administrator() { username = currentSelection };
                adminUsername = selectedAdmin.username;
                usernameTextBox.Text = adminUsername;
            }
            else
            {
                selectedDoc = new Doctor() { UserName = currentSelection };
                docUsername = selectedDoc.UserName;
                usernameTextBox.Text = docUsername;
            }

        }
        #endregion

        #region(User list serialization)
        public void LoadAdminInfoFromXml(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (Stream openedFile = File.OpenRead(fileName))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Administrator>));
                        List<Administrator> deserialize = serializer.Deserialize(openedFile) as List<Administrator>;
                        adminList = deserialize;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while deserializing");
            }
        }

        public void SaveAdminInfoToXml(List<Administrator> list)
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Administrator>));
                    serializer.Serialize(adminStream, list);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while serializing");
            }
        }

        public void LoadDocInfoFromXml(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (Stream openedFile = File.OpenRead(fileName))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                        List<string> deserialize = serializer.Deserialize(openedFile) as List<string>;
                        docList = deserialize;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while deserializing");
            }
        }

        public void SaveDocInfoToXml(List<string> list)
        {
            Stream docStream;
            try
            {
                if (File.Exists(docListFile))
                {
                    docStream = File.OpenWrite(docListFile);
                }
                else
                {
                    docStream = File.Create(docListFile);
                }
                using (docStream)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    serializer.Serialize(docStream, list);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while serializing");
            }
        }
        #endregion
    }
}
