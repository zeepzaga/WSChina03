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
using WSChina2020AppComp03.Pages.Competitor;

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Interaction logic for SponsorshipViewPage.xaml
    /// </summary>
    public partial class SponsorshipViewPage : Page
    {
        List<Event> eventList = new List<Event>();
        List<Competition> competitionList = new List<Competition>();
        List<Sponsorship> sponsorships = AppData.Context.Sponsorships.ToList().OrderByDescending(p=>p.FullPriceOneCategory).ToList();
        List<Sponsorship> sponsorshipsBuffer = new List<Sponsorship>();
        public SponsorshipViewPage()
        {
            InitializeComponent();
            sponsorshipsBuffer = sponsorships;
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
                foreach (var item in AppData.Context.Competitions.ToList())
                {
                    Competition competition = new Competition
                    {
                        Name = item.FullCompetition
                    };
                    competitionList.Add(competition);
                }
                competitionList.Insert(0, new Competition
                {
                    Name = "All Competition"
                });
                DgSponsorship.ItemsSource = sponsorshipsBuffer;
                CbEvent.ItemsSource = eventList;
                CbCompetition.ItemsSource = competitionList;
                CbCompetition.SelectedIndex = CbEvent.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private class Competition
        {
            public string Name { get; set; }
        }

        private class Event //Класс для комбобокса
        {
            public string Name { get; set; }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            sponsorshipsBuffer = sponsorships;
            if(CbCompetition.SelectedIndex>0)
            {
                sponsorshipsBuffer = sponsorshipsBuffer.Where(p => p.Competition.FullCompetition == CbCompetition.Text).ToList();
            }
            if(CbEvent.SelectedIndex>0)
            {
                sponsorshipsBuffer = sponsorshipsBuffer.Where(p => p.EventCompetition.YearCountryTown == CbEvent.Text).ToList();
            }
            sponsorshipsBuffer = sponsorshipsBuffer.Where(p => p.Sponsor.Name.Contains(TbSponsor.Text)).ToList();
            DgSponsorship.ItemsSource = null;
            DgSponsorship.ItemsSource = sponsorshipsBuffer;
        }
        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ExportSponsorshipDetail(sponsorshipsBuffer));
        }
    }
}
