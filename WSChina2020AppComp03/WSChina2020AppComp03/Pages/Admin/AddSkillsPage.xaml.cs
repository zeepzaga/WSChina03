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
    /// Interaction logic for AddSkillsPage.xaml
    /// </summary>
    public partial class AddSkillsPage : Page
    {
        List<Competition> competitionsList = new List<Competition>();
        List<Competition> competitionsListBufer = new List<Competition>();
        private EventCompetition _event;
        public AddSkillsPage(EventCompetition @event)
        {
            InitializeComponent();
            _event = @event;
            TblEvent.Text = _event.YearCountryTown;
            try
            {
                competitionsList = AppData.Context.Competitions.ToList();
            }
            catch
            {
                MessageBox.Show("Connection Problem", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            foreach (var item in _event.Competitions) //Цикл позволяющий оставить компетенции которые не свзяаны с выбранным ранее чемпионатом
            {
                competitionsList.Remove(competitionsList.FirstOrDefault(p => p.Id == item.Id));
            }
            if (competitionsList != null)
            {
                DgSkills.ItemsSource = competitionsList;
                TblTotalSkills.Text = $"Total Skills: {DgSkills.Items.Count}";
            }
            else
            {
                TblTotalSkills.Text = "No Data";
            }
        }
        /// <summary>
        /// Кнопка сохраняющая изменения
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var competitoin in competitionsListBufer)
            {
                try
                {
                    _event.Competitions.Add(competitoin);
                    AppData.Context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            AppData.MainFrame.Navigate(new CompetitionSkillsPage(_event));
        }
        /// <summary>
        /// Обработка клика на CheckBox
        /// </summary>
        private void CbSkill_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true) competitionsListBufer.Add((sender as CheckBox).DataContext as Competition);
            if ((sender as CheckBox).IsChecked == false) competitionsListBufer.Remove((sender as CheckBox).DataContext as Competition);

        }
    }
}
