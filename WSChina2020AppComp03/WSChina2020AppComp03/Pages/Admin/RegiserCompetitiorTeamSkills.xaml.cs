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
    /// Interaction logic for RegiserCompetitiorTeamSkills.xaml
    /// </summary>
    public partial class RegiserCompetitiorTeamSkills : Page
    {
        Competition _competition;
        EventCompetition _event;
        List<Competitior> competitiorsList = new List<Competitior>();
        int teamId = 1;
        public RegiserCompetitiorTeamSkills(Competition competition, EventCompetition @event)
        {
            InitializeComponent();
            _competition = competition;
            _event = @event;
            TblEvent.Text = @event.YearCountryTown;
            TblSkills.Text = competition.FullCompetition;
            TeamCompetition lastTeam = AppData.Context.TeamCompetitions.ToList().LastOrDefault();
            if (lastTeam != null)
            {
                teamId = lastTeam.TeamId + 1;
            }
        }

        private void BtnAddMember_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddNewMemberWindow memberWindow = new Windows.AddNewMemberWindow(_competition, _event, teamId);
            memberWindow.Owner = MainWindow.GetWindow(this);
            memberWindow.ShowDialog();
            DgMember.ItemsSource = null;
            competitiorsList = null;
            foreach (var competitiors in AppData.Context.TeamCompetitions.ToList().Where(p => p.TeamId == teamId).ToList())
            {
                competitiorsList.Add(competitiors.Competitior);
            }
            DgMember.ItemsSource = competitiorsList;

        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            List<TeamCompetition> list = AppData.Context.TeamCompetitions.Where(p => p.TeamId == teamId).ToList();
            if (list.Count >= 2)
            {
                AppData.MainFrame.Navigate(new RegisterSuccessfulyTeamPage(teamId));
            }
            else
            {
                MessageBox.Show("The team must have at least 2 people", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cancel Action", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.MainFrame.GoBack();
            }
            if (AppData.Context.TeamCompetitions.Where(p => p.TeamId == teamId) != null)
            {
                AppData.Context.TeamCompetitions.RemoveRange(AppData.Context.TeamCompetitions.Where(p => p.TeamId == teamId));
                AppData.Context.SaveChanges();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            competitiorsList.Remove(AppData.Context.Competitiors.LastOrDefault());
            DgMember.ItemsSource = null;
            DgMember.ItemsSource = competitiorsList;
        }
    }
}
