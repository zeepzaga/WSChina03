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
            ICCompetitionsLarge.ItemsSource = ICCompetitionsSmall.ItemsSource = AppData.Context.Competitiors.ToList();
            SVLarge.Visibility = Visibility.Collapsed;
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

       
    }
}
