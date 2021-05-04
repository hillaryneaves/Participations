using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CSV2Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Data> dataSet = new List<Data>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma separated value documents (.csv)|*.csv";

            Data starData = new Data();

            if (ofd.ShowDialog() == true)
            {
                var lines = File.ReadAllLines(ofd.FileName);
                for (int i = 3; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var pieces = line.Split(',');

                    starData.time = pieces[0];
                    starData.Taylor = Convert.ToInt32(pieces[1]);
                    starData.Kim = Convert.ToInt32(pieces[2]);

                    dataSet.Add(starData);

                    PopulateComboBox();
                }

                List<int> Taylor = new List<int>();
                foreach (var item in dataSet)
                {
                    Taylor.Add(item.Taylor);
                }

                var taylorSum = Taylor.Sum();
                lstTaylor.Items.Add(taylorSum);

                List<int> Kim = new List<int>();
                foreach (var item in dataSet)
                {
                    Kim.Add(item.Kim);
                }

                var kimSum = Kim.Sum();
                lstKim.Items.Add(kimSum);

                //List<int> Combo = new List<int>();
                //foreach (var item in dataSet)
                //{
                //    cmbOptions.Items.Add(item.Taylor);
                //    cmbOptions.Items.Add(item.Kim);
                //}

                //var comboAnswers = Combo(d);
                //cmbOptions.Items.Add(Combo);
            }
        }

        private void PopulateComboBox()
        {
            cmbOptions.Items.Add("Taylor");
            cmbOptions.Items.Add("Kim");
            cmbOptions.SelectedIndex = 0;

            foreach (var item in dataSet)
            {
                if (!cmbOptions.Items.Contains(item.Taylor))
                {
                    cmbOptions.Items.Add(item.Taylor);
                }
            }
        }

        private void cmbOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
