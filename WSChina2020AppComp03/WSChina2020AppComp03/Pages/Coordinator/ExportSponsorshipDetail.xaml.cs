using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using WSChina2020AppComp03.Entities;
using WSChina2020AppComp03.Pages.Coordinator;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace WSChina2020AppComp03.Pages.Competitor
{
    /// <summary>
    /// Interaction logic for ExportSponsorshipDetail.xaml
    /// </summary>
    public partial class ExportSponsorshipDetail : System.Windows.Controls.Page
    {
        private string _filePath = "";
        private int _numberOfButton = 0;
        private string _xmlResult = "";
        private List<Sponsorship> sponsorshipList = new List<Sponsorship>();
        public ExportSponsorshipDetail(List<Sponsorship> sponsorships)
        {
            InitializeComponent();
            RBtnXML.IsChecked = true;
            sponsorshipList = sponsorships;
        }
        /// <summary>
        /// Обработка клика на кнопку "Export"
        /// </summary>
        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            switch (_numberOfButton)
            {
                case 0:
                    if (RBtnXML.IsChecked == false) //Обработка если сохраняемый файл не соответвествует выбранной кнопки
                    {
                        MessageBox.Show("A different format was selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    // Запись в XML не хитрым способом 
                    _xmlResult += "<?xml version=\"1.0\" encoding=\"utf - 16\"?>\n  <SponsorshipDetal Version = \"1.0.0\">\n";
                    foreach (var SponsorshipDetal in sponsorshipList)
                    {
                        _xmlResult += $"      <SponsorshipDetal Event = \"{SponsorshipDetal.EventCompetition.YearCountryTown}\" " +
                             $"Skills=\"{SponsorshipDetal.Competition.FullCompetition}\" Sponsor = \"{SponsorshipDetal.Sponsor.Name}\" " +
                             $"SponsorItem = \"{SponsorshipDetal.CategoryOfSponsorship.Name}\" Amount = \"{SponsorshipDetal.FullPriceOneCategory}\"/>\n";
                    }
                    _xmlResult += "   </SponsorshipDetal>";
                    File.WriteAllText(_filePath, _xmlResult);
                    break;
                case 1:
                    if (RBtnXLS.IsChecked == false) //Обработка если сохраняемый файл не соответвествует выбранной кнопки
                    {
                        MessageBox.Show("A different format was selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    // Запись в Excel
                    Application application = new Application();
                    Workbook workbook = application.Workbooks.Add(1);
                    Worksheet worksheet = workbook.Sheets[1];
                    worksheet.Cells[1][1] = "Event";
                    worksheet.Cells[2][1] = "Skills";
                    worksheet.Cells[3][1] = "Sponsor";
                    worksheet.Cells[4][1] = "SponsorItem";
                    worksheet.Cells[5][1] = "Amount";
                    int row = 2;
                    foreach (var Sponsorship in sponsorshipList)
                    {
                        worksheet.Cells[1][row] = Sponsorship.EventCompetition.YearCountryTown;
                        worksheet.Cells[2][row] = Sponsorship.Competition.FullCompetition;
                        worksheet.Cells[3][row] = Sponsorship.Sponsor.Name;
                        worksheet.Cells[4][row] = Sponsorship.CategoryOfSponsorship.Name;
                        worksheet.Cells[5][row] = Sponsorship.FullPriceOneCategory;
                        row++;
                    }
                    application.ActiveWorkbook.SaveAs(_filePath);
                    workbook.Close();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Обработка клика на кнопку "Browse..."
        /// </summary>
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (RBtnXLS.IsChecked == true)
            {
                _numberOfButton = 1;
                saveFileDialog.Filter = "Excel files (*.xls, *.xlsx) | *.xls; *xlsx";
            }
            if (RBtnXML.IsChecked == true)
            {
                _numberOfButton = 0;
                saveFileDialog.Filter = "XML Document (*.xml)|*.xml";
            }
            if (saveFileDialog.ShowDialog() == true)
            {
                _filePath = $"{saveFileDialog.FileName}";
                TbFIleName.Text = saveFileDialog.SafeFileName;
            }
        }
        /// <summary>
        /// Обработка клика на кнопку "Cancel"
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel actions?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.MainFrame.Navigate(new SponsorshipViewPage());
            }
        }
    }
}
