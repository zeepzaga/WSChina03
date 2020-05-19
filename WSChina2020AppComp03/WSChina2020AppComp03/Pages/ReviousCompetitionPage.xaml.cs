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
    /// Логика взаимодействия для ReviousCompetitionPage.xaml
    /// </summary>
    public partial class ReviousCompetitionPage : Page
    {
        private List<EventCompetition> _previousCompList = new List<EventCompetition>();
        private List<TownAndCountry> _TownList = new List<TownAndCountry>();
        public ReviousCompetitionPage()
        {
            InitializeComponent();
            try
            {
                _previousCompList = AppData.Context.EventCompetitions.ToList();
                foreach (var town in AppData.Context.Towns.ToList())
                {
                    _TownList.Add(new TownAndCountry
                    {
                        Name = town.Name
                    });
                }
                foreach (var country in AppData.Context.Countries.ToList())
                {
                    _TownList.Add(new TownAndCountry
                    {
                        Name = country.Name
                    });
                }
            }
            catch
            {
                MessageBox.Show("Connecting to the database error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DgComp.ItemsSource = _previousCompList;
            CbOrdinal.ItemsSource = _previousCompList;
            CbCity.ItemsSource = _TownList;
        }

        private class TownAndCountry
        {
            public string Name { get; set; }
        }
        /// <summary>
        /// Обработка ввода текста в комбобокса для поиска.
        /// </summary>
        private void CbOrdinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            CbOrdinal.ItemsSource = _previousCompList.Where(p => p.Ordinal.Contains(CbOrdinal.Text.ToLower())).ToList();
            CbOrdinal.IsDropDownOpen = true;
        }

        /// <summary>
        /// Обработка ввода текста в комбобокса для поиска.
        /// </summary>
        private void CbCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            CbCity.ItemsSource = _TownList.ToList().Where(p => p.Name.ToLower().Contains(CbCity.Text.ToLower())).ToList();
            CbCity.IsDropDownOpen = true;
        }

        /// <summary>
        /// Кнопка применяющая параметры поиска
        /// </summary>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(CbOrdinal.Text))
            {
                DgComp.ItemsSource = null;
                DgComp.ItemsSource = _previousCompList.Where(p => p.TownPartial.ToLower().Contains(CbCity.Text.ToLower())).ToList();
            }
            else
            {
                DgComp.ItemsSource = null;
                DgComp.ItemsSource = _previousCompList.Where(p => p.Ordinal.ToLower().Contains(CbOrdinal.Text.ToLower()) && p.TownPartial.ToLower().Contains(CbCity.Text)).ToList();
            }
        }
        /// <summary>
        /// Метод, который позволяет убрать выделение первого символа
        /// </summary>
        private void CbOrdinal_SelectionChanged(object sender, RoutedEventArgs e)
        {
            CbOrdinal.SelectedIndex = -1;
            CbOrdinal.SelectedIndex = -1;
            var text = (TextBox)e.OriginalSource;
            if (text.SelectionLength != 0 && text.Text.Length == 1)
            {
                text.SelectionStart = text.Text.Length;
            }
        }
        /// <summary>
        /// Метод, который позволяет убрать выделение первого символа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCity_SelectionChanged(object sender, RoutedEventArgs e)
        {
            CbCity.SelectedIndex = -1;
            CbCity.SelectedIndex = -1;
            var text = (TextBox)e.OriginalSource;
            if (text.SelectionLength != 0 && text.Text.Length == 1)
            {
                text.SelectionStart = text.Text.Length;
            }
        }
    }
}
