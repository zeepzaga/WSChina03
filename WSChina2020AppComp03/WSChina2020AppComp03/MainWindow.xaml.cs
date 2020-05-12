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
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new MainScreenPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var title = (AppData.MainFrame.Content as Page).Title;
            if (title == "MainScreenPage")
            {
                MainGrid.RowDefinitions[0].Height = new GridLength(0);
            }
        }
    }
}
