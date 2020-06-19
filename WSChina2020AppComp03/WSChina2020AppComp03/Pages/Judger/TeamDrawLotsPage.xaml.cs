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

namespace WSChina2020AppComp03.Pages.Judger
{
    /// <summary>
    /// Interaction logic for TeamDrawLotsPage.xaml
    /// </summary>
    public partial class TeamDrawLotsPage : Page
    {
        List<int> stationNumbersList = new List<int>();
        public TeamDrawLotsPage()
        {
            InitializeComponent();
            try
            {
                var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
                TblEvent.Text = $"{judger.EventCompetition.YearCountryTown}";
                TblSkill.Text = $"{judger.Competition.FullCompetition}";
                if (judger.IsMain == false) //Если эксперт не главный
                {
                    MessageBox.Show("To perform the draw you must be the main expert", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    BtnDrawLots.IsEnabled = false; // то
                }
                DgCompetitiors.ItemsSource = AppData.Context.TeamCompetitions.ToList().
                    Where(p => p.EventCompetitionId == judger.EventCompetitionId && judger.CompetitionId == p.CompetitionId).OrderBy(p => p.TeamId).
                    GroupBy(p => p.TeamId);
                // Заполнение листа с порядковыми норерами
                for (int i = 1; i <=
                    AppData.Context.TeamCompetitions.ToList().
                    Where(p => p.EventCompetitionId == judger.EventCompetitionId && judger.CompetitionId == p.CompetitionId).
                    GroupBy(p => p.TeamId).ToList().Count; i++)
                {
                    stationNumbersList.Add(i);
                }
                TblTotal.Text = $"Total Members: " +
                    $"{AppData.Context.TeamCompetitions.ToList().Where(p => p.CompetitionId == judger.CompetitionId && p.EventCompetitionId == judger.EventCompetitionId).ToList().Count}";
                // Удаление использованных ранее номеров
                foreach (var team in AppData.Context.TeamCompetitions.ToList().
                    Where(p => p.EventCompetitionId == judger.EventCompetitionId && judger.CompetitionId == p.CompetitionId && p.StationNumber != null).
                    GroupBy(p => p.TeamId).ToList())
                {
                    stationNumbersList.Remove(Convert.ToInt32(AppData.Context.TeamCompetitions.FirstOrDefault(p => p.TeamId == team.Key).StationNumber));
                }
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                BtnDrawLots.IsEnabled = false;
            }
            
        }

        private void BtnDrawLots_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random random = new Random();
                var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
                foreach (var team in AppData.Context.TeamCompetitions.ToList().Where(p => p.StationNumber == null).ToList().GroupBy(p => p.TeamId))
                {
                    foreach (var teamItem in AppData.Context.TeamCompetitions.ToList().Where(p => p.TeamId == team.Key).ToList())
                    {
                        int index; // переменная хранящая выпавший индекс
                        index = random.Next(0, stationNumbersList.Count);  //получение случайного индекса
                        teamItem.StationNumber = stationNumbersList[index];
                        AppData.Context.SaveChanges();
                        stationNumbersList.RemoveAt(index);
                        DgCompetitiors.ItemsSource = null;
                        DgCompetitiors.ItemsSource = AppData.Context.TeamCompetitions.ToList().
                    Where(p => p.EventCompetitionId == judger.EventCompetitionId && judger.CompetitionId == p.CompetitionId).OrderBy(p => p.TeamId).
                    GroupBy(p => p.TeamId);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                BtnDrawLots.IsEnabled = false;
            }
          
        }
    }
}
