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
using System.Windows.Shapes;
using WSChina2020AppComp03.Entities;

namespace WSChina2020AppComp03.Windows
{
    /// <summary>
    /// Interaction logic for AddNewMemberWindow.xaml
    /// </summary>
    public partial class AddNewMemberWindow : Window
    {
        List<User> usersList = new List<User>();
        List<Competitior> competitiorsList = new List<Competitior>();
        Competition _competition;
        int genderId = 0;
        byte[] photo = null;
        EventCompetition _event;
        public AddNewMemberWindow(Competition competition, EventCompetition @event)
        {
            InitializeComponent();
            int i = 1;
            string competitiorRegNumber = "";
            string competitionNumber = "";
            try
            {
                usersList = AppData.Context.Users.Where(p => p.RoleId == 1).ToList();
                competitiorsList = AppData.Context.Competitiors.ToList();
                CbProvince.ItemsSource = AppData.Context.Towns.ToList();
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            foreach (var item in competitiorsList.Where(p => p.EventCompetitionId == @event.Id && p.CompetitionId == competition.Id))
            {
                i++;
            }
            if (i.ToString().Length < 2)
                competitiorRegNumber = $"0{i}";
            else
                competitiorRegNumber = $"{i}";
            if (competition.Id.ToString().Length < 2)
                competitionNumber = $"0{competition.Id}";
            else
                competitionNumber = $"{competition.Id}";
            TbCompetitorNumber.Text = $"{@event.DateStart.Year}{competitionNumber}{competitiorRegNumber}";
            _competition = competition;
            _event = @event;
        }

        private void TbIdNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TblClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void BtnSumbit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
