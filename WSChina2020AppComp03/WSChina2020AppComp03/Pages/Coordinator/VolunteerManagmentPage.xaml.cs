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

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Interaction logic for VolunteerManagmentPage.xaml
    /// </summary>
    public partial class VolunteerManagmentPage : Page
    {
        List<Volunteer> _listVolunteers = new List<Volunteer>();
        List<Volunteer> _searchList = new List<Volunteer>();
        List<string> _sort = new List<string>();
        decimal _pageCount = 0;
        decimal _pageNow = 1;
        public VolunteerManagmentPage()
        {
            InitializeComponent();
            _listVolunteers = AppData.Context.Volunteers.ToList();
            _searchList = _listVolunteers;
            _sort.Add("IdNumber");
            _sort.Add("Name");
            _sort.Add("Gender");
            _sort.Add("Occupation");
            _sort.Add("Province");
            _sort.Add("Competition");
            CbSort.ItemsSource = _sort;
            List<Competition> competitionsList = AppData.Context.Competitions.ToList();
            competitionsList.Insert(0, new Competition
            {
                Name = "All Competition",
                CategoryOfCompetitionId = 1,
                Description = ""
            });
            CbCompetition.SelectedIndex = 0;
            CbCompetition.ItemsSource = competitionsList;
            BtnSearch_Click(null, null);
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ImportVolonteersPage());
        }

        private void BtnAdjust_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckPage()
        {
            if (_pageNow == _pageCount) BtnNextPage.IsEnabled = false;
            else BtnNextPage.IsEnabled = true;
            if (_pageNow == 1) BtnPreviousPage.IsEnabled = false;
            else BtnPreviousPage.IsEnabled = true;
        }
        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow = 1;
            PageFlipping(_pageNow, _searchList);
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow--;
            PageFlipping(_pageNow, _searchList);
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow++;
            PageFlipping(_pageNow, _searchList);
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow = _pageCount;
            PageFlipping(_pageNow, _searchList);
        }

        private void BtnGoPage_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(TbPageNumber.Text) > _pageCount)
            {
                MessageBox.Show($"Too many pages, only {_pageCount}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _pageNow = decimal.Parse(TbPageNumber.Text);
            PageFlipping(_pageNow, _searchList);
        }

        private void PageFlipping(decimal newPage, List<Volunteer> list)
        {
            DgVolunteer.ItemsSource = null;
            DgVolunteer.ItemsSource = list.Skip((Convert.ToInt32(newPage) - 1) * 10).Take(10).ToList();
            TblTotalVolunteers.Text = $"Total Volunteers: {_searchList.Count}";
            TblPage.Text = $"{_pageNow} / {_pageCount}";
            CheckPage();
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (CbSort.SelectedIndex)
            {
                case 1:
                    _searchList = _listVolunteers.OrderBy(p => p.Name).ToList();
                    break;
                case 2:
                    _searchList = _listVolunteers.OrderBy(p => p.GenderId).ToList();
                    break;
                case 3:
                    _searchList = _listVolunteers.OrderBy(p => p.RepresentCountryId).ToList();
                    break;
                case 4:
                    _searchList = _listVolunteers.OrderBy(p => p.BornCountryId).ToList();
                    break;
                case 5:
                    _searchList = _listVolunteers.OrderBy(p => p.CompetitionId).ToList();
                    break;
                default:
                    _searchList = _listVolunteers.OrderBy(p => p.Id).ToList();
                    break;
            }
            if (CbCompetition.SelectedIndex > 0)
            {
                _searchList = _searchList.ToList().Where(p => p.Competition == CbCompetition.SelectedItem as Competition).ToList();
            }
            _pageNow = 1;
            _pageCount = Math.Ceiling((decimal)_searchList.Count / 10);
            PageFlipping(_pageNow, _searchList);
        }
    }
}
