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

namespace WPF_Web_Browser
{
    /// <summary>
    /// Interaction logic for MyWebBrowserWindow.xaml
    /// </summary>
    public partial class MyWebBrowserWindow : Window
    {
        public string Query { get; set; }

        public MyWebBrowserWindow()
        {
            InitializeComponent();

            webHillary.Navigate($"https://www.google.com/search?q={Query}");
        }
            public void Search(string q)
            {
                Query = q;
                webHillary.Navigate($"https://www.google.com/search?q={q}");
            }

        public void Search()
        {
            webHillary.Navigate($"https://www.google.com/search?q={Query}");
        }
       
    }
}
