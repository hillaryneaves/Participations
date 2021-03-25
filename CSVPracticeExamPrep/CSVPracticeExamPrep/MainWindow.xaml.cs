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

namespace CSVPracticeExamPrep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Data> dataFile = new List<Data>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma seperated value documents (.csv)|*.csv";

            Data coffeeData = new Data();

            if (ofd.ShowDialog() == true)
            {
                var lines = File.ReadAllLines(ofd.FileName);

                for (int i = 3; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var pieces = line.Split(',');

                    coffeeData.week = pieces[0];
                    coffeeData.Starbucks = Convert.ToInt32(pieces[1]);
                    coffeeData.Dunkin = Convert.ToInt32(pieces[2]);

                    dataFile.Add(coffeeData);
                }

                List<int> Starbucks = new List<int>();
                foreach (var item in dataFile)
                {
                    Starbucks.Add(item.Starbucks);
                }

                var starbucksSum = Starbucks.Sum();
                lstStarbucks.Items.Add(starbucksSum);

                List<int> Dunkin = new List<int>();
                foreach (var item in dataFile)
                {
                    Dunkin.Add(item.Dunkin);
                }

                var dunkinSum = Dunkin.Sum();
                lstDunkin.Items.Add(dunkinSum);

                List<int> AverageData = new List<int>();
                foreach (var item in dataFile)
                {
                    AverageData.Add(item.Starbucks);
                    AverageData.Add(item.Dunkin);
                }

                var averageSum = AverageData.Average();
                lstAverage.Items.Add(averageSum);
            }
        }
    }
}
