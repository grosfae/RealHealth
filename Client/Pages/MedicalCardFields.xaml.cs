using Client.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MedicalCardFields.xaml
    /// </summary>
    public partial class MedicalCardFields : Page
    {
        MedicalCard contextMedicalCard;
        public MedicalCardFields(MedicalCard medicalCard)
        {
            InitializeComponent();
            contextMedicalCard = medicalCard;
            DataContext = contextMedicalCard;
            CbGender.ItemsSource = App.DB.Gender.ToList();
            contextMedicalCard.DateOfBirth = DateTime.Today;
        }

        private void BackBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextMedicalCard.FirstName))
            {
                errorMessage += "Введите имя\n";
            }
            if (string.IsNullOrWhiteSpace(contextMedicalCard.LastName))
            {
                errorMessage += "Введите фамилию\n";
            }
            if (string.IsNullOrWhiteSpace(contextMedicalCard.Patronymic))
            {
                errorMessage += "Введите отчество\n";
            }
            if (contextMedicalCard.Height <= 0)
            {
                errorMessage += "Введите корректный рост\n";
            }
            if (contextMedicalCard.Weight <= 0)
            {
                errorMessage += "Введите корректный вес\n";
            }
            if (contextMedicalCard.Gender == null)
            {
                errorMessage += "Выберите пол\n";
            }
            if (contextMedicalCard.DateOfBirth >= DateTime.Today)
            {
                errorMessage += "Выберите корректную дату\n";
            }
            if (string.IsNullOrEmpty(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (contextMedicalCard.Id == 0)
            {
                contextMedicalCard.UserId = App.LoggedUser.Id;
                App.DB.MedicalCard.Add(contextMedicalCard);
                App.DB.BodyHealth.Add(new BodyHealth
                {
                    HeadHp = 35,
                    TorsoHp = 85,
                    StomachHp = 70,
                    LeftHandHp = 60,
                    RightHandHp = 60,
                    LeftLegHp = 65,
                    RightLegHp = 65,
                    UserId = App.LoggedUser.Id
                });
            }
            App.DB.SaveChanges();
            NavigationService.GoBack();
            MessageBox.Show("Медицинская карта успешно заполнена!");
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            contextMedicalCard.FirstName = null;
            TbName.Clear();
            contextMedicalCard.LastName = null;
            TbSurname.Clear();
            contextMedicalCard.Patronymic = null;
            TbPatronymic.Clear();
            contextMedicalCard.Height = 0;
            TbHeight.Text = 0.ToString();
            contextMedicalCard.Weight = 0;
            TbWeight.Text = 0.ToString();
            contextMedicalCard.Gender = null;
            CbGender.SelectedItem = null;
            contextMedicalCard.DateOfBirth = DateTime.Today;
            DtDateOfBirth.SelectedDate = DateTime.Today;

        }
        private void NoneSpaceBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[0-9]") == false)
            {
                e.Handled = true;
            }
        }
    }
}
