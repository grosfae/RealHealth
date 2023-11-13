using Client.Components;
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

namespace Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            var user = App.DB.User.FirstOrDefault(x => x.Login == TbLogin.Text && x.RoleId == 1);
            if(user == null)
            {
                MessageBox.Show("Такого пользователя не существует!");
                return;
            }
            if (user.Password != PbPassword.Password)
            {
                MessageBox.Show("Неправильный пароль!");
                return;
            }
            if (CbRemember.IsChecked == true)
            {
                Properties.Settings.Default.Password = PbPassword.Password;
            }
            else
            {
                Properties.Settings.Default.Password = null;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.Login = TbLogin.Text;
            Properties.Settings.Default.Save();

            App.LoggedUser = user;
            if (user.MedicalCard.Count() == 0)
            {
                NavigationService.Navigate(new MedicalCardFields(new MedicalCard()));
            }
            else
            {
                NavigationService.Navigate(new MenuPage());
            }


        }

        private void RegBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void RevivePasswordBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ForgotPassworPage());
        }
        private void NoneSpaceBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Login))
            {
                TbLogin.Text = Properties.Settings.Default.Login;
            }
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Password))
            {
                PbPassword.Password = Properties.Settings.Default.Password;
                CbRemember.IsChecked = true;
            }
        }
    }
}
