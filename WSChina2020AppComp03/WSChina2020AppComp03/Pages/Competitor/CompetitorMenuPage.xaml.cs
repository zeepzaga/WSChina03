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
    /// Логика взаимодействия для CompetitorMenuPage.xaml
    /// </summary>
    public partial class CompetitorMenuPage : Page
    {
        public CompetitorMenuPage()
        {
            InitializeComponent();
            DataContext = AppData.CurrentUser;
        }
        /// <summary>
        /// Обработчик кнопки "My Profile"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Be under development", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Обработчик кнопки "My Skills"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSkills_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Be under development", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        /// <summary>
        /// Обработчик кнопки "My Results"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Be under development", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
