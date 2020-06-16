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
    /// Interaction logic for RegisterSuccessfulyTeamPage.xaml
    /// </summary>
    public partial class RegisterSuccessfulyTeamPage : Page
    {
        int _teamId;
        List<Competitior> competitiorsList = new List<Competitior>();
        public RegisterSuccessfulyTeamPage(int teamId)
        {
            InitializeComponent();
            _teamId = teamId;
            foreach (var competitior in AppData.Context.TeamCompetitions.ToList().Where(p=>p.TeamId==teamId))
            {
                competitiorsList.Add(competitior.Competitior);
            }
            ICCompetitiors.ItemsSource = competitiorsList;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new PrintCompetitiorCardTeamPage(_teamId));
        }

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Retur?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.MainFrame.Navigate(new AdministratorMenuPage());
            }
        }
    }
}
