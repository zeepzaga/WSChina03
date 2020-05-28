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
    /// Interaction logic for SponsorshipStatisticsPage.xaml
    /// </summary>
    public partial class SponsorshipStatisticsPage : Page
    {
        //Листо со всеми спонсорствами
        private List<Sponsorship> sponsorList = AppData.Context.Sponsorships.ToList();
        // Листы для комбобоксов
        List<Event> eventList = new List<Event>();
        private List<string> displayList = new List<string>();
        private decimal _totalAmount = 0; //Общая сумма спонсорства

        public SponsorshipStatisticsPage()
        {
            InitializeComponent();
            try
            {
                foreach (var item in AppData.Context.EventCompetitions.ToList())
                {
                    Event @event = new Event
                    {
                        Name = item.YearCountryTown
                    };
                    eventList.Add(@event);
                }
                eventList.Insert(0, new Event
                {
                    Name = "All Events"
                });
                CbEvent.ItemsSource = eventList;
                displayList.Add("Sponsor");
                displayList.Add("SponsorshipCategory");
                CbDisplay.SelectedIndex = CbEvent.SelectedIndex = 0;
                CbDisplay.ItemsSource = displayList;
                UpdateData();
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private class Event //Класс для комбобокса
        {
            public string Name { get; set; }
        }

        /// <summary>
        /// Обработка кнопки поиск
        /// </summary>
        private void BtnStatistics_Click(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }
        private void UpdateData()
        {
            _totalAmount = 0;
            if (CbEvent.SelectedIndex == 0) //Если выбраны все компетенции
            {
                switch (CbDisplay.SelectedIndex)
                {
                    case 0:
                        DgSponshipByCategory.Visibility = Visibility.Collapsed;
                        DgSponsorshipBySponsor.Visibility = Visibility.Visible;
                        DgSponsorshipBySponsor.ItemsSource = null;
                        DGCSponsorshipCategoryForSponsor.Binding = new Binding("AllCategoryList");
                        DGCSponsorhipFullPriceForSponsor.Binding = new Binding("AllFullPriceSponsor");
                        DgSponsorshipBySponsor.ItemsSource = sponsorList.OrderBy(p => p.AllFullPriceSponsor).GroupBy(p => p.Sponsor.Name);
                        break;
                    case 1:
                        DgSponsorshipBySponsor.Visibility = Visibility.Collapsed;
                        DgSponshipByCategory.Visibility = Visibility.Visible;
                        DgSponshipByCategory.ItemsSource = null;
                        DGCAmountForCategory.Binding = new Binding("AllFullPriceCategory");
                        DGCSponsorForCategory.Binding = new Binding("AllSponsorList");
                        DgSponshipByCategory.ItemsSource = sponsorList.OrderBy(p => p.AllFullPriceCategory).GroupBy(p => p.CategoryOfSponsorship.Name);
                        break;
                    default:
                        break;
                }
                foreach (var amount in sponsorList)
                {
                    _totalAmount += Convert.ToDecimal(amount.Count * amount.UnitPrice); //Подсчёт общей суммы
                }
                TblTotalAmount.Text = $"TotalAmount {_totalAmount} (¥)";
                return;
            }
            switch (CbDisplay.SelectedIndex)
            {
                case 0:
                    DgSponshipByCategory.Visibility = Visibility.Collapsed;
                    DgSponsorshipBySponsor.Visibility = Visibility.Visible;
                    DgSponsorshipBySponsor.ItemsSource = null;
                    DGCSponsorshipCategoryForSponsor.Binding = new Binding("CategoryList");
                    DGCSponsorhipFullPriceForSponsor.Binding = new Binding("FullPriceSponsor");
                    DgSponsorshipBySponsor.ItemsSource =
                        sponsorList.Where(p => p.EventCompetition.YearCountryTown == CbEvent.Text).OrderBy(p => p.FullPriceSponsor).
                        GroupBy(p => p.Sponsor.Name);
                    break;
                case 1:
                    DgSponsorshipBySponsor.Visibility = Visibility.Collapsed;
                    DgSponshipByCategory.Visibility = Visibility.Visible;
                    DgSponshipByCategory.ItemsSource = null;
                    DGCAmountForCategory.Binding = new Binding("FullPriceCategory");
                    DGCSponsorForCategory.Binding = new Binding("SponsorList");
                    DgSponshipByCategory.ItemsSource =
                        sponsorList.Where(p => p.EventCompetition.YearCountryTown == CbEvent.Text).OrderBy(p => p.FullPriceCategory).GroupBy(p => p.CategoryOfSponsorship.Name);
                    break;
                default:
                    break;
            }
            foreach (var amount in sponsorList.Where(p => p.EventCompetition.YearCountryTown == CbEvent.Text))
            {
                _totalAmount += Convert.ToDecimal(amount.Count * amount.UnitPrice); //Подсчёт общей суммы
            }
            TblTotalAmount.Text = $"TotalAmount {_totalAmount} (¥)";
        }
    }
}
