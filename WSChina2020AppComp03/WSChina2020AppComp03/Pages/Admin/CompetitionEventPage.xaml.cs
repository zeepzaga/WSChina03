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
            BtnRegistration.IsEnabled = false;
            BtnEdit.IsEnabled = false;
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
        /// <summary>
        /// Обработка нажатия на кнопку Edit
        /// </summary>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The functionality is being developed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        /// <summary>
        /// Обработка нажатия на кнопку View Registration
        /// </summary>
        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ViewRegistrationPage(@event));
        }
        /// <summary>
        /// Обработка нажатия на кнопку +Add an Event
        /// </summary>
        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The functionality is being developed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Обработка ввода текста в TextBox
        /// </summary>
        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDataGrid();
        }
        /// <summary>
        /// Обработка смены выбора внутри DataGrid
        /// </summary>
        private void DgEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((DgEvent.SelectedItem as EventCompetition).DateStart > DateTime.Now) BtnEdit.IsEnabled = true;
            else BtnEdit.IsEnabled = false;
            @event = DgEvent.SelectedItem as EventCompetition;
            BtnRegistration.IsEnabled = true;
        }
        /// <summary>
        /// Метод позволяющий обновлять DataGrid
        /// </summary>
        private void UpdateDataGrid()
        {
            DgEvent.ItemsSource = eventCompetitionsList.Where(p => p.YearCountryTown.Contains(TbSearch.Text));
        }
    }
}
