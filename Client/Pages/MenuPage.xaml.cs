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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            MenuFrame.Navigate(new ProfilePage(App.LoggedUser.BodyHealth.FirstOrDefault()));
        }

        private void MedCardBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuFrame.Navigate(new PatientCard(App.LoggedUser.MedicalCard.FirstOrDefault()));
        }

        private void ListQuestionBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuFrame.Navigate(new MedicalTestView(App.DB.MedicalTest.FirstOrDefault()));
        }

        private void HealthCheckBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuFrame.Navigate(new ProfilePage(App.LoggedUser.BodyHealth.FirstOrDefault()));
        }
    }
}
