using System;
using System.Collections.Generic;
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

namespace WPF_FirstApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lblMessage.Content = string.Empty;
            txtFavoriteNumber.Clear();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for clicking me!", "Clicked", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            lblMessage.Content = "Hello World!";

            string answer = txtFavoriteNumber.Text;
            double result = Convert.ToDouble(answer);

            lblOutput.Content = $"Your favorite number multipled by five is: {(result * 5).ToString("N2")}!";
        }

        private void btnDontClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hahah you clicked me!");
            Environment.Exit(0);
        }
    }
}
