using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace FinalExamExtraCredit_HillaryNeaves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            COVIDInfo covidAPI;
            string url = "https://api.apify.com/v2/key-value-stores/moxA3Q0aZh5LosewB/records/LATEST?disableRedirect=true";
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                covidAPI = JsonConvert.DeserializeObject<COVIDInfo>(json);
            }

            //cmbState.Items.Add("ALL");
            foreach (var item in covidAPI.casesByState)
            {
                cmbState.Items.Add(item);
            }
        }
        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedState = (States)cmbState.SelectedItem;

            lstList.Items.Add(selectedState.casesReported);
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Thank you for showing in interest in seeing what I have learned this semester! Please click the 'Practice Problem' tab that will showcase my knowledge through a problem that I created.");
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ouch! I know you want to see eveything that I have learned this semester. I am going to let you try again...hit the 'Yes' box this time!");
        }

        private void btnYes_MouseEnter(object sender, MouseEventArgs e)
        {
            tabIntro.Background = Brushes.LightGreen;
        }

        private void btnYes_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter convert = new BrushConverter();
            tabIntro.Background = (Brush)convert.ConvertFrom("#FFD3EEF3");
        }

        private void btnNo_MouseEnter(object sender, MouseEventArgs e)
        {
            tabIntro.Background = Brushes.PaleVioletRed;
        }

        private void btnNo_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter convert = new BrushConverter();
            tabIntro.Background = (Brush)convert.ConvertFrom("#FFD3EEF3");
        }
    }
}
