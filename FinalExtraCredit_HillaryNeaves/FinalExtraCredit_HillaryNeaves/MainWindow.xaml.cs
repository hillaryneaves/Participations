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

namespace FinalExtraCredit_HillaryNeaves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Thank you for showing an interest in seeing all that I have learned" +
                $"this semester! Now, please click the next tab to go to my example problem that" +
                $"showcases my knowledge.");
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ouch! I know you want to see everything that I have learned this" +
                $"semester. I'll give you another chance...select the 'Yes!' box this time!!");
        }
        private void btnYes_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid.Background = Brushes.LightCoral;
        }

        private void btnYes_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter convert = new BrushConverter();
            Grid.Background = (Brush)convert.ConvertFrom("#FFC94FE8");
        }

        private void btnNo_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid.Background = Brushes.BlueViolet;
        }

        private void btnNo_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter convert = new BrushConverter();
            Grid.Background = (Brush)convert.ConvertFrom("#FFC94FE8");
        }
    }
}
