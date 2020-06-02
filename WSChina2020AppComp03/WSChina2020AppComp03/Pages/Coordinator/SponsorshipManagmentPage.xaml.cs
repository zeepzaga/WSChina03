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
    /// Interaction logic for SponsorshipManagmentPage.xaml
    /// </summary>
    public partial class SponsorshipManagmentPage : Page
    {
        public SponsorshipManagmentPage()
        {
            InitializeComponent();
        }

        private void BtnStatistics_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new SponsorshipStatisticsPage());
        }

        private void BtnChart_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new SponsorshipCahrtPage());
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new SponsorshipViewPage());
        }
    }
}
