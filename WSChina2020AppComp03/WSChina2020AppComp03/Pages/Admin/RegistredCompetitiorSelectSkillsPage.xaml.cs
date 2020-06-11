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
    /// Interaction logic for RegistredCompetitiorSelectSkillsPage.xaml
    /// </summary>
    public partial class RegistredCompetitiorSelectSkillsPage : Page
    {
        List<Competition> competitionsList = new List<Competition>();
        EventCompetition @event;
        public RegistredCompetitiorSelectSkillsPage()
        {
            InitializeComponent();
            @event = AppData.Context.EventCompetitions.FirstOrDefault(p => p.DateStart > DateTime.Now);
            foreach (var competition in @event.Competitions)
            {
                competitionsList.Add(competition);
            }
            CbSkills.ItemsSource = competitionsList;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegisterCompetitiorIndividualSkillsPage(CbSkills.SelectedItem as Competition, @event));
        }
    }
}
