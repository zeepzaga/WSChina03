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

namespace WSChina2020AppComp03.Pages.Competitor
{

    /// <summary>
    /// Логика взаимодействия для MySkillsPage.xaml
    /// </summary>
    public partial class MySkillsPage : Page
    {
        public MySkillsPage()
        {
            InitializeComponent();
            var competitior = AppData.Context.Competitiors.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            ICCompetitionsLarge.ItemsSource = ICCompetitionsSmall.ItemsSource = AppData.Context.Competitiors.ToList().Where(p=>p.CompetitionId == competitior.CompetitionId);
            ICJudgerLarge.ItemsSource = ICJudgerSmall.ItemsSource = AppData.Context.Judgers.ToList().Where(p => p.CompetitionId == competitior.CompetitionId);
            SVLarge.Visibility = Visibility.Collapsed;
            SVLargeJudger.Visibility = Visibility.Collapsed;
            WorkshopLItem.DataContext = InfrastructureItem.DataContext = AppData.Context.Competitions.ToList().FirstOrDefault(p => p.Id == competitior.CompetitionId);
            foreach (var sessia in AppData.Context.Schedules.ToList().Where(p=>p.CompetitionId == competitior.CompetitionId))
            {
                TblockSchedule.Text += $"{sessia.Name}   {sessia.DateTimeStart.ToShortDateString()} {sessia.DateTimeStart.ToShortTimeString()}" +
                    $" — {sessia.DateTimeEnd.ToShortTimeString()}\n";
            }
        }

        private void MILargeIcon_Click(object sender, RoutedEventArgs e)
        {
            SVLarge.Visibility = Visibility.Visible;
            SVSmall.Visibility = Visibility.Collapsed;
        }

        private void MiSmallIcon_Click(object sender, RoutedEventArgs e)
        {
            SVLarge.Visibility = Visibility.Collapsed;
            SVSmall.Visibility = Visibility.Visible;
        }
        private void MiSmallIconJudger_Click(object sender, RoutedEventArgs e)
        {
            SVLargeJudger.Visibility = Visibility.Collapsed;
            SVSmallJudger.Visibility = Visibility.Visible;
        }
        private void MILargeIconJudger_Click(object sender, RoutedEventArgs e)
        {
            SVLargeJudger.Visibility = Visibility.Visible;
            SVSmallJudger.Visibility = Visibility.Collapsed;
        }
        
    }
}
