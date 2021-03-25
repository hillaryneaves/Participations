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

namespace ChuckNorrisRedoExamPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] jokeAPI;
        public MainWindow()
        {
            InitializeComponent();

            
            string url = "https://api.chucknorris.io/jokes/categories";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                jokeAPI = JsonConvert.DeserializeObject<string[]>(json);
            }

            cmbCategory.Items.Add("ALL");
            foreach (var item in jokeAPI)
            {
                cmbCategory.Items.Add(item);
                cmbCategory.SelectedIndex = 0;
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Jokes chuckJokes;
            string selectedCAT = (string)cmbCategory.SelectedItem;
            string allURL = "https://api.chucknorris.io/jokes/random";
            if (selectedCAT == "ALL")
            {
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(allURL).Result;
                    chuckJokes = JsonConvert.DeserializeObject<Jokes>(json);
                }
            }
            else
            {
                string selectedCATURL = "https://api.chucknorris.io/jokes/random?category=" + selectedCAT;
                using (var client = new HttpClient())
                {
                    string json = client.GetStringAsync(selectedCATURL).Result;
                    chuckJokes = JsonConvert.DeserializeObject<Jokes>(json);
                }
            }

            lstJokes.Items.Add(chuckJokes);
        }
    }
}
