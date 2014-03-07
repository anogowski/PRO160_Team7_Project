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
using Medical_System.Models;
using System.IO;
using System.Xml.Serialization;
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

        List<Doctor> docList = new List<Doctor>();
        List<Doctor> tempDocList;
        Doctor selectedDoc;

        List<Doctor> dbDocList;

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

            adminListFile = "newAdminInfo.txt.";
            docListFile = "newDocInfo.txt.";

            if (userType == 0)
            {
                LoadAdminInfoFromXml(adminListFile);

                foreach (Administrator a in adminList)
                {
                    userComboBox.Items.Add(a.username);
                }
            }
            else
            {
                LoadDocInfoFromXml(docListFile);
                foreach(Doctor d in docList)
                {
                    userComboBox.Items.Add(d.UserName);
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
            SaveAdminInfoToXml(adminList);
            #endregion

            Administrator returnAdmin = new Administrator();
            if (db.CanAdminLogin(user, pswd, out returnAdmin))
            {
                mMain.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password does not exist!");
            }
        }

        private void ShowDoctorGui(string user, string pswd)
        {
            #region(Saving Doctor Info)
            Doctor newDoc = new Doctor()
            {
                UserName = usernameTextBox.Text
            };

            tempDocList = new List<Doctor>();
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
                mMain.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password does not exist!");
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

        private bool CheckDocsInfo(Doctor newDoc, bool isChecking)
        {
            foreach (Doctor d in docList)
            {
                if (!newDoc.UserName.Equals(d.UserName))
                {
                    tempDocList.Add(newDoc);
                    isChecking = true;
                }
                else if (newDoc.UserName.Equals(d.UserName))
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
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));
                        List<Doctor> deserialize = serializer.Deserialize(openedFile) as List<Doctor>;
                        docList = deserialize;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while deserializing");
            }
        }

        public void SaveDocInfoToXml(List<Doctor> list)
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));
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
