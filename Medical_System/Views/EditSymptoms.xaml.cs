﻿using System;
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

namespace Medical_System.Views
{
    /// <summary>
    /// Interaction logic for EditSymptoms.xaml
    /// </summary>
    public partial class EditSymptoms : Window
    {
        int PatientID { get; set; }
        string Symptoms { get; set; }
        DbHelper helper = new DbHelper();
        Patient pat = new Patient();
        public EditSymptoms(int PID = 1)
        {
            InitializeComponent();
            pat.PID = PID;
            PatientID = PID - 1; 
           DataContext = helper.GetPatients()[PatientID];
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            Symptoms = textBox.Text;
           
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            pat.Symptoms = Symptoms;
                helper.updatePatientSymptoms(pat);
            Close();
        }
    }
}
