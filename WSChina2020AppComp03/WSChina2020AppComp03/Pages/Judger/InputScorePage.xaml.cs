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
        List<TableScore> tableScoresList = new List<TableScore>(); // Лист для таблицы
        List<CompetitiorPoints> competitiorPointsList = new List<CompetitiorPoints>(); // Лист для рещультатов выбранного полбзователя
        public InputScorePage()
        {
            InitializeComponent();
            var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            if (!judger.IsMain)
            {
                MessageBox.Show("You need to be the chief expert to change the results", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                BtnSave.IsEnabled = false;
            }
            TblEvent.Text = judger.EventCompetition.YearCountryTown;
            TblSkill.Text = judger.Competition.FullCompetition;
            UpdateData();
        }
        /// <summary>
        /// Обработка изменения данных в поле для ввода результатов
        /// </summary>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tbx = sender as TextBox;
                if(tbx.Text=="0")
                {
                    tbx.Text = "0.00";
                }
                if (!tbx.Text.Contains('.'))
                    Dispatcher.BeginInvoke(new Action(() => tbx.Undo()));
                CompetitiorPoints model = competitiorPointsList.FirstOrDefault(p => p == ((sender as TextBox).DataContext as CompetitiorPoints));
                model.Points = Convert.ToDecimal((sender as TextBox).Text.Replace(".", ","));
                TblTotalScore.Text = $"{competitiorPointsList.Sum(p => p.Points)}";
            }
            catch
            {

            }
        }
        /// <summary>
        /// Класс для правильного отображения данных в таблице
        /// </summary>
        private class TableScore
        {
            public string CompetitiorNumber { get; set; }
            public string Name { get; set; }
            public string Province { get; set; }
            public string StationNumber { get; set; }
            public string Score { get; set; }
        }
        /// <summary>
        /// Класс для хранения результатов выюранного юзера
        /// </summary>
        private class CompetitiorPoints
        {
            public string Name { get; set; }
            public int ScheduleId { get; set; }
            public decimal Points { get; set; }
            public string CompetitiorNumber { get; set; }
        }
        /// <summary>
        /// Обработка кнопки сохранения
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (decimal.Parse(TblTotalScore.Text.Replace(".", ",")) <= 100)
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
        /// Обновление данных в таблице
        /// </summary>
        private void UpdateData()
        {
            try
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
            catch
            {
                MessageBox.Show("Data Base Error", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обработка выбора участника из списка
        /// </summary>
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
                                Points = item.Points,
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
            if (tbx.Text == "0")
            {
                tbx.Text = "0.00";
            }
        }
    }
}
