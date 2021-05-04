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

namespace GOTQuote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SecondWindow GOTurl;
            string url = "https://got-quotes.herokuapp.com/quotes";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                GOTurl = JsonConvert.DeserializeObject<SecondWindow>(json);
            }

            foreach (var item in GOTurl.results.OrderBy(x => x.quote).ToList())
            {
                lstQuote.Items.Add(item);
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            var gotQuote = (ResultObject)lstQuote.SelectedItem;
            string url = gotQuote.url;
            SecondWindow GOTurl;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                GOTurl = JsonConvert.DeserializeObject<SecondWindow>(json);
            }
        }
    }
}
