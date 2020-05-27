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

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Interaction logic for AdjustVolunteerPage.xaml
    /// </summary>
    public partial class AdjustVolunteerPage : Page
    {
        //лист хранящий кол-во волонтёров
        List<int> countList = new List<int>();

        //Листы для работы с таблицами
        List<Volunteer> NoLessVolList = new List<Volunteer>();
        List<Volunteer> LessVolList = new List<Volunteer>();
        List<Volunteer> NoLessCheckList = new List<Volunteer>();
        List<Volunteer> LessCheckList = new List<Volunteer>();

        // Булевы ппеременные для разных проверок
        bool IsChangeLess = false;
        bool IsChangeNoLess = false;
        bool IsSearchLess = false;
        bool IsSearchNoLess = false;

        double average = 0;
        public AdjustVolunteerPage()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        /// <summary>
        /// Метод для обновления ComboBox
        /// </summary>
        private void UpdateComboBox()
        {
            try
            {
                foreach (var item in AppData.Context.Competitions.ToList())
                {
                    countList.Add(item.CountVolunteer);
                }
                average = countList.Average();

                var skillsNoLessList = AppData.Context.Competitions.ToList().Where(i => i.CountVolunteer > average).ToList();
                CbCompetition1.ItemsSource = skillsNoLessList;

                var skillsLessList = AppData.Context.Competitions.ToList().Where(i => i.CountVolunteer < average).ToList();
                CbCompetition2.ItemsSource = skillsLessList;
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Метод для обновления всей информации
        /// </summary>
        private void Update()
        {
            try
            {
                if (LessCheckList.Count > 0 && IsChangeNoLess == true)
                {
                    foreach (var item in LessCheckList)
                    {
                        LessVolList.Remove(item);
                        item.Competition = CbCompetition1.SelectedItem as Competition;
                        NoLessVolList.Add(item);
                    }
                    LessCheckList.Clear();
                    BtnSave.IsEnabled = true;
                }
                else if (NoLessCheckList.Count > 0 && IsChangeLess == true)
                {
                    foreach (var item in NoLessCheckList)
                    {
                        NoLessVolList.Remove(item);
                        item.Competition = CbCompetition2.SelectedItem as Competition;
                        LessVolList.Add(item);
                    }
                    NoLessCheckList.Clear();
                    BtnSave.IsEnabled = true;
                }
                else
                {
                    LessCheckList.Clear();
                    NoLessCheckList.Clear();

                    if (CbCompetition1.SelectedIndex > -1)
                    {
                        IsSearchNoLess = true;
                        NoLessVolList = AppData.Context.Volunteers.ToList().Where
                            (i => i.Competition == CbCompetition1.SelectedItem as Competition).ToList();
                    }

                    if (CbCompetition2.SelectedIndex > -1)
                    {
                        IsSearchLess = true;
                        LessVolList = AppData.Context.Volunteers.ToList().Where
                                (i => i.Competition == CbCompetition2.SelectedItem as Competition).ToList();
                    }
                }

                DgVolunteers2.ItemsSource = LessVolList;
                DgVolunteers1.ItemsSource = NoLessVolList;
                DgVolunteers2.Items.Refresh();
                DgVolunteers1.Items.Refresh();
                TbTotal2.Text = $"Total Volunteers: {DgVolunteers2.Items.Count}";
                TbTotal1.Text = $"Total Volunteers: {DgVolunteers1.Items.Count}";
            }
            catch
            {
                MessageBox.Show("Data Base Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Метод для перемещения из левой таблицы в правую
        /// </summary>
        private void BtnToRight_Click(object sender, RoutedEventArgs e)
        {
            if (NoLessCheckList.Count == 0)
                MessageBox.Show("Select the volunteers in the table with no less than average volunteers number!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (IsSearchLess == false || IsSearchNoLess == false)
                MessageBox.Show("Update or upload table with less than average volunteers number!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                IsChangeLess = true;
                Update();
            }
        }
        /// <summary>
        /// Метод для перемещения из правой таблицы в левую
        /// </summary>
        private void BtnToLeft_Click(object sender, RoutedEventArgs e)
        {
            if (LessCheckList.Count == 0)
                MessageBox.Show("Select the volunteers in the table with less than average volunteers number!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (IsSearchNoLess == false || IsSearchLess == false)
                MessageBox.Show("Update or upload table with no less than average volunteers number!",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                IsChangeNoLess = true;
                Update();
            }
        }
        /// <summary>
        /// Метод для поиска в левой таблице
        /// </summary>
        private void BtnSearch1_Click(object sender, RoutedEventArgs e)
        {
            if (NoLessCheckList.Count > 0 || LessCheckList.Count > 0
                || BtnSave.IsEnabled == true)
            {
                    Update();
            }
            else if (CbCompetition1.SelectedIndex == -1)
                MessageBox.Show("Select skill!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                Update();
        }
        /// <summary>
        /// Метод для поиска в правой таблице
        /// </summary>
        private void BtnSearch2_Click(object sender, RoutedEventArgs e)
        {
            if (NoLessCheckList.Count > 0 || LessCheckList.Count > 0
                    || BtnSave.IsEnabled == true)
            {
                    Update();
            }
            else if (CbCompetition2.SelectedIndex == -1)
                MessageBox.Show("Select skill!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                Update();
        }
        /// <summary>
        /// Метод для сохранения информации 
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.SaveChanges();

            MessageBox.Show("Changes saved!", "Successful", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            UpdateComboBox();
            BtnSave.IsEnabled = false;
            DgVolunteers2.ItemsSource = null;
            DgVolunteers1.ItemsSource = null;
            CbCompetition2.SelectedIndex = -1;
            CbCompetition1.SelectedIndex = -1;
            NoLessVolList = null;
            LessVolList = null;
        }
        /// <summary>
        /// Обработка выбора волонтёра из левой таблциы
        /// </summary>
        private void ChB1_Click(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;
            if (check.IsChecked == true)
                NoLessCheckList.Add(DgVolunteers1.SelectedItem as Volunteer);
            else
                NoLessCheckList.Remove(DgVolunteers1.SelectedItem as Volunteer);
        }
        /// <summary>
        /// Обработка выбора волонтёра из правой таблциы
        /// </summary>
        private void ChB2_Click(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;
            if (check.IsChecked == true)
                LessCheckList.Add(DgVolunteers2.SelectedItem as Volunteer);
            else
                LessCheckList.Remove(DgVolunteers2.SelectedItem as Volunteer);
        }
        /// <summary>
        ///  Изменение переменной отвечающей за информации нажата ли кнопка поиск у левой таблицы
        /// </summary>
        private void CbCompetition1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsSearchNoLess = false;
        }
        /// <summary>
        ///  Изменение переменной отвечающей за информации нажата ли кнопка поиск у правой таблицы
        /// </summary>
        private void CbCompetition2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsSearchLess = false;
        }
    }
}
