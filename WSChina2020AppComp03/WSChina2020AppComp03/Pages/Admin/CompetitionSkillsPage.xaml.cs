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

namespace WSChina2020AppComp03.Pages.Admin
{
    /// <summary>
    /// Interaction logic for CompetitionSkillsPage.xaml
    /// </summary>
    public partial class CompetitionSkillsPage : Page
    {
        private List<EventCompetition> eventCompetitionsList = new List<EventCompetition>();
        public CompetitionSkillsPage(EventCompetition @event)
        {
            InitializeComponent();
            try
            {
            eventCompetitionsList = AppData.Context.EventCompetitions.ToList();
            }
            catch
            {
                MessageBox.Show("Connection problem", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                BtnAddSkills.IsEnabled = false;
                BtnSearch.IsEnabled = false;
            }
            CbEvent.ItemsSource = eventCompetitionsList;
            if (@event != null)
                CbEvent.SelectedItem = @event;
            else
                CbEvent.SelectedIndex = CbEvent.Items.Count - 1;
            UpdateTable();
        }
        /// <summary>
        /// Метод для обновления страницы
        /// </summary>
        private void UpdateTable()
        {
            var result = new StringBuilder();

            result.Append("<html>");

            result.Append("<meta charset='utf-8'/>");

            result.Append("<body>"); //Стардартные теги html
            result.Append("<table width=100% border=1 bordercolor=#000 style='border-collapse:collapse;'>");//тег создающий табилицу

            result.Append("<tr>");

            result.Append("<td align=center><b>Field</b></td>");

            result.Append("<td align=center><b>Skills Id</b></td>");

            result.Append("<td align=center><b>Skills Name</b></td>");

            result.Append("</tr>"); //Шапка таблицы


            foreach (var competitioncategory in eventCompetitionsList.FirstOrDefault(p => p == CbEvent.SelectedItem as EventCompetition)
                .Competitions.OrderBy(p => p.Id).GroupBy(p => p.CategoryOfCompetition.Name).ToList())
            {
                int i = 0;
                result.Append("<tr>");
                result.Append($"<td rowspan=\"{competitioncategory.Count()}\">{competitioncategory.Key}</td>");
                foreach (var competition in eventCompetitionsList.FirstOrDefault(p => p == CbEvent.SelectedItem as EventCompetition)
                    .Competitions.Where(p => p.CategoryOfCompetition.Name == competitioncategory.Key).ToList())
                {
                    if (i != 0)
                    {
                        result.Append("<tr>");
                    }
                    result.Append($"<td>{competition.Id}</td>");
                    result.Append($"<td>{competition.Name}</td>");
                    result.Append("</tr>");
                    i++;
                } //Заполнение таблицы
            }
            result.Append("</table>"); //Закрытие тега таблицы
            result.Append("</body>");
            if (eventCompetitionsList.FirstOrDefault(p => p == CbEvent.SelectedItem as EventCompetition)
                .Competitions.ToList() == null)
            {
                TblTotalSkills.Text = "No Data";
            }
            else
            {
                WebMain.NavigateToString(result.ToString());
                TblTotalSkills.Text = $"Total SKills: {eventCompetitionsList.FirstOrDefault(p => p == CbEvent.SelectedItem as EventCompetition).Competitions.Count}";
            }
        }
        /// <summary>
        ///     Обработка клика на кнопку Search
        /// </summary>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }
        /// <summary>
        ///     Обработка клика на кнопку Add SKills
        /// </summary>
        private void BtnAddSkills_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AddSkillsPage(CbEvent.SelectedItem as EventCompetition));
        }
    }
}
