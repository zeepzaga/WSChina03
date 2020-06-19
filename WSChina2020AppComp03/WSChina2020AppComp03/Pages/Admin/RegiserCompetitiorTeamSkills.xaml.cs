using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSChina2020AppComp03.Entities;

namespace WSChina2020AppComp03.Pages.Admin
{
    public class CompetitiorGrid
    {
        public string CompetitiorNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string IdNumber { get; set; }
    }
    /// <summary>
    /// Interaction logic for RegiserCompetitiorTeamSkills.xaml
    /// </summary>
    public partial class RegiserCompetitiorTeamSkills : Page
    {
        Competition _competition;
        EventCompetition _event;
        List<User> usersList = new List<User>();
        List<Competitior> competitiorsList = new List<Competitior>();
        List<CompetitiorGrid> competitiorGridList = new List<CompetitiorGrid>();
        int teamId = 1;
        int genderId = 0;
        byte[] photo = null;
        public RegiserCompetitiorTeamSkills(Competition competition, EventCompetition @event)
        {
            InitializeComponent();
            try
            {
                usersList = AppData.Context.Users.Where(p => p.RoleId == 1).ToList();
                competitiorsList = AppData.Context.Competitiors.ToList();
                CbProvince.ItemsSource = AppData.Context.Towns.ToList();
                TeamCompetition lastTeam = AppData.Context.TeamCompetitions.ToList().LastOrDefault();
                if (lastTeam != null)
                {
                    teamId = lastTeam.TeamId + 1;
                }
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            _competition = competition;
            _event = @event;
            TblEvent.Text = @event.YearCountryTown;
            TblSkills.Text = competition.FullCompetition;
        }

        private void BtnAddMember_Click(object sender, RoutedEventArgs e)
        {
            StackPanelMain.Visibility = Visibility.Collapsed;
            TblEvent.Text = _event.YearCountryTown;
            TblSkills.Text = _competition.FullCompetition;
            int i = 1;
            string competitiorRegNumber = "";
            string competitionNumber = "";
            try
            {
                competitiorsList = AppData.Context.Competitiors.ToList();
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            foreach (var item in competitiorsList.Where(p => p.EventCompetitionId == _event.Id && p.CompetitionId == _competition.Id))
            {
                i++;
            }
            if (i.ToString().Length < 2)
                competitiorRegNumber = $"0{i}";
            else
                competitiorRegNumber = $"{i}";
            if (_competition.Id.ToString().Length < 2)
                competitionNumber = $"0{_competition.Id}";
            else
                competitionNumber = $"{_competition.Id}";
            TbCompetitorNumber.Text = $"{_event.DateStart.Year}{competitionNumber}{competitiorRegNumber}";
            BorderAddMember.Visibility = Visibility.Visible;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            List<TeamCompetition> list = AppData.Context.TeamCompetitions.Where(p => p.TeamId == teamId).ToList();
            if (list.Count >= 2)
            {
                AppData.MainFrame.Navigate(new RegisterSuccessfulyTeamPage(teamId));
            }
            else
            {
                MessageBox.Show("The team must have at least 2 people", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cancel Action", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.MainFrame.GoBack();
            }
            if (AppData.Context.TeamCompetitions.Where(p => p.TeamId == teamId) != null)
            {
                AppData.Context.TeamCompetitions.RemoveRange(AppData.Context.TeamCompetitions.Where(p => p.TeamId == teamId));
                AppData.Context.SaveChanges();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            competitiorGridList.Remove((sender as Button).DataContext as CompetitiorGrid);
            AppData.Context.TeamCompetitions.Remove(AppData.Context.TeamCompetitions.ToList().
                FirstOrDefault(p => p.CompetitorId == ((sender as Button).DataContext as CompetitiorGrid).CompetitiorNumber));
            AppData.Context.Competitiors.Remove(AppData.Context.Competitiors.ToList().
             FirstOrDefault(p => p.Id == ((sender as Button).DataContext as CompetitiorGrid).CompetitiorNumber));
            AppData.Context.Users.Remove(AppData.Context.Users.ToList().
            FirstOrDefault(p => p.Id == ((sender as Button).DataContext as CompetitiorGrid).IdNumber));
            AppData.Context.SaveChanges();
            DgMember.ItemsSource = null;
            DgMember.ItemsSource = competitiorGridList;
        }

        private void TbIdNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TbIdNumber.Text.Length == 18)
            {

                var user = usersList.FirstOrDefault(p => p.Id.ToString() == TbIdNumber.Text);
                var competitior = competitiorsList.FirstOrDefault(p => p.User == user);
                if (competitior != null)
                {
                    MessageBox.Show("A user with this Id is already registered as a member", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    BtnRegister.IsEnabled = false;
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
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "Image Files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                photo = File.ReadAllBytes(openFileDialog.FileName);
                ImgPgoto.DataContext = photo;
            }
        }

        private void TblClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BorderAddMember.Visibility = Visibility.Collapsed;
            StackPanelMain.Visibility = Visibility.Visible;
        }

        private void BtnSumbit_Click(object sender, RoutedEventArgs e)
        {
            if (TbIdNumber.Text.Length != 18)
            {
                MessageBox.Show("Not Correct IdNumber", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
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
                        string patronymic = TbName.Text.Replace($"{name} {lastName}", "");
                        string trst = TbIdNumber.Text;
                        AppData.Context.Users.Add(user = new User
                        {
                            Id = TbIdNumber.Text,
                            Password = TbIdNumber.Text.Substring(14, 4),
                            Name = name,
                            LastName = lastName,
                            Patronymic = patronymic,
                            GenderId = genderId,
                            Photo = photo == null ? null : photo,
                            Email = TbEmail.Text,
                            DateOfBirth = DateTime.ParseExact(TblBirh.Text, "yyyy-mm-dd", null),
                            Phone = TbPhone.Text,
                            Organization = TbOrganization.Text,
                            ContactAddress = TbAddress.Text,
                            TownId = (CbProvince.SelectedItem as Town).Id,
                            RoleId = 1
                        });
                        AppData.Context.SaveChanges();
                        Competitior competitior;
                        AppData.Context.Competitiors.Add(competitior = new Competitior
                        {
                            Id = TbCompetitorNumber.Text,
                            CompetitionId = _competition.Id,
                            EventCompetitionId = _event.Id,
                            UserId = user.Id
                        });
                        AppData.Context.SaveChanges();
                        AppData.Context.TeamCompetitions.Add(new TeamCompetition
                        {
                            CompetitionId = _competition.Id,
                            CompetitorId = competitior.Id,
                            TeamId = teamId,
                            EventCompetitionId = _event.Id
                        });
                        AppData.Context.SaveChanges();
                        MessageBox.Show("All done", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                        competitiorGridList.Add(new CompetitiorGrid
                        {
                            CompetitiorNumber = TbCompetitorNumber.Text,
                            Gender = TblGender.Text,
                            IdNumber = TbIdNumber.Text,
                            Name = TbName.Text,
                            Province = CbProvince.Text
                        });
                        DgMember.ItemsSource = competitiorGridList;
                        BorderAddMember.Visibility = Visibility.Collapsed;
                        StackPanelMain.Visibility = Visibility.Visible;
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
}
