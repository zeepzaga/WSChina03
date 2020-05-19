using Microsoft.Win32;
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
using System.Windows.Threading;
using WSChina2020AppComp03.Entities;
using WSChina2020AppComp03.Pages;

namespace WSChina2020AppComp03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new MainScreenPage());
        }
        /// <summary>
        /// Во время тика таймера происходит обновление нижней строчки
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            var dateTimer = new DateTime(2021, 08, 22, 00, 00, 00) - DateTime.Now;
            TblTimer.Text = $"{dateTimer.Days} days, {dateTimer.Hours} hours, {dateTimer.Minutes} minutes and {dateTimer.Seconds} seconds until the WorldSkillsShanghai 2021 starts.";
        }
        /// <summary>
        /// Метод позволяющий отслеживать изменения контента на Frame
        /// </summary>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var title = (AppData.MainFrame.Content as Page).Title;
            if (title == "MainScreenPage" || title == "AboutShanghaiPage")
            {
                MainGrid.RowDefinitions[0].Height = new GridLength(0);
            }
            else
            {
                MainGrid.RowDefinitions[0].Height = GridLength.Auto;
            }
            if (AppData.CurrentUser == null)
            {
                BtnLogout.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnLogout.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Обработка нажатия на кнопку "Back"
        /// </summary>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

            var title = (AppData.MainFrame.Content as Page).Title;
            switch (title)
            {
                case "AdministratorMenuPage":
                case "CompetitorMenuPage":
                case "CoordinatorMenuPage":
                case "JudgerMenuPage.xaml":
                    BtnLogout_Click(null, null);
                    break;
                default:
                    if (AppData.MainFrame.CanGoBack)
                    {
                        AppData.MainFrame.GoBack();
                    }
                    break;
            }
        }
        /// <summary>
        /// Обработка клика на кнопку "Logout"
        /// </summary>
        private void BtnLogout_Click(object sender, RoutedEventArgs e) 
        {
            if (MessageBox.Show("Do you really want to get out?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.CurrentUser = null;
                Properties.Settings.Default.Password = null;
                Properties.Settings.Default.UserId = null;
                AppData.MainFrame.Navigate(new MainScreenPage());
            }
        }
    }
}
