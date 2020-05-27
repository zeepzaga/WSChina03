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
            CbCompetition.SelectedIndex = CbSort.SelectedIndex = 0;
            CbCompetition.ItemsSource = competitionsList;
            BtnSearch_Click(null, null);
        }
        /// <summary>
        /// Обработки кнопки Import Volunteers
        /// </summary>
        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ImportVolonteersPage());
        }
        /// <summary>
        /// Обработка кнопки Adjust volunteers between competition
        /// </summary>
        private void BtnAdjust_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AdjustVolunteerPage());
        }

        /// <summary>
        /// Проверка на какой мы странице странице пользователь и блокировка кнопок следующая и назад, если это надо
        /// </summary>
        private void CheckPage()
        {
            if (_pageNow >= _pageCount) BtnNextPage.IsEnabled = false;
            else BtnNextPage.IsEnabled = true;
            if (_pageNow <= 1) BtnPreviousPage.IsEnabled = false;
            else BtnPreviousPage.IsEnabled = true;
        }
        /// <summary>
        /// Перенос на первую страницу
        /// </summary>
        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow = 1;
            PageFlipping(_pageNow, _searchList);
        }
        /// <summary>
        /// Обратботка кнопки отображения предыдущей относительно текущей страницы
        /// </summary>
        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow--;
            PageFlipping(_pageNow, _searchList);
        }
        /// <summary>
        /// Обратботка кнопки отображения следующей относительно текущей страницы
        /// </summary>
        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow++;
            PageFlipping(_pageNow, _searchList);
        }
        /// <summary>
        /// Обратботка кнопки отображения последней страницы
        /// </summary>
        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            _pageNow = _pageCount;
            PageFlipping(_pageNow, _searchList);
        }
        /// <summary>
        /// Обратботка кнопки отображения конкретной страницы
        /// </summary>
        private void BtnGoPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (decimal.Parse(TbPageNumber.Text) > _pageCount || decimal.Parse(TbPageNumber.Text) < 1)
                {
                    MessageBox.Show($"Enter a number from 1 to {_pageCount}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _pageNow = decimal.Parse(TbPageNumber.Text);
                PageFlipping(_pageNow, _searchList);
            }
            catch { }
        }
        /// <summary>
        /// Метод переворачивающий страницу
        /// </summary>
        /// <param name="newPage">Страница на которую нужно перевернуть</param>
        /// <param name="list">Текущий лист волонтёров исходя из фильтрации</param>
        private void PageFlipping(decimal newPage, List<Volunteer> list)
        {
            DgVolunteer.ItemsSource = null;
            BtnFirstPage.IsEnabled = BtnGoPage.IsEnabled = BtnLastPage.IsEnabled = BtnPreviousPage.IsEnabled 
                = BtnNextPage.IsEnabled = TbPageNumber.IsEnabled = true;
            DgVolunteer.ItemsSource = list.Skip((Convert.ToInt32(newPage) - 1) * 10).Take(10).ToList();
            if (list.Count == 0)
            {
                _pageNow = 0;
                BtnFirstPage.IsEnabled = BtnGoPage.IsEnabled = BtnLastPage.IsEnabled =
                    BtnPreviousPage.IsEnabled = BtnNextPage.IsEnabled = TbPageNumber.IsEnabled = false;
            }
            TblTotalVolunteers.Text = $"Total Volunteers: {_searchList.Count}";
            TblPage.Text = $"{_pageNow} / {_pageCount}";
            CheckPage();
        }
        /// <summary>
        /// Обработка кнопки search
        /// </summary>
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

        /// <summary>
        /// Обработка вводимых клавиш, чтобы в TextBox вводить только цифры 
        /// </summary>
        private void TbPageNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c)))
                e.Handled = true;
        }
    }
}
