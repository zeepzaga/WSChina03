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
    /// Interaction logic for InputScorePage.xaml
    /// </summary>
    public partial class InputScorePage : Page
    {
        List<TableScore> tableScoresList = new List<TableScore>();
        List<CompetitiorPoints> competitiorPointsList = new List<CompetitiorPoints>();
        public InputScorePage()
        {
            InitializeComponent();
            var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            TblEvent.Text = judger.EventCompetition.YearCountryTown;
            TblSkill.Text = judger.Competition.FullCompetition;
            UpdateData();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tbx = sender as TextBox;
                if (tbx.SelectedText.Length == tbx.Text.Length)
                {
                    tbx.Text = ".";
                }
                if (!tbx.Text.Contains('.'))
                    Dispatcher.BeginInvoke(new Action(() => tbx.Undo()));
                CompetitiorPoints model = competitiorPointsList.FirstOrDefault(p => p == ((sender as TextBox).DataContext as CompetitiorPoints));
                if (tbx.Text == ".")
                {
                    model.Points = 0;
                }
                else
                {
                    model.Points = Convert.ToDecimal((sender as TextBox).Text.Replace(".", ","));
                }
                TblTotalScore.Text = $"{competitiorPointsList.Sum(p => p.Points)}";
            }
            catch
            {

            }
        }
        private class TableScore
        {
            public string CompetitiorNumber { get; set; }
            public string Name { get; set; }
            public string Province { get; set; }
            public string StationNumber { get; set; }
            public string Score { get; set; }
        }

        private class CompetitiorPoints
        {
            public string Name { get; set; }
            public int ScheduleId { get; set; }
            public decimal Points { get; set; }
            public string CompetitiorNumber { get; set; }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in competitiorPointsList)
            {
                var scheduleOfCompetitior = AppData.Context.ScheduleOfCompetitors.ToList().
                    FirstOrDefault(p => p.CompetitorId == item.CompetitiorNumber && p.ScheduleId == item.ScheduleId);
                scheduleOfCompetitior.Points = item.Points;
            }
            AppData.Context.SaveChanges();
            UpdateData();
        }
        private void UpdateData()
        {
            tableScoresList.Clear();
            var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            decimal score = 0;
            foreach (var competitior in AppData.Context.Competitiors.ToList().Where(p => p.CompetitionId == judger.CompetitionId
            && p.EventCompetitionId == judger.EventCompetitionId))
            {
                string StringScore = "";
                foreach (var point in AppData.Context.ScheduleOfCompetitors.ToList().Where(p => p.CompetitorId == competitior.Id))
                {
                    score += Convert.ToDecimal(point.Points);
                }
                StringScore = score.ToString("f2");
                if (score == 0)
                {
                    StringScore = "--";
                }
                tableScoresList.Add(new TableScore
                {
                    CompetitiorNumber = competitior.Id.ToString(),
                    Name = competitior.FullName,
                    Province = competitior.User.Town.Name,
                    StationNumber = competitior.StationNumber.ToString(),
                    Score = StringScore
                });
                score = 0;
            }
            DgScore.ItemsSource = null;
            DgScore.ItemsSource = tableScoresList;
        }

        private void DgScore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DgScore.Items.Count != 0)
                {
                    competitiorPointsList.Clear();
                    var competitior = AppData.Context.Competitiors.ToList().FirstOrDefault(p => p.Id.ToString() == (DgScore.SelectedItem as TableScore).CompetitiorNumber);
                    var schedules = AppData.Context.Schedules.ToList().
                            Where(p => p.CompetitionId == competitior.CompetitionId && p.EventCompetitionId == competitior.EventCompetitionId).ToList();
                    foreach (var schedule in schedules)
                    {
                        if (AppData.Context.ScheduleOfCompetitors.ToList().FirstOrDefault(p => p.ScheduleId == schedule.Id && p.CompetitorId == competitior.Id) == null)
                        {
                            AppData.Context.ScheduleOfCompetitors.Add(new ScheduleOfCompetitor
                            {
                                CompetitorId = competitior.Id,
                                Points = 0,
                                ScheduleId = schedule.Id
                            });
                            AppData.Context.SaveChanges();
                        }
                        foreach (var item in AppData.Context.ScheduleOfCompetitors.ToList().Where(p => p.CompetitorId == competitior.Id && p.ScheduleId == schedule.Id).OrderBy(p => p.ScheduleId))
                        {
                            competitiorPointsList.Add(new CompetitiorPoints
                            {
                                Name = schedule.Name,
                                CompetitiorNumber = competitior.Id,
                                Points = Convert.ToDecimal(item.Points),
                                ScheduleId = schedule.Id
                            });
                        }
                    }
                    ICSchedule.ItemsSource = null;
                    ICSchedule.ItemsSource = competitiorPointsList;
                    TblTotalScore.Text = $"{competitiorPointsList.Sum(p => p.Points)}";
                    TblName.Text = competitior.FullName;
                }
            }
            catch
            {
                MessageBox.Show("Unknown Error", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
