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

        private void BtnAboutWs_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AboutWorldskillsPage());
        }

        private void BtnAboutShangHai_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AboutShanghaiPage());
        }

        private void BtnAboutWsChina_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This page is under construction", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This page is under construction", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
