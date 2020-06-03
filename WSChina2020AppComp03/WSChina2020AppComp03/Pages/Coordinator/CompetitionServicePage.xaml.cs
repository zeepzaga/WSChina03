using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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

namespace WSChina2020AppComp03.Pages.Coordinator
{
    /// <summary>
    /// Interaction logic for CompetitionServicePage.xaml
    /// </summary>
    public partial class CompetitionServicePage : Page
    {
        private bool _isDown = false; // переменная для хранения зажата ли ЛКМ
        private ServiceType _data; // переменная для хранения контекста картинки
        // лист для хранения элементов канваса
        private List<CompetitionService> competitionServicesList = new List<CompetitionService>(); 
        public CompetitionServicePage()
        {
            InitializeComponent();
            competitionServicesList = AppData.Context.CompetitionServices.ToList();
            LVService.ItemsSource = AppData.Context.ServiceTypes.ToList();
            LoadCanvas();
        }
        /// <summary>
        /// Обработка кнопки "Clear"
        /// </summary>
        private void BtnCLear_Click(object sender, RoutedEventArgs e)
        {
            CanvasMain.Children.Clear();
        }
        /// <summary>
        /// Метод загружающий элементы на канвас из базы 
        /// </summary>
        private void LoadCanvas()
        {
            foreach (var item in competitionServicesList)
            {
                Image image = new Image();
                image.Width = image.Height = 25;
                image.DataContext = item.ServiceType;
                image.SetBinding(Image.SourceProperty, new Binding("Image"));
                image.MouseMove += Image_MouseMove;
                image.MouseLeftButtonDown += Image_MouseDown;
                image.MouseUp += Image_MouseUp;
                image.MouseRightButtonDown += Image_MouseRightButtonDown;
                CanvasMain.Children.Add(image);
                Canvas.SetTop(image, Convert.ToDouble(item.CoordinateY));
                Canvas.SetLeft(image, Convert.ToDouble(item.CoordinateX));
            }
        }
        /// <summary>
        /// Обработка кнопки "Save"
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Save Changes", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Context.CompetitionServices.RemoveRange(competitionServicesList);
                AppData.Context.SaveChanges();
                foreach (var item in CanvasMain.Children)
                {
                    AppData.Context.CompetitionServices.Add(new CompetitionService
                    {
                        ServiceTypeId = ((item as Image).DataContext as ServiceType).Id,
                        CoordinateX = Convert.ToDecimal(Canvas.GetLeft(item as Image)),
                        CoordinateY = Convert.ToDecimal(Canvas.GetTop(item as Image)),
                    });
                }
                AppData.Context.SaveChanges();
            }
        }
        /// <summary>
        /// Метод позволяющий выбрать элемент из списка
        /// </summary>
        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _data = (sender as StackPanel).DataContext as ServiceType;
            DragDrop.DoDragDrop((sender as StackPanel), _data, DragDropEffects.Move);
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDown = true;
            foreach (var item in CanvasMain.Children)
            {
                Canvas.SetZIndex(sender as Image, CanvasMain.Children.Count);
                if (item as Image != sender as Image)
                {
                    Canvas.SetZIndex(item as Image, 0);
                }
            }
        }
        /// <summary>
        /// Метод позволяющий перемещать картинки внутри канвас
        /// </summary>
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                var windowPosition = Mouse.GetPosition(CanvasMain);
                double x = windowPosition.X - (sender as Image).ActualWidth / 2;
                double y = windowPosition.Y - (sender as Image).ActualHeight / 2;
                if (windowPosition.X < 0 || windowPosition.X > 745 ||
                    windowPosition.Y > 295 || windowPosition.Y < 0) return;
                Canvas.SetLeft(sender as Image, x);
                Canvas.SetTop(sender as Image, y);
            }
        }
        /// <summary>
        /// Метод принимающий Drop на канвас
        /// </summary>
        private void CanvasMain_Drop(object sender, DragEventArgs e)
        {
            Image image = new Image();
            image.Width = image.Height = 25;
            image.DataContext = _data;
            image.SetBinding(Image.SourceProperty, new Binding("Image"));
            image.MouseMove += Image_MouseMove;
            image.MouseLeftButtonDown += Image_MouseDown;
            image.MouseUp += Image_MouseUp;
            image.MouseRightButtonDown += Image_MouseRightButtonDown;
            CanvasMain.Children.Add(image);
            Canvas.SetTop(image, e.GetPosition(CanvasMain).Y);
            Canvas.SetLeft(image, e.GetPosition(CanvasMain).X);
        }
        /// <summary>
        /// Метод позволяющий удалять элементы с канвас
        /// </summary>
        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            CanvasMain.Children.Remove((sender as Image));
        }
        /// <summary>
        /// Метод отслеживающий поднятие ЛКМ 
        /// </summary>
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDown = false;
        }
    }
}
