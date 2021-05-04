using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RedoHW3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        public void SetUpWindow(TVShow show)
        {
            imgPoster.Source = new BitmapImage(new Uri(show.Poster));
            txtPlot.Text = show.Plot;
            this.Title = show.Title;
        }
    }
}
