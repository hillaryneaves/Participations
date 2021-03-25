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

namespace PokeRedo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AllPokemonAPI api;
            string url = "https://pokeapi.co/api/v2/pokemon?limit=1200";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<AllPokemonAPI>(json);
            }

            foreach (var item in api.results.OrderBy(x => x.name).ToList())
            {
                lstPokemons.Items.Add(item);
            }
        }

        private void lstPokemons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (ResultObject)lstPokemons.SelectedItem;

            string url = selectedCharacter.url;

            URL api;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<URL>(json);
            }

            lblHeight.Content = $"Height: {api.height}";
            lblWeight.Content = $"Weight: {api.weight}";

            string picturePoke = api.sprites.front_default;
            imgPoke.Source = new BitmapImage(new Uri(picturePoke));
        }

        bool PictureAtFront = true;
        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacter = (ResultObject)lstPokemons.SelectedItem;
            string url = selectedCharacter.url;
            URL api;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<URL>(json);
            }

            string picturePoke = api.sprites.front_default;
            string picturePokes = api.sprites.back_default;

            if (PictureAtFront == true)
            {
                imgPoke.Source = new BitmapImage(new Uri(picturePokes));
                PictureAtFront = false;
            }
            else if (PictureAtFront == false)
            {
                imgPoke.Source = new BitmapImage(new Uri(picturePoke));
                PictureAtFront = true;
            }
        }
    }
}
