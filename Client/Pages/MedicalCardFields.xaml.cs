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
        }

        private void BackBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            contextMedicalCard.FirstName = null;
            contextMedicalCard.LastName = null;
            contextMedicalCard.Patronymic = null;
            contextMedicalCard.Height = 0;
            contextMedicalCard.Weight = 0;
            contextMedicalCard.Gender = null;
            contextMedicalCard.DateOfBirth = DateTime.Today;

        }

        private void NoneSpaceBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
