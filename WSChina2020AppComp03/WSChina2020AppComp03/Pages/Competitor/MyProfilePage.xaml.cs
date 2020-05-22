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
    /// Interaction logic for MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        public MyProfilePage()
        {
            InitializeComponent();
            try
            {
                DataContext = AppData.CurrentUser;
            }
            catch
            {
                MessageBox.Show("DataBase Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            BorderPassword.IsEnabled = false;
        }
        /// <summary>
        /// Кнопка сохранить
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBModifyPassword.IsChecked == false) return;
            string error = "";
            bool isCharRepeated = false;
            var password = PbPassword.Password;
            var repassword = PbRepeatPassword.Password;

            if (password != repassword)
            {
                MessageBox.Show("The Repassword field is not equal to the Password field", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (password.Any(char.IsUpper) == false) error += "• The password must contain at least one uppercase letter\n";
            if (password.Any(char.IsLower) == false) error += "• The password must contain at least one lowercase letter\n";
            if (password.Any(char.IsDigit) == false) error += "• The password must contain at least one digit\n";
            if (String.IsNullOrWhiteSpace(password) == true) error += "• The password must not contain spaces\n";

            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i].ToString().ToLower() == password[i + 1].ToString().ToLower()
                    && password[i + 1].ToString().ToLower() == password[i + 2].ToString().ToLower())
                    isCharRepeated = true;
                break;
            }
            if (isCharRepeated) error += "• The same symbol cannot be repeated 3 times in a row\n";
            if (error != "")
            {
                MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                AppData.CurrentUser.Password = PbPassword.Password;
                AppData.Context.SaveChanges();
            }
            catch
            {
                MessageBox.Show("DataBase Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Кнопка отмены
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel actions?", "Question", MessageBoxButton.OK, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (AppData.MainFrame.CanGoBack)
                {
                    AppData.MainFrame.GoBack();
                }
            }
        }
        /// <summary>
        /// Метод позволяющий включить смену пароля
        /// </summary>
        private void CheckBModifyPassword_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBModifyPassword.IsChecked == true)
                BorderPassword.IsEnabled = BtnSave.IsEnabled = true;
            else
                BorderPassword.IsEnabled = BtnSave.IsEnabled = false;
        }
        /// <summary>
        ///  Метод позволяющий скрывать и показывать пароль
        /// </summary>
        private void CheckBShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBShowPassword.IsChecked == true)
            {
                TbPassword.Text = PbPassword.Password;
                TbRepeatPassword.Text = PbRepeatPassword.Password;
                TbPassword.Visibility = TbRepeatPassword.Visibility = Visibility.Visible;
                PbPassword.Visibility = PbRepeatPassword.Visibility = Visibility.Collapsed;
            }
            if (CheckBShowPassword.IsChecked == false)
            {
                PbPassword.Password = TbPassword.Text;
                PbRepeatPassword.Password = TbRepeatPassword.Text;
                TbPassword.Visibility = TbRepeatPassword.Visibility = Visibility.Collapsed;
                PbPassword.Visibility = PbRepeatPassword.Visibility = Visibility.Visible;
            }
        }
    }
}
