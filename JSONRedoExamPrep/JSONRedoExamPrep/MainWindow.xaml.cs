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

namespace JSONRedoExamPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> categories = new List<string>();
        string[] api;

        public MainWindow()
        {
            InitializeComponent();
            string url = "https://api.chucknorris.io/jokes/categories";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<string[]>(json);
            }

            cmbCategories.Items.Add("ALL");

            foreach (var item in api)
            {
                cmbCategories.Items.Add(item);
                cmbCategories.SelectedIndex = 0;
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            Jokes apiJoke;

            string selectedItem = (string)cmbCategories.SelectedItem;

            if (selectedItem == "ALL")
            {
                string allURL = "https://api.chucknorris.io/jokes/random";

                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(allURL).Result;
                    apiJoke = JsonConvert.DeserializeObject<Jokes>(json);
                }
            }
            else
            {
                string jokeURL = "https://api.chucknorris.io/jokes/random?category=" + selectedItem;
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(jokeURL).Result;
                    apiJoke = JsonConvert.DeserializeObject<Jokes>(json);
                }
            }

            lstJokes.Items.Add(apiJoke);
        }
    }
}
