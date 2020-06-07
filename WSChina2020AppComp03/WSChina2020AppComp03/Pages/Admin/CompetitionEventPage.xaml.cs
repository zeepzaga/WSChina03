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
    /// Interaction logic for CompetitionEventPage.xaml
    /// </summary>
    public partial class CompetitionEventPage : Page
    {
        private EventCompetition @event;
        List<EventCompetition> eventCompetitionsList = new List<EventCompetition>();
        public CompetitionEventPage()
        {
            InitializeComponent();
            try
            {
                eventCompetitionsList = AppData.Context.EventCompetitions.ToList();
            }
            catch
            {
                MessageBox.Show("Data Base Connection Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateDataGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ViewRegistrationPage(@event));
        }

        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void DgEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DgEvent.SelectedItem as EventCompetition).DateStart > DateTime.Now) BtnEdit.IsEnabled = true;
            else BtnEdit.IsEnabled = false;
            @event = DgEvent.SelectedItem as EventCompetition;
        }

        private void UpdateDataGrid()
        {
            DgEvent.ItemsSource = eventCompetitionsList.Where(p => p.YearCountryTown.Contains(TbSearch.Text));
        }
    }
}
