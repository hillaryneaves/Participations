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

namespace RedoHW3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TVShow> TVShows = new List<TVShow>();
        private char[] CharactersToTrim = { '"', ' ' };
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            foreach (var line in lines)
            {
                TVShows.Add(new TVShow(line));
            }

            PopulateListBox(TVShows);
            PopulateRatingFilter();
            PopulateCountryFilter();
            PopulateLanguageFilter();
        }

        private void PopulateListBox(List<TVShow> tVShows)
        {
            lstMainList.Items.Clear();
            foreach (var show in tVShows)
            {
                lstMainList.Items.Add(show);
            }
        }

        private void PopulateRatingFilter()
        {
            cmbRating.Items.Add("All");
            cmbRating.SelectedIndex = 0;
            
            foreach (var show in TVShows)
            {
                if (string.IsNullOrWhiteSpace(show.Rated))
                {
                    continue;
                }
                string cleanedValue = show.Rated.Trim();
                if (!cmbRating.Items.Contains(cleanedValue))
                {
                    cmbRating.Items.Add(cleanedValue);
                }
            }
        }

        private void PopulateCountryFilter()
        {
            cmbCountry.Items.Add("All");
            cmbCountry.SelectedIndex = 0;

            foreach (var show in TVShows)
            {
                var values = show.Country.Split(',');

                foreach (var val in values)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    string cleanedValue = val.Trim(CharactersToTrim);
                    if (!cmbCountry.Items.Contains(cleanedValue))
                    {
                        cmbCountry.Items.Add(cleanedValue);
                    }
                }
            }
        }

        private void PopulateLanguageFilter()
        {
            cmbLanguage.Items.Add("All");
            cmbLanguage.SelectedIndex = 0;

            foreach (var show in TVShows)
            {
                var values = show.Language.Split(',');

                foreach (var val in values)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    string cleanedValue = val.Trim(CharactersToTrim);
                    if (!cmbLanguage.Items.Contains(cleanedValue))
                    {
                        cmbLanguage.Items.Add(cleanedValue);
                    }
                }
            }
        }

        private void cmbRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void UpdateDataForFilters()
        {
            if (cmbLanguage.SelectedValue is null || cmbRating.SelectedValue is null || cmbCountry.SelectedValue is null)
            {
                return;
            }
            List<TVShow> filteredShows;

            filteredShows = FilterRating(TVShows);
            filteredShows = FilterLanguage(filteredShows);
            filteredShows = FilterCountry(filteredShows);

            PopulateListBox(filteredShows);
        }

        private List<TVShow> FilterCountry(List<TVShow> shows)
        {
            string country = cmbCountry.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (country.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Country.Contains(country))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }

        private List<TVShow> FilterLanguage(List<TVShow> shows)
        {
            string language = cmbLanguage.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (language.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Language.Contains(language))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }

        private List<TVShow> FilterRating(List<TVShow> shows)
        {
            string rating = cmbRating.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (rating.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Rated.Contains(rating))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }

        private void cmbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void cmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cmbLanguage.SelectedValue = 0;
            cmbCountry.SelectedValue = 0;
            cmbRating.SelectedValue = 0;
        }

        private void lstMainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TVShow selectedShow = (TVShow)lstMainList.SelectedItem;
            Window1 wnd = new Window1();
            wnd.SetUpWindow(selectedShow);
            wnd.ShowDialog();
        }
    }
}
