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

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorMenuPage.xaml
    /// </summary>
    public partial class CoordinatorMenuPage : Page
    {
        public CoordinatorMenuPage()
        {
            InitializeComponent();
            DataContext = AppData.CurrentUser;
        }
        /// <summary>
        /// Обработчик клика на кнопку Volunteer Managment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVolonteer_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new VolunteerManagmentPage());
        }
        /// <summary>
        /// Обработчик клика на кнопку Sponsorship Managment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSponship_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new SponsorshipManagmentPage());

        }
        /// <summary>
        /// Обработчик клика на кнопку Competition Service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnComp_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CompetitionServicePage());
        }
    }
}
