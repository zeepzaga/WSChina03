using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSChina2020AppComp03.Entities;

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Interaction logic for SponsorshipCahrtPage.xaml
    /// </summary>
    public partial class SponsorshipCahrtPage : Page
    {
        List<Sponsorship> sponsorships = new List<Sponsorship>();
        List<Sponsorship> sponsorshipsChart = new List<Sponsorship>();
        public SponsorshipCahrtPage()
        {
            InitializeComponent();

            ChartSponsorship.ChartAreas.Add(new ChartArea("Main"));

            var currentSponsorship = new Series("Amount(Million)¥")
            {
                IsValueShownAsLabel = true
            };
            ChartSponsorship.Series.Add(currentSponsorship);
            try
            {
                sponsorships = AppData.Context.Sponsorships.ToList();
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ICYears.ItemsSource = sponsorships.OrderBy(p=>p.EventCompetition.Year).GroupBy(p => p.EventCompetition.Year);
            sponsorshipsChart.AddRange(sponsorships);
            UpdateChart();
        }
        /// <summary>
        /// Проверка на вывод
        /// </summary>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                sponsorshipsChart.AddRange(sponsorships.Where(p => p.EventCompetition.Year.ToString() == (sender as CheckBox).Content.ToString()));
            }
            else
            {
                foreach (var item in sponsorships.Where(p => p.EventCompetition.Year.ToString() == (sender as CheckBox).Content.ToString()))
                {
                    sponsorshipsChart.Remove(item);
                }
            }
            UpdateChart();
        }
        /// <summary>
        /// Метод обновляющий Chart
        /// </summary>
        private void UpdateChart()
        {
            var currentSeries = ChartSponsorship.Series.FirstOrDefault();
            currentSeries.ChartType = SeriesChartType.StackedColumn;
            currentSeries.Points.Clear();

            foreach (var item in sponsorshipsChart.GroupBy(p => p.EventCompetition.Year))
            {
                currentSeries.Points.AddXY(item.Key, item.Sum(p => Math.Round(p.FullPriceOneCategory/1000000,2)));
            }
        }
    }
}
