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

namespace Classes3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool isEverythingGood = true;

            if (string.IsNullOrWhiteSpace(txtCity.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid city!");
            }

            if (string.IsNullOrWhiteSpace(txtFirst.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid first name!");
            }

            double gpa;

            if (double.TryParse(txtGPA.Text, out gpa) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid GPA!");
            }

            if (string.IsNullOrWhiteSpace(txtLast.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid last name!");
            }

            if (string.IsNullOrWhiteSpace(txtMajor.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid major!");
            }

            if (string.IsNullOrWhiteSpace(txtState.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid state!");
            }

            if (string.IsNullOrWhiteSpace(txtStreetName.Text) == true)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid street name!");
            }

            int streetNumber, zipCode;

            if (int.TryParse(txtStreetNum.Text, out streetNumber) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid street number!");
            }

            if (int.TryParse(txtZip.Text, out zipCode) == false)
            {
                isEverythingGood = false;
                MessageBox.Show("You must enter a valid GPA!");
            }

            if (isEverythingGood == false)
            {
                return;
            }

            Student student = new Student()
            {
                FirstName = txtFirst.Text,
                GPA = gpa,
                LastName = txtLast.Text,
                Major = txtMajor.Text
            };
            student.SetAddress(streetNumber, txtStreetName.Text, txtState.Text, txtCity.Text, zipCode);

            lstGrads.Items.Add(student);

            txtCity.Clear();
            txtFirst.Clear();
            txtGPA.Clear();
            txtLast.Clear();
            txtMajor.Clear();
            txtState.Clear();
            txtStreetName.Clear();
            txtStreetNum.Clear();
            txtZip.Clear();
        }

        private void lstGrads_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondWindow outputWindow = new SecondWindow();

            var selectedStudent = (Student)lstGrads.SelectedItem;

            string output = $"Name: {selectedStudent.FirstName} {selectedStudent.LastName}" +
                $"\rAddress: {selectedStudent.Address.StreetNumber} {selectedStudent.Address.StreetName}, {selectedStudent.Address.City}, {selectedStudent.Address.State} {selectedStudent.Address.ZipCode}";

            outputWindow.lstSecond.Items.Add(output);
            outputWindow.ShowDialog();
        }
    }
}
