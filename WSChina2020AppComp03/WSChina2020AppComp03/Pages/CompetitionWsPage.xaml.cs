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

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для CompetitionWsPage.xaml
    /// </summary>
    public partial class CompetitionWsPage : Page
    {
       private List<CategoryOfCompetition> _competitions = AppData.Context.CategoryOfCompetitions.ToList();
        public CompetitionWsPage()
        {
            InitializeComponent();
            try
            {
                TvICompetition.ItemsSource = _competitions;
            }
            catch
            {
                MessageBox.Show("Connecting to the database error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Метод отслеживающий смену выбранного элемента TreeView
        /// </summary>
        private void TvCompetition_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TblDescription.Text = "";
            try
            {
                Competition competition = (TvCompetition.SelectedItem as Competition);
                TblDescription.Text = $"{competition.Id}. {competition.Name}\n\n" +
                    $"{competition.Description}";
                Scroll.ScrollToTop();
            }
            catch
            {
                try
                {
                    foreach (var competition in (TvCompetition.SelectedItem as CategoryOfCompetition).Competitions)
                    {
                        TblDescription.Text += $"{competition.Id}. {competition.Name}\n\n" +
                            $"{competition.Description}\n\n";
                    }
                }
                catch
                {
                    foreach (var item in _competitions)
                    {
                        foreach (var competition in item.Competitions)
                        {
                            TblDescription.Text += $"{competition.Id}. {competition.Name}\n\n" +
                           $"{competition.Description}\n\n";
                        }
                    }
                }
            }
        }
    }
}
