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
    /// Interaction logic for PrintCompetitiorCardTeamPage.xaml
    /// </summary>
    public partial class PrintCompetitiorCardTeamPage : Page
    {
        List<Competitior> competitiorsList = new List<Competitior>();
        public PrintCompetitiorCardTeamPage(int teamId)
        {
            InitializeComponent();
            foreach (var item in AppData.Context.TeamCompetitions.Where(p=>p.TeamId==teamId).ToList())
            {
                competitiorsList.Add(item.Competitior);
            }
            Print.ItemsSource = competitiorsList;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Retur?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.MainFrame.Navigate(new AdministratorMenuPage());
            }
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog()==true)
            {
                printDialog.PrintVisual(Print, "Print");
            }
        }
    }
}
