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
    /// Interaction logic for CompetitorManagmentPage.xaml
    /// </summary>
    public partial class CompetitorManagmentPage : Page
    {
        public CompetitorManagmentPage()
        {
            InitializeComponent();
        }

        private void BtnRegCompetitior_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegistredCompetitiorSelectSkillsPage());
        }

        private void BtnViewCompetitior_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}