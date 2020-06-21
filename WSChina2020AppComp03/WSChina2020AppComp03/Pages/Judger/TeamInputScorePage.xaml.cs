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
    /// Interaction logic for TeamInputScorePage.xaml
    /// </summary>
    public partial class TeamInputScorePage : Page
    {
        private List<TeamScore> teamScoresList = new List<TeamScore>(); // Лист для таблицы
        private List<TeamPoints> teamPointsList = new List<TeamPoints>(); // Лист для результатов одной команды
        Entities.Judger judger; // Переменная для хранения эксперта
        public TeamInputScorePage()
        {
            InitializeComponent();
            try
            {
                judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id); // Присвоение эксперту его компетенции
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateData();
            TblEvent.Text = judger.EventCompetition.YearCountryTown;
            TblSkill.Text = judger.Competition.FullCompetition;
        }
        /// <summary>
        /// Обработка выбора команды из талицы
        /// </summary>
        private void DgScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DgScore.Items.Count != 0)
                {
                    teamPointsList.Clear();
                    var team = AppData.Context.TeamCompetitions.ToList().FirstOrDefault(p => p.TeamId == (DgScore.SelectedItem as TeamScore).TeamId);
                    var schedules = AppData.Context.Schedules.ToList().
                            Where(p => p.CompetitionId == team.CompetitionId && p.EventCompetitionId == team.EventCompetitionId).ToList();
                    foreach (var schedule in schedules)
                    {
                        if (AppData.Context.ScheduleOfTeams.ToList().FirstOrDefault(p => p.ScheduleId == schedule.Id && p.TeamId == team.TeamId) == null)
                        {
                            AppData.Context.ScheduleOfTeams.Add(new ScheduleOfTeam
                            {
                                TeamId = team.TeamId,
                                Points = 0,
                                ScheduleId = schedule.Id
                            });
                            AppData.Context.SaveChanges();
                        }
                        foreach (var item in AppData.Context.ScheduleOfTeams.ToList().
                            Where(p => p.TeamId == team.TeamId && p.ScheduleId == schedule.Id).OrderBy(p => p.ScheduleId))
                        {
                            teamPointsList.Add(new TeamPoints
                            {
                                Name = schedule.Name,
                                TeamId = team.TeamId,
                                Points = item.Points,
                                ScheduleId = schedule.Id
                            });
                        }
                    }
                    ICSchedule.ItemsSource = null;
                    ICSchedule.ItemsSource = teamPointsList;
                    TblTotalScore.Text = $"{teamPointsList.Sum(p => p.Points)}";
                    TblName.Text = team.Names;
                }
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обработка кнопки сохранить
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (decimal.Parse(TblTotalScore.Text.Replace(".", ",")) <= 100)
                {
                    foreach (var item in teamPointsList)
                    {
                        var scheduleOfCompetitior = AppData.Context.ScheduleOfTeams.ToList().
                            FirstOrDefault(p => p.TeamId == item.TeamId && p.ScheduleId == item.ScheduleId);
                        scheduleOfCompetitior.Points = item.Points;
                    }
                    AppData.Context.SaveChanges();
                    UpdateData();
                }
                else
                {
                    MessageBox.Show("Maximum number of points is 100", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обработка изменения текста в полях для результатов
        /// </summary>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tbx = sender as TextBox;
                if (tbx.Text == "0")
                {
                    tbx.Text = "0.00";
                }
                if (!tbx.Text.Contains('.'))
                    Dispatcher.BeginInvoke(new Action(() => tbx.Undo()));
                TeamPoints model = teamPointsList.FirstOrDefault(p => p == ((sender as TextBox).DataContext as TeamPoints));
                model.Points = Convert.ToDecimal((sender as TextBox).Text.Replace(".", ","));
                TblTotalScore.Text = $"{teamPointsList.Sum(p => p.Points)}";
            }
            catch
            {

            }
        }
        /// <summary>
        /// Метод для обновления данных
        /// </summary>
        private void UpdateData()
        {
            try
            {
                decimal score = 0;
                teamScoresList.Clear();
                foreach (var team in AppData.Context.TeamCompetitions.ToList().
                    Where(p => p.CompetitionId == judger.CompetitionId && p.EventCompetitionId == judger.EventCompetitionId).ToList().GroupBy(p => p.TeamId))
                {
                    string StringScore = "";
                    foreach (var point in AppData.Context.ScheduleOfTeams.ToList().Where(p => p.TeamId == team.Key))
                    {
                        score += Convert.ToDecimal(point.Points);
                    }
                    StringScore = score.ToString("f2");
                    if (score == 0)
                    {
                        StringScore = "--";
                    }
                    var teamData = AppData.Context.TeamCompetitions.ToList().FirstOrDefault(p => p.TeamId == team.Key);
                    teamScoresList.Add(new TeamScore
                    {
                        Names = teamData.Names,
                        Province = teamData.Province,
                        TeamId = team.Key,
                        Score = StringScore,
                        StationNumber = teamData.StationNumber
                    });
                    score = 0;
                }
                DgScore.ItemsSource = null;
                DgScore.ItemsSource = teamScoresList;
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Класс для таблицы
        /// </summary>
        private class TeamScore
        {
            public int TeamId { get; set; }
            public string Names { get; set; }
            public string Province { get; set; }
            public int? StationNumber { get; set; }
            public string Score { get; set; }
        }
        /// <summary>
        /// Класс для хранения результатов выбранной команды
        /// </summary>
        private class TeamPoints
        {
            public string Name { get; set; }
            public int ScheduleId { get; set; }
            public decimal Points { get; set; }
            public int TeamId { get; set; }
        }
        /// <summary>
        /// Метод позволяющий вводить только цифры
        /// </summary>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Метод загрузки текстбокса, для нормального отображения данных
        /// </summary>
        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            var tbx = sender as TextBox;
            if (tbx.Text=="0")
            {
                tbx.Text = "0.00";
            }
        }
    }
}
