﻿using System;
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
    /// Interaction logic for EventManagmentPage.xaml
    /// </summary>
    public partial class EventManagmentPage : Page
    {
        public EventManagmentPage()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Обработка нажатия на кнопку Competition Event
        /// </summary>
        private void BtnEvent_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CompetitionEventPage());
        }
        /// <summary>
        ///  Обработка нажатия на кнопку Competiton Skills
        /// </summary>
        private void BtnComp_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new CompetitionSkillsPage(null));
        }
    }
}
