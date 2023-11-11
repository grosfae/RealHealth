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
    /// Логика взаимодействия для ForgotPassworPage.xaml
    /// </summary>
    public partial class ForgotPassworPage : Page
    {
        bool isAnswered = false;
        public ForgotPassworPage()
        {
            InitializeComponent();
        }
        private void NoneSpaceBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void BackBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            TbLogin.Clear();
            PbPassword.Clear();
            PbSecondPassword.Clear();
            TbCodeAnswer.Clear();
            PbPassword.Clear();
            PbSecondPassword.Clear();
            PbSecondPassword.IsEnabled = false;
            PbPassword.IsEnabled = false;
            isAnswered = false;
            TbCodeAnswer.IsEnabled = true;
            TbLogin.IsEnabled = true;
            TbCodeQuestion.Text = String.Empty;
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                TbCodeQuestion.Text = String.Empty;
                MessageBox.Show("Заполните логин"); 
                return;
            }
            var user = App.DB.User.FirstOrDefault(x => x.RoleId == 1 && x.Login == TbLogin.Text);
            if(user == null)
            {
                MessageBox.Show("Такого пользователя не существует");
                return;
            }
            TbCodeQuestion.Text = user.CodeQuestion.Name;

            if (string.IsNullOrWhiteSpace(TbCodeAnswer.Text))
            {
                MessageBox.Show("Ответьте на кодовый вопрос");
                return;
            }
            if (user.CodeAnswer != TbCodeAnswer.Text)
            {
                MessageBox.Show("Ответ на кодовый вопрос неверный");
                return;
            }
            
            if(user.CodeAnswer == TbCodeAnswer.Text && isAnswered == false)
            {
                MessageBox.Show("Вы успешно ответили на кодовый вопрос, теперь вы можете сменить старый пароль на новый");
                PbPassword.IsEnabled = true;
                PbSecondPassword.IsEnabled = true;
                isAnswered = true;
                TbCodeAnswer.IsEnabled = false;
                TbLogin.IsEnabled = false;
            }
            if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (string.IsNullOrWhiteSpace(PbSecondPassword.Password))
            {
                MessageBox.Show("Введите повторяющийся пароль");
                return;
            }
            if (PbPassword.Password != PbSecondPassword.Password)
            {
                MessageBox.Show("Пароли не повторяются!");
                return;
            }
            if (PbPassword.Password == user.Password)
            {
                MessageBox.Show("Это старый пароль, введите новый");
                return;
            }
            user.Password = PbPassword.Password;
            App.DB.SaveChanges();
            NavigationService.GoBack();
            MessageBox.Show("Пароль успешно сменен");

        }
    }
}
