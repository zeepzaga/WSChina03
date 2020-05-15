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
using WSChina2020AppComp03.Entities;

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReviousCompetitionPage.xaml
    /// </summary>
    public partial class ReviousCompetitionPage : Page
    {
        private List<PreviousCompetition> _previousCompList = AppData.Context.PreviousCompetitions.ToList();
        private List<Town> _TownList = AppData.Context.Towns.ToList();
        public ReviousCompetitionPage()
        {
            InitializeComponent();
            DgComp.ItemsSource = _previousCompList;
            CbOrdinal.ItemsSource = _previousCompList;
            CbCity.ItemsSource = _TownList;
        }
        private void CbOrdinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            CbOrdinal.ItemsSource = _previousCompList.Where(p => p.Ordinal.Contains(CbOrdinal.Text)).ToList();
            CbOrdinal.IsDropDownOpen = true;
        }

        private void CbOrdinal_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void CbOrdinal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CbOrdinal.Text))
            {
                CbOrdinal.Text = "";
            }
            else
            {
                CbOrdinal.SelectedIndex = 0;
            }
        }

        private void CbCity_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void CbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            CbCity.ItemsSource = _TownList.Where(p => p.Country.Name.Contains(CbCity.Text) || p.Name.Contains(CbCity.Text)).ToList();
            CbCity.IsDropDownOpen = true;
        }

        private void CbCity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CbCity.Text))
            {
                CbCity.Text = "";
            }
            else
            {
                CbCity.SelectedIndex = 0;
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CbOrdinal.Text))
            {
                DgComp.ItemsSource = null;
                DgComp.ItemsSource = _previousCompList.Where(p => p.TownPartial.Contains(CbCity.Text)).ToList();
            }
            else
            {
                DgComp.ItemsSource = null;
                DgComp.ItemsSource = _previousCompList.Where(p => p.Ordinal == (CbOrdinal.SelectedItem as PreviousCompetition).Ordinal && p.TownPartial.Contains(CbCity.Text)).ToList();
            }
        }
    }
}
