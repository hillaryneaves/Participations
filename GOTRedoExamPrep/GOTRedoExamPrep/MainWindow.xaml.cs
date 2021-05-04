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

namespace GOTRedoExamPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SecondWindow quote;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://got-quotes.herokuapp.com/quotes";
            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;
                quote = JsonConvert.DeserializeObject<SecondWindow>(json);
            }

            lstQuote.Items.Add(quote);
        }
    }
}
