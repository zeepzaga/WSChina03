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
    /// Логика взаимодействия для AdministratorMenuPage.xaml
    /// </summary>
    public partial class AdministratorMenuPage : Page
    {
        public AdministratorMenuPage()
        {
            InitializeComponent();
            DataContext = AppData.CurrentUser;
        }
        /// <summary>
        /// Обработчик клика кнопки "Event Managmen"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Be under development", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Обработчик клика кнопки "Competitor Managment"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnComp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Be under development", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
