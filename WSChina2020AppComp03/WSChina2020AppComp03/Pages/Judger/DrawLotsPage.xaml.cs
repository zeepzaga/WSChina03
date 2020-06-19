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

namespace WSChina2020AppComp03.Pages.Judger
{
    /// <summary>
    /// Interaction logic for DrawLotsPage.xaml
    /// </summary>
    public partial class DrawLotsPage : Page
    {
        List<int> stationNumbersList = new List<int>();
        public DrawLotsPage()
        {
            InitializeComponent();
            try
            {
                // Получаем эксперта, который выполнил вход
                var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id); 
                TblEvent.Text = $"{judger.EventCompetition.YearCountryTown}";
                TblSkill.Text = $"{judger.Competition.FullCompetition}";
                if (judger.IsMain == false) //Если эксперт не главный
                {
                    MessageBox.Show("To perform the draw you must be the main expert", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    BtnDrawLots.IsEnabled = false; // то
                }
                DgCompetitiors.ItemsSource = AppData.Context.Competitiors.ToList().Where(p => p.EventCompetitionId == judger.EventCompetitionId && p.CompetitionId == judger.CompetitionId).ToList();
                // Заполнение листа с порядковыми норерами
                for (int i = 1; i <=
                    AppData.Context.Competitiors.ToList().
                    Where(p => p.EventCompetitionId == judger.EventCompetitionId && p.CompetitionId == judger.CompetitionId).ToList().Count; i++)
                {
                    stationNumbersList.Add(i);
                }
                TblTotal.Text = $"Total Members: {stationNumbersList.Count}";
                // Удаление использованных ранее номеров
                foreach (var competitior in AppData.Context.Competitiors.ToList().
                    Where(p => p.EventCompetitionId == judger.EventCompetitionId && p.CompetitionId == judger.CompetitionId && p.StationNumber != null).ToList())
                {
                    stationNumbersList.Remove(Convert.ToInt32(competitior.StationNumber));
                }
            }
            catch
            {
                MessageBox.Show("Data Base Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                BtnDrawLots.IsEnabled = false;
            }
        }
        /// <summary>
        /// Метод обрабатывающий нажатие на кнопку Draw Lots
        /// </summary>
        private void BtnDrawLots_Click(object sender, RoutedEventArgs e)
        {
            var judger = AppData.Context.Judgers.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            if (AppData.Context.Competitiors.ToList().
                Where(p => p.EventCompetitionId == judger.EventCompetitionId && p.CompetitionId == judger.CompetitionId && p.StationNumber == null).
                ToList().Count == 0) //Если у всех участников есть номера
            {
                MessageBox.Show("All competitior have a station number", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Random random = new Random();
            foreach (var competitior in AppData.Context.Competitiors.ToList().
                Where(p => p.EventCompetitionId == judger.EventCompetitionId && p.CompetitionId == judger.CompetitionId && p.StationNumber == null).ToList())
            {
                int index; // переменная хранящая выпавший индекс
                index = random.Next(0, stationNumbersList.Count);  //получение случайного индекса
                competitior.StationNumber = stationNumbersList[index]; // присваивание номера участника
                stationNumbersList.RemoveAt(index); // удаление использованного номера из листа с номерами
                AppData.Context.SaveChanges();
            }
            DgCompetitiors.ItemsSource = null;
            DgCompetitiors.ItemsSource = AppData.Context.Competitiors.ToList().
                Where(p => p.EventCompetitionId == judger.EventCompetitionId && p.CompetitionId == judger.CompetitionId).ToList(); // Обновелние DataGrid
        }
    }
}
