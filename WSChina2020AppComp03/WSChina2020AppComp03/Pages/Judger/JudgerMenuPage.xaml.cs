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
    /// Логика взаимодействия для JudgerMenuPage.xaml
    /// </summary>
    public partial class JudgerMenuPage : Page
    {
        public JudgerMenuPage()
        {
            InitializeComponent();
            DataContext = AppData.CurrentUser;
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Be under development", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void BtnInput_Click(object sender, RoutedEventArgs e)
        {
            var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            bool isIdividual = AppData.Context.Competitions.ToList().FirstOrDefault(p => p.Id == judger.CompetitionId).IsIndividual;
            switch (isIdividual)
            {
                case true:
                    AppData.MainFrame.Navigate(new InputScorePage());
                    break;
                case false:
                    AppData.MainFrame.Navigate(new TeamInputScorePage());
                    break;
                default:
                    break;
            }
        }
        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            bool isIdividual = AppData.Context.Competitions.ToList().FirstOrDefault(p => p.Id == judger.CompetitionId).IsIndividual;
            switch (isIdividual)
            {
                case true:
                    AppData.MainFrame.Navigate(new DrawLotsPage());
                    break;
                case false:
                    AppData.MainFrame.Navigate(new TeamDrawLotsPage());
                    break;
                default:
                    break;
            }
        }
    }
}
