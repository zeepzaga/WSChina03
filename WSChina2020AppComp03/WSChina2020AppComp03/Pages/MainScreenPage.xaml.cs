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
    /// Логика взаимодействия для MainScreenPage.xaml
    /// </summary>
    public partial class MainScreenPage : Page
    {
        public MainScreenPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработка нажатия на кнопку "About World Skills"
        /// </summary>
        private void BtnAboutWs_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AboutWorldskillsPage());
        }
        /// <summary>
        /// Обработка нажатия на кнопку "About Shang Hai"
        /// </summary>
        private void BtnAboutShangHai_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AboutShanghaiPage());
        }
        /// <summary>
        /// Обработка нажатия на кнопку "About World Skills China"
        /// </summary>
        private void BtnAboutWsChina_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AboutWsChinaPage());
        }
        /// <summary>
        /// Обработка нажатия на кнопку "Login"
        /// </summary>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new LoginScreenPage());
        }
    }
}
