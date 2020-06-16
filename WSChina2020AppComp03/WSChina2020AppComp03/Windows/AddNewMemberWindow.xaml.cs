using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int _teamId;
        EventCompetition _event;
        public AddNewMemberWindow(Competition competition, EventCompetition @event, int teamId)
        {
            _teamId = teamId;
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
            BtnSumbit.IsEnabled = true;
            if (TbIdNumber.Text.Length == 18)
            {

                var user = usersList.FirstOrDefault(p => p.Id.ToString() == TbIdNumber.Text);
                var competitior = competitiorsList.FirstOrDefault(p => p.User == user);
                if (competitior != null)
                {
                    MessageBox.Show("A user with this Id is already registered as a member", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    BtnSumbit.IsEnabled = false;
                }
                else if (user != null)
                {
                    TbName.Text = $"{user.Name} {user.LastName} {user.Patronymic}";
                    TblGender.Text = $"{user.Gender.Name}";
                    TbOrganization.Text = $"{user.Organization}";
                    TbAddress.Text = $"{user.ContactAddress}";
                    TbEmail.Text = $"{user.Email}";
                    TbPhone.Text = $"{user.Phone}";
                    TblBirh.Text = $"{user.DateOfBirth}";
                    ImgPgoto.DataContext = user.Photo;
                    CbProvince.SelectedItem = user.Town;
                }
                else
                {
                    try
                    {
                        string year = "";
                        string month = "";
                        string day = "";
                        if (double.Parse(TbIdNumber.Text.Substring(16, 1)) % 2 == 0)
                        {
                            TblGender.Text = "Female";
                            genderId = 2;
                        }
                        else
                        {
                            genderId = 1;
                            TblGender.Text = "Male";
                        }
                        year = TbIdNumber.Text.Substring(6, 4);
                        month = TbIdNumber.Text.Substring(10, 2);
                        day = TbIdNumber.Text.Substring(12, 2);
                        TblBirh.Text = $"{year}-{month}-{day}";
                    }
                    catch
                    {

                    }
                }
            }
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
            string error = "";
            String[] words = TbName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Count() == 0) error += "• Not Correct Name\n";
            if (String.IsNullOrWhiteSpace(TbIdNumber.Text)) error += "• Not Correct IdNUmber\n";
            if (String.IsNullOrWhiteSpace(TbName.Text)) error += "• Not Correct Name\n";
            if (CbProvince.SelectedIndex < 0) error += "• Not Correct Province\n";
            if (String.IsNullOrWhiteSpace(TbPhone.Text)) error += "• Not Correct Phone\n";
            if (String.IsNullOrWhiteSpace(TbOrganization.Text)) error += "• Not Correct Organization\n";
            if (String.IsNullOrWhiteSpace(TbOrganization.Text)) error += "• Not Correct Organization\n";
            if (!(Regex.IsMatch(TbEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{1,4}$"))) error += "• Not Correct Email\n";
            if (String.IsNullOrWhiteSpace(error))
            {
                try
                {
                    User user = null;
                    string name = words[0];
                    string lastName = words[1];
                    string patronymic = TbName.Text.Replace($"{Name} {lastName}", "");
                    AppData.Context.Users.Add(user = new User
                    {
                        Id = TbIdNumber.Text,
                        Password = TbIdNumber.Text.Substring(13, 4),
                        Name = name,
                        LastName = lastName,
                        Patronymic = patronymic,
                        GenderId = genderId,
                        Photo = photo == null ? null : photo,
                        Email = TbEmail.Text,
                        DateOfBirth = DateTime.ParseExact(TblBirh.Text.Substring(6, 8), "yyyyMdd", null),
                        Phone = TbPhone.Text,
                        Organization = TbOrganization.Text,
                        ContactAddress = TbAddress.Text,
                        TownId = (CbProvince.SelectedItem as Town).Id,
                        RoleId = 1
                    });
                    AppData.Context.SaveChanges();
                    Competitior competitor;
                    AppData.Context.Competitiors.Add(competitor = new Competitior
                    {
                        Id = TbCompetitorNumber.Text,
                        CompetitionId = _competition.Id,
                        EventCompetitionId = _event.Id,
                        TownId = (CbProvince.SelectedItem as Town).Id,
                        UserId = user.Id
                    });
                    AppData.Context.SaveChanges();
                    AppData.Context.TeamCompetitions.Add(new TeamCompetition
                    {
                        CompetitionId = _competition.Id,
                        CompetitorId = competitor.Id,
                        TeamId = _teamId,
                    });
                    AppData.Context.SaveChanges();
                    MessageBox.Show("All done", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Unknown Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
