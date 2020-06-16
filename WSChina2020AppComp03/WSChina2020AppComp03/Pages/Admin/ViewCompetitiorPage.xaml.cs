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
    /// Interaction logic for ViewCompetitiorPage.xaml
    /// </summary>
    public partial class ViewCompetitiorPage : Page
    {
        List<Competitior> competitionsList = new List<Competitior>();
        List<Competitior> competitionsListBufer = new List<Competitior>();
        List<EventCompetition> EventCompetitionList = new List<EventCompetition>();
        List<Competition> CompetitionList = new List<Competition>();
        List<Gender> GenderList = new List<Gender>();
        List<Town> townList = new List<Town>();
        public ViewCompetitiorPage()
        {
            InitializeComponent();
            try
            {
                EventCompetitionList = AppData.Context.EventCompetitions.ToList();
                CompetitionList = AppData.Context.Competitions.ToList();
                GenderList = AppData.Context.Genders.ToList();
                townList = AppData.Context.Towns.ToList();
                competitionsList = AppData.Context.Competitiors.ToList();
                EventCompetitionList.Insert(0, new EventCompetition
                {
                    YearCountryTown = "All Events"
                });
                CompetitionList.Insert(0, new Competition
                {
                    FullCompetition = "All Competitoins"
                });
                GenderList.Insert(0, new Gender
                {
                    Name = "All Genders"
                });
                townList.Insert(0, new Town
                {
                    Name = "All Towns"
                });
                CbEvent.ItemsSource = EventCompetitionList;
                CbGender.ItemsSource = GenderList;
                CbProvince.ItemsSource = townList;
                CbSkill.ItemsSource = CompetitionList;
                CbEvent.SelectedIndex =
                    CbGender.SelectedIndex =
                    CbProvince.SelectedIndex =
                    CbSkill.SelectedIndex = 0;

            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            competitionsListBufer = competitionsList;
            DgCompetitiors.Visibility = Visibility.Visible;
            TblNoData.Visibility = Visibility.Collapsed;
            if (CbEvent.SelectedIndex > 0)
                competitionsListBufer = competitionsListBufer.ToList().
                    Where(p => p.EventCompetition == CbEvent.SelectedItem as EventCompetition).ToList();
            if (CbGender.SelectedIndex > 0)
                competitionsListBufer = competitionsListBufer.ToList().
                    Where(p => p.User.Gender == CbGender.SelectedItem as Gender).ToList();
            if (CbProvince.SelectedIndex > 0)
                competitionsListBufer = competitionsListBufer.ToList().
                    Where(p => p.User.Town == CbProvince.SelectedItem as Town).ToList();
            if (CbSkill.SelectedIndex > 0)
                competitionsListBufer = competitionsListBufer.ToList().
                    Where(p => p.Competition == CbSkill.SelectedItem as Competition).ToList();
            DgCompetitiors.ItemsSource = null;
            if (!String.IsNullOrWhiteSpace(TbIdNumber.Text))
                competitionsListBufer = competitionsListBufer.ToList().Where(p => p.UserId == TbIdNumber.Text).ToList();
            DgCompetitiors.ItemsSource = competitionsListBufer.ToList().Where(p => p.FullName.Contains(TbName.Text));
            if(competitionsListBufer.Count==0)
            {
                DgCompetitiors.Visibility = Visibility.Collapsed;
                TblNoData.Visibility = Visibility.Visible;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The feature would be future add-on to the current system.","Edit Competitior — Future Add-on",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void DgCompetitiors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((DgCompetitiors.SelectedItem as Competitior).EventCompetition.DateStart > DateTime.Now)
            {
                BtnEdit.IsEnabled = true;
            }
            else
            {
                BtnEdit.IsEnabled = false;
            }
        }
    }
}
