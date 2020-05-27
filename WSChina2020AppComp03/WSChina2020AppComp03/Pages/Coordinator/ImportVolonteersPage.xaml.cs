using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WSChina2020AppComp03.Entities;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Interaction logic for ImportVolonteersPage.xaml
    /// </summary>
    public partial class ImportVolonteersPage : System.Windows.Controls.Page
    {
        // переменные нужные для работы с Excel
        private Worksheet _worksheet;
        private Range _range;
        private Workbook _workbook;
        private _Application _application = new _Excel.Application();
        private int CountOfRows;
        private int CountOfColumns;
        // переменные для счёта для финального вывода
        private int _newRecord = 0;
        private int _totalRecord = 0;
        private int _overriderRecord = 0;
        //воркер
        BackgroundWorker backgroundWorker;
        public ImportVolonteersPage()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }
        /// <summary>
        /// Обработка кнопки импорт
        /// </summary>
        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
        /// <summary>
        ///  Обработка отмены импорта
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel actions?", "Question", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (AppData.MainFrame.CanGoBack)
                {
                    backgroundWorker.CancelAsync();
                    AppData.MainFrame.GoBack();
                }
            }
        }
        /// <summary>
        /// Кнопка для загрузки документа
        /// </summary>
        private void BtnDocument_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Excel files (*.xls, *.xlsx | *.xls; *xlsx",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == true)
            {

                _workbook = _application.Workbooks.Open(openFileDialog.FileName);
                _worksheet = _workbook.Worksheets[1];
                _range = _worksheet.UsedRange;
                CountOfRows = _range.Rows.Count;
                CountOfColumns = _range.Columns.Count;
                TbPath.Text = openFileDialog.SafeFileName;
                _newRecord = 0;
                _overriderRecord = 0;
                PBProgress.Value = 0;
            }
        }
        /// <summary>
        /// Метод обрабатывающий окончание работы
        /// </summary>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PBProgress.Value = 100;
            TblResult.Text = $"Import Successfully! Total Record: {_totalRecord}; New Record: {_newRecord}; Overridden Record: {_overriderRecord}";
        }
        /// <summary>
        /// Счётчик процессов 
        /// </summary>
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PBProgress.Value = e.ProgressPercentage;
        }
        /// <summary>
        /// Выполнение импорта
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (CountOfColumns != 6)
            {
                MessageBox.Show("Not correct document", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            for (int row = 2; row <= CountOfRows; row++)
            {
                string nameAndLastName = Convert.ToString(_worksheet.Cells[row, 2].Value2);
                string name = nameAndLastName.Substring(0, nameAndLastName.IndexOf(" "));
                string lastName = nameAndLastName.Substring(nameAndLastName.IndexOf(" "));
                int gender = 1;
                switch (Convert.ToString(_worksheet.Cells[row, 3].Value2))
                {
                    case "Male":
                        gender = 1;
                        break;
                    case "Female":
                        gender = 2;
                        break;
                    default:
                        break;
                }
                try
                {
                    var newVolunteer = new Volunteer
                    {
                        Id = Convert.ToInt32(Convert.ToString(_worksheet.Cells[row, 1].Value2)),
                        Name = name,
                        LastName = lastName,
                        GenderId = gender,
                        RepresentCountryId = Convert.ToInt32(Convert.ToString(_worksheet.Cells[row, 4].Value2)),
                        BornCountryId = Convert.ToInt32(Convert.ToString(_worksheet.Cells[row, 5].Value2)),
                        CompetitionId = Convert.ToInt32(Convert.ToString(_worksheet.Cells[row, 6].Value2)),
                    };
                    List<Volunteer> list = AppData.Context.Volunteers.ToList();
                    _totalRecord = list.Count;
                    var volunteer = list.FirstOrDefault(p => p.Id == System.Convert.ToInt32(System.Convert.ToString(_worksheet.Cells[row, 1].Value2)));
                    if (volunteer != null)
                    {
                        volunteer = newVolunteer;
                        AppData.Context.SaveChanges();
                        _newRecord++;
                        _overriderRecord++;
                        _totalRecord++;
                    }
                    else
                    {
                        AppData.Context.Volunteers.Add(newVolunteer);
                        AppData.Context.SaveChanges();
                        _newRecord++;
                        _totalRecord++;
                    }
                }
                catch { MessageBox.Show(""); }
                backgroundWorker.ReportProgress((int)(100 / _totalRecord * row));
            }
        }
    }
}

