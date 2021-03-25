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

namespace RickAndMortyRedoExamPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RickAndMortyAPI rickandmortyAPI;
            string url = "https://rickandmortyapi.com/api/character";

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync(url).Result;
                rickandmortyAPI = JsonConvert.DeserializeObject<RickAndMortyAPI>(jsonData);

                foreach (var character in rickandmortyAPI.results)
                {
                    lstCharacters.Items.Add(character);
                }
            }

            for (int i = 0; i < rickandmortyAPI.ToString().Length; i++)
            {
                if (rickandmortyAPI.info.next != null)
                {
                    using (var client = new HttpClient())
                    {
                        url = client.GetStringAsync(rickandmortyAPI.info.next).Result;
                        rickandmortyAPI = JsonConvert.DeserializeObject<RickAndMortyAPI>(url);

                        foreach (var item in rickandmortyAPI.results.ToList())
                        {
                            lstCharacters.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void lstCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (Character)lstCharacters.SelectedItem;
            SecondWindow scdWindow = new SecondWindow();
            scdWindow.imgCharacters.Source = new BitmapImage(new Uri(selectedCharacter.image));
            scdWindow.ShowDialog();
        }
    }
}
