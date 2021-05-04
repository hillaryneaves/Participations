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

namespace FirstWPFApplication
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

        private void btn_Submit(object sender, RoutedEventArgs e)
        {
            string answer = txtBirthday.Text;
            DateTime result = Convert.ToDateTime(answer);

            string name = txtName.Text;

            DateTime today = DateTime.Now;
            TimeSpan age = today - result;

            lblAnswer.Content = $"Thank you {name}! Based on your inputs, you are {age.Days / 365} years old.";
            MessageBox.Show($"Thank you {name}! Based on your inputs, you are {age.Days / 365} years old.");

        }

        private void btnAnswer_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid.Background = Brushes.LightCoral;
        }

        private void btnAnswer_MouseLeave(object sender, MouseEventArgs e)
        {
            BrushConverter convert = new BrushConverter();
            Grid.Background = (Brush)convert.ConvertFrom("#FFC94FE8");
        }
    }
}
