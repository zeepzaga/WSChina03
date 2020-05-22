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

namespace WSChina2020AppComp03.Pages.Competitor
{
    /// <summary>
    /// Interaction logic for MyResultsPage.xaml
    /// </summary>
    public partial class MyResultsPage : Page
    {
        public MyResultsPage()
        {
            InitializeComponent();
            Competitior competitior = AppData.Context.Competitiors.ToList().FirstOrDefault(p => p.UserId == AppData.CurrentUser.Id);
            DataContext = competitior;
            List<ScheduleOfCompetitor> ScheduleList = AppData.Context.ScheduleOfCompetitors.ToList().Where(p => p.CompetitorId == competitior.Id).ToList();
            ICSession.ItemsSource = ScheduleList;
            double cout = 0;
            foreach (var sessia in ScheduleList)
            {
                cout += Convert.ToDouble(sessia.Points);
            }
            TblockTotalPoints.Text = $"{cout}";
        }
    }
}
