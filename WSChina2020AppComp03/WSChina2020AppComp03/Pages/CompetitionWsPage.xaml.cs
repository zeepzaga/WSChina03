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
        public CompetitionWsPage()
        {
            InitializeComponent();
            try
            {
                TvICompetition.ItemsSource = AppData.Context.CategoryOfCompetitions.ToList();
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
            try
            {
            TblDescription.Text = (TvCompetition.SelectedItem as Competition).Description;
                Scroll.ScrollToTop();
            }
            catch
            {

            }
        }
    }
}
