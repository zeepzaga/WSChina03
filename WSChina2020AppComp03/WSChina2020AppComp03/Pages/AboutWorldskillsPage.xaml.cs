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

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutWorldskillsPage.xaml
    /// </summary>
    public partial class AboutWorldskillsPage : Page
    {
        public AboutWorldskillsPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработка нажатия на кнопку "History of Worldskills"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHistoryWs_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new HistoryOfWsPage());
        }
        /// <summary>
        /// Обработка нажатия на кнопку "Competition Skills"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCompetition_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CompetitionWsPage());
        }
        /// <summary>
        /// Обработка нажатия на кнопку "Previous Competitions"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrCom_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This page is under construction", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
