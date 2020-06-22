using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfBubbles_Zakharov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double bubble = 0; //перменная хранящая милисколько прошло секунд, для создания пузыря
        double speed = 60; //переменная хранящая через сколько милисекунд, нужно создавать пузырь
        int score = 0; //переменная храянщая результат
        double move = 0; //переменная хранящая сколько секунд осталось, до смены направления
        List<string> corals = new List<string>(); // лист с коралами
        List<string> bubbles = new List<string>(); //лист с пузыриками
        string appFolderPath; // переменная помогающая выйти в корневую папку из папки с exe файлом
        string resourcesFolderPath; // переменная погощая выйти в папку ресурсы
        public MainWindow()
        {
            InitializeComponent();
            TblScore.Text = "0";
            TblMoving.Text = "↑";
            // первоначальные данные
            appFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            resourcesFolderPath = System.IO.Path.Combine(Directory.GetParent(appFolderPath).Parent.FullName, "Recourses\\");
            //заполнение переменных с путями к файлам
            bubbles.Add($"{resourcesFolderPath}bubble1.png");
            bubbles.Add($"{resourcesFolderPath}bubble2.png");
            bubbles.Add($"{resourcesFolderPath}bubble3.png");
            // заполнение листа с пузыриками 
            DispatcherTimer timer = new DispatcherTimer(); // общий таймер программы
            DispatcherTimer timerForMove = new DispatcherTimer(); // таймер позволяющий пузырикам двигаться
            timer.Interval = new TimeSpan(0,0,0,0,100);
            timer.Tick += Timer_Tick;
            timer.Start();
            timerForMove.Interval = new TimeSpan(0, 0, 0, 0, 5);
            timerForMove.Tick += TimerForMove_Tick;
            timerForMove.Start();
            DrawCorals();
        }
        /// <summary>
        /// Метод таймера для движения
        /// </summary>
        private void TimerForMove_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var image in CanvasMain.Children.OfType<Image>())
                {
                    var bottom = Canvas.GetBottom(image);
                    Canvas.SetBottom(image, bottom + 0.5);
                }
                foreach (var image in CanvasMain.Children.OfType<Image>())
                {
                    if (Canvas.GetBottom(image) >= CanvasMain.ActualHeight - 50
                        || Canvas.GetRight(image) >= CanvasMain.ActualWidth - 25
                        || Canvas.GetRight(image) - 25 <= 0)
                    {
                        CanvasMain.Children.Remove(image);
                        score--;
                        TblScore.Text = score.ToString();
                    }
                }
                switch (TblMoving.Text)
                {
                    case "↖":
                        foreach (var image in CanvasMain.Children.OfType<Image>())
                        {
                            var right = Canvas.GetRight(image);
                            Canvas.SetRight(image, right + 0.5);
                            TblMoving.Text = "↖";
                        }
                        break;
                    case "↗":
                        foreach (var image in CanvasMain.Children.OfType<Image>())
                        {
                            var right = Canvas.GetRight(image);
                            Canvas.SetRight(image, right - 0.5);
                            TblMoving.Text = "↗";
                        }
                        break;
                    case "↑":
                        TblMoving.Text = "↑";
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Метод общего таймера
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            bubble += 100;
            move += 100;
            if (bubble >= speed)
            {
                DrawBubble();
                bubble = 0;
            }
            if (move >= 20000)
            {
                move = 0;
                switch (new Random().Next(1, 4))
                {
                    case 1:
                        foreach (var image in CanvasMain.Children.OfType<Image>())
                        {
                            TblMoving.Text = "↖";
                        }
                        break;
                    case 2:
                        foreach (var image in CanvasMain.Children.OfType<Image>())
                        {
                            TblMoving.Text = "↗";
                        }
                        break;
                    case 3:
                        TblMoving.Text = "↑";
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Метод для надувания пузыря :)
        /// </summary>
        private void DrawBubble()
        {
            Image image = new Image();
            CanvasMain.Children.Add(image);
            image.Source = new BitmapImage(new Uri(bubbles[new Random().Next(0, 3)]));
            image.Width = image.Height = 50;
            image.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Canvas.SetBottom(image, new Random().Next(0, Convert.ToInt32(CanvasMain.ActualHeight - 100)));
            Canvas.SetRight(image, new Random().Next(0, Convert.ToInt32(CanvasMain.ActualWidth - 30)));
        }
        /// <summary>
        /// Метод для лопанья пузыриков
        /// </summary>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CanvasMain.Children.Remove(sender as Image);
            score++;
            TblScore.Text = score.ToString();
        }
        /// <summary>
        /// Зарисовка коралами
        /// </summary>
        private void DrawCorals()
        {
            corals.Add($"{resourcesFolderPath}coral1.png");
            corals.Add($"{resourcesFolderPath}coral2.png");
            corals.Add($"{resourcesFolderPath}coral3.png");
            corals.Add($"{resourcesFolderPath}coral4.png");
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 2:
                        DrawCoralImage(new BitmapImage(new Uri(corals[0])));
                        break;
                    case 3:
                        DrawCoralImage(new BitmapImage(new Uri(corals[1])));
                        break;
                    case 4:
                        DrawCoralImage(new BitmapImage(new Uri(corals[2])));
                        break;
                    case 5:
                        DrawCoralImage(new BitmapImage(new Uri(corals[3])));
                        break;
                    default:
                        DrawCoralImage(new BitmapImage(new Uri(corals[random.Next(0, 4)])));
                        break;
                }
            }
        }
        /// <summary>
        /// Метод для нарисовки определённого корала
        /// </summary>
        /// <param name="bitmapImage"></param>
        private void DrawCoralImage(BitmapImage bitmapImage)
        {
            Image image = new Image();
            MainStack.Children.Add(image);
            image.Source = bitmapImage;
            image.Width = image.Height = 75;
        }
        /// <summary>
        /// Метод отслеживающий изменения положения слайдера
        /// </summary>
        private void SlSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            speed = 2000;
            for (int i = 0; i < SlSpeed.Value; i++)
            {
                speed -= 100;
                if (speed <= 0)
                {
                    speed = 100;
                }
            }
            try
            {
                TblSpeed.Text = $"Speed: {Convert.ToInt32(SlSpeed.Value)}";
            }
            catch
            {

            }
        }
    }
}
