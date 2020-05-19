using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для AboutWsChinaPage.xaml
    /// </summary>
    public partial class AboutWsChinaPage : Page

    {
        private List<FilesForDownload> _accesionList = new List<FilesForDownload>();
        private List<FilesForDownload> _commeittieList = new List<FilesForDownload>();
        private List<FilesForDownload> _partisipationList = new List<FilesForDownload>();
        public AboutWsChinaPage()
        {
            InitializeComponent();
            GetFiles(_accesionList, "Accession");
            GetFiles(_commeittieList, "Commeitte");
            GetFiles(_partisipationList, "Partisipation");
            ICFiles.ItemsSource = _accesionList;
        }
        /// <summary>
        /// Класс для хранения списка файлов
        /// </summary>
        private class FilesForDownload
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
        }
        /// <summary>
        /// Метод для получения нужных фалов
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        private void GetFiles(List<FilesForDownload> list, string type)
        {
            int id = 1;
            foreach (var file in new DirectoryInfo($@"..\..\Resourses\AboutWsChinaPage\{type}").GetFiles())
            {
                list.Add(new FilesForDownload
                {
                    Id = id++,
                    Name = file.Name,
                    Path = file.FullName
                });
            }
        }
        /// <summary>
        /// Метод для переключения отображаемых файлов
        /// </summary>
        private void Border1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICFiles.ItemsSource = _accesionList;
        }
        /// <summary>
        /// Метод для переключения отображаемых файлов
        /// </summary>
        private void Border2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICFiles.ItemsSource = _commeittieList;
        }
        /// <summary>
        /// Метод для переключения отображаемых файлов
        /// </summary>
        private void Border3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ICFiles.ItemsSource = _partisipationList;
        }
        /// <summary>
        /// Метод для загрузки выбранного файла
        /// </summary>
        private void TblDownload_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                FilesForDownload filesForDownload = (sender as TextBlock).DataContext as FilesForDownload;
                try
                {
                    File.Copy(filesForDownload.Path, $@"{path}\{filesForDownload.Name}");
                    if (System.Windows.MessageBox.Show("Open file after download?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Process.Start($@"{path}\{filesForDownload.Name}");
                    }
                }
                catch
                {
                    if (System.Windows.MessageBox.Show("A file with that name exists.\n Overwrite it?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        File.Delete($@"{path}\{filesForDownload.Name}");
                        File.Copy(filesForDownload.Path, $@"{path}\{filesForDownload.Name}");
                        if (System.Windows.MessageBox.Show("Open file after download?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            Process.Start($@"{path}\{filesForDownload.Name}");
                        }
                    }
                }
            }
        }
    }
}
