using System;
using System.Collections.Generic;
using System.Globalization;
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
using WSChina2020AppComp03.Pages.Admin;
using WSChina2020AppComp03.Pages.Competitor;
using WSChina2020AppComp03.Pages.Coordinator;
using WSChina2020AppComp03.Pages.Judger;

namespace WSChina2020AppComp03.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginScreenPage.xaml
    /// </summary>
    public partial class LoginScreenPage : Page
    {
        int countOfLogin = 0;
        private string CapchaText = "";
        private Random random = new Random();
        public LoginScreenPage()
        {
            InitializeComponent();
            TbLogin.Text = Properties.Settings.Default.UserId;
            PbPassword.Password = Properties.Settings.Default.Password;
            countOfLogin = AppData.countLogin;
            if (countOfLogin >= 3)
            {
                BtnLogin.IsEnabled = false;
            }
            ImageCapha.Source = Drawing(1500, 500);
        }

        /// <summary>
        /// Метод создания капчи
        /// </summary>
        /// <param name="x">Высота</param>
        /// <param name="y">Ширина</param>
        /// <returns></returns>
        private DrawingImage Drawing(int x, int y)
        {
            CapchaText = null;
            string alltext = "qQWwEeRrTtYyUuIiOoPPAaSsDdFfGgHhJjKkLlZzXxCcVvBbNnMm1234567890";
            string text = "qwertyuioasdfghjklzxcvbnm";
            string number = "1234567890";

            List<char> result = new List<char>()
            {
                alltext[random.Next(alltext.Length)],
                text.ToUpper()[random.Next(text.Length)],
                text[random.Next(text.Length)],
                number[random.Next(number.Length)]
            };

            for (int i = 0; i < 4; i++)
            {
                char symbol = result[random.Next(result.Count())];
                CapchaText += symbol;
                result.Remove(symbol);
            }

            byte[] bytes = new byte[x * y * 100];
            random.NextBytes(bytes);

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(BitmapSource.Create(x, y, 300, 300, PixelFormats.Gray32Float, null, bytes, x * 30), new Rect(0, 0, x, y));
                drawingContext.DrawText(new FormattedText(CapchaText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                    new Typeface("Microsoft Sans Serif"), 300, Brushes.Black), new Point(x / 5, y / 5));

            }
            return new DrawingImage(drawingVisual.Drawing);
        }
        /// <summary>
        /// Обработчик клика на кнопку "Login"
        /// </summary>
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string error = "";
            if (String.IsNullOrWhiteSpace(TbLogin.Text)) error += "• Write the Id Number\n"; ;
            if (String.IsNullOrWhiteSpace(PbPassword.Password)) error += "• Write the Password\n";
            if (String.IsNullOrWhiteSpace(TbAuthCode.Text)) error += "• Write the Auth Code\n";
            if (!(String.IsNullOrWhiteSpace(error)))
            {
                MessageBox.Show($"{error}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ImageCapha.Source = Drawing(1500, 500);
                return; // Ошибка о том, что данные не введены
            }
            if (TbAuthCode.Text.ToLower() != CapchaText.ToLower())
            {
                error += "• Wrong the Auth Code\n";
                MessageBox.Show($"{error}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ImageCapha.Source = Drawing(1500, 500);
                return; // Ошибка, если капча не верна
            }
            try //Защита от вылетов
            {
                AppData.CurrentUser = AppData.Context.Users.ToList().FirstOrDefault(p => p.Id.ToString() == TbLogin.Text && p.Password == PbPassword.Password);
            }
            catch
            {
                MessageBox.Show("Connecting to the database error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (AppData.CurrentUser != null)
            { // Если пользователь найден
                if (CheckBRemember.IsChecked == true)
                {
                    Properties.Settings.Default.UserId = AppData.CurrentUser.Id.ToString();
                    Properties.Settings.Default.Password = AppData.CurrentUser.Password;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.UserId = "";
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Save();
                }
                switch (AppData.CurrentUser.RoleId)
                {
                    case 1:
                        AppData.MainFrame.Navigate(new CompetitorMenuPage());
                        break;
                    case 2:
                        AppData.MainFrame.Navigate(new CoordinatorMenuPage());
                        break;
                    case 3:
                        AppData.MainFrame.Navigate(new AdministratorMenuPage());
                        break;
                    case 4:
                        AppData.MainFrame.Navigate(new JudgerMenuPage());
                        break;
                    default:
                        break;
                }
            }
            else
            { //Если пользователь не найден 
                MessageBox.Show("• Wrong Id Number or Password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ImageCapha.Source = Drawing(1500, 500);
                countOfLogin++;
                if (countOfLogin >= 3)
                {
                    MessageBox.Show("• Exceeded the number of login attempts.\n Restart the application", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    AppData.countLogin = 3;
                    BtnLogin.IsEnabled = false;
                }
                return;
            }
        }
        /// <summary>
        /// Обработчик клика на кнопку "Cancel"
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cancel actions?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.MainFrame.Navigate(new MainScreenPage());
            }
        }
        /// <summary>
        /// Обработчик нажатия лкм на картинку
        /// </summary>
        private void ImageCapha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageCapha.Source = Drawing(1500, 500); // Обновление капчи
        }
    }
}
