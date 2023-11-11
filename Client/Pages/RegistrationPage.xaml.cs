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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            CbQuestion.ItemsSource = App.DB.CodeQuestion.Where(x => x.IsCustom == false).ToList();
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
            CbQuestion.SelectedItem = null;
            StOwnQuestionBlock.Visibility = Visibility.Collapsed;
            TbOwnQuestion.Clear();
            TbCodeAnswer.Clear();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            var selectedItem = CbQuestion.SelectedItem as CodeQuestion;
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                errorMessage += "Введите логин\n";
            }
            if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                errorMessage += "Введите пароль\n";
            }
            if (string.IsNullOrWhiteSpace(PbSecondPassword.Password))
            {
                errorMessage += "Введите повторяющийся пароль\n";
            }
            if (selectedItem == null)
            {
                errorMessage += "Выберите кодовый вопрос\n";
            }
            else if (selectedItem.Id == 7 && string.IsNullOrWhiteSpace(TbOwnQuestion.Text))
            {
                errorMessage += "Введите свой кодовый вопрос\n";
            }
            if (string.IsNullOrWhiteSpace(TbCodeAnswer.Text))
            {
                errorMessage += "Введите ответ на кодовый вопрос\n";
            }
            if(string.IsNullOrEmpty(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if(PbPassword.Password != PbSecondPassword.Password)
            {
                MessageBox.Show("Пароли не повторяются!");
                return;
            }
            if (App.DB.User.FirstOrDefault(x => x.Login == TbLogin.Text) != null)
            {
                MessageBox.Show("Такой логин уже существует!");
                return;
            }
            if(selectedItem.Id == 7)
            {
                App.DB.CodeQuestion.Add(new CodeQuestion()
                {
                    Name = TbOwnQuestion.Text,
                    IsCustom = true
                });
                App.DB.User.Add(new User()
                {
                    Login = TbLogin.Text,
                    Password = PbPassword.Password,
                    RoleId = 1,
                    CodeAnswer = TbCodeAnswer.Text,
                    CodeQuestion = App.DB.CodeQuestion.FirstOrDefault(x => x.Name == TbOwnQuestion.Text)
                });
                
            }
            else
            {
                App.DB.User.Add(new User()
                {
                    Login = TbLogin.Text,
                    Password = PbPassword.Password,
                    RoleId = 1,
                    CodeAnswer = TbCodeAnswer.Text,
                    CodeQuestion = CbQuestion.SelectedItem as CodeQuestion
                });
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
            MessageBox.Show("Регистрация прошла успешно!");

        }

        private void CbQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ComboBox).SelectedItem as CodeQuestion;
            if (selectedItem == null)
            {
                return;
            }
            if(selectedItem.Id == 7)
            {
                StOwnQuestionBlock.Visibility = Visibility.Visible;
            }
            else
            {
                TbOwnQuestion.Clear();
                StOwnQuestionBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}
