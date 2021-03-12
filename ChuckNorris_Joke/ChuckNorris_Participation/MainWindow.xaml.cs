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

namespace ChuckNorris_Participation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> options = new List<string>();
        //string chuckAPI;
        string[] chuckAPI;
        public MainWindow()
        {
            InitializeComponent();

            string chuckURLCAT = "https://api.chucknorris.io/jokes/categories";

            //string[] chuckURLJOKE = "https://api.chucknorris.io/jokes/random";
            //ClassJokes chuckURLJOKE;
            //if(SelectedItem = "ALL")

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(chuckURLCAT).Result;
                chuckAPI = JsonConvert.DeserializeObject<string[]>(json);
            }

            CMBCategories.Items.Add("ALL");
            foreach (var item in chuckAPI)
            {
                CMBCategories.Items.Add(item);
                CMBCategories.SelectedIndex = 0;
            }

            //ClassJokes chuckURLJOKE;
            //string selectedCAT = (string)CMBCategories.SelectedItem;
            //string everythingURL = "https://api.chucknorris.io/jokes/random";
            //if (selectedCAT == "ALL")
            //{
            //    using (var client = new HttpClient())
            //    {
            //        string json = client.GetStringAsync(everythingURL).Result;
            //        chuckURLJOKE = JsonConvert.DeserializeObject<ClassJokes>(json);
            //    }

        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            ClassJokes chuckURLJOKE;
            string selectedCAT = (string)CMBCategories.SelectedItem;
            string everythingURL = "https://api.chucknorris.io/jokes/random";
            if (selectedCAT == "ALL")
            {
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(everythingURL).Result;
                    chuckURLJOKE = JsonConvert.DeserializeObject<ClassJokes>(json);
                }
                //CMBCategories.Items.Add("ALL");
                //foreach (var item in chuckAPI)
                //{
                //    CMBCategories.Items.Add(item);
                //    CMBCategories.SelectedIndex = 0;
                //}
            }
            else
            {
                //(selectedCAT == "ALL" is null)
                string selectedCATURL = "https://api.chucknorris.io/jokes/random?category=" + selectedCAT;
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(selectedCATURL).Result;
                    chuckURLJOKE = JsonConvert.DeserializeObject<ClassJokes>(json);
                }
                //CMBCategories.Items.Add("ALL");
                //foreach (var item in chuckAPI)
                //{
                //    CMBCategories.Items.Add(item);
                //    CMBCategories.SelectedIndex = 0;
                //}
            }

            lstQuote.Items.Add(chuckURLJOKE);
        }
    }
}
