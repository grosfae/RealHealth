using Client.Components;
using Client.Windows;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        BodyHealth contextBody;
        public ProfilePage(BodyHealth bodyHealth)
        {
            InitializeComponent();
            contextBody = bodyHealth;
            DataContext = contextBody;
            LvEffects.ItemsSource = App.LoggedUser.BodyHealth.FirstOrDefault().BodyHealthEffect.ToList();

        }

        private void EffectAddBtn_Click(object sender, RoutedEventArgs e)
        {
            EffectAddWindow effectWindow = new EffectAddWindow();
            effectWindow.ShowDialog();
            DataContext = null;
            DataContext = contextBody;
            LvEffects.ItemsSource = App.LoggedUser.BodyHealth.FirstOrDefault().BodyHealthEffect.ToList();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as Button).DataContext as BodyHealthEffect;
            if (selectedItem == null)
            {
                return;
            }
            App.DB.BodyHealthEffect.Remove(selectedItem);
            App.DB.SaveChanges();
            LvEffects.ItemsSource = App.LoggedUser.BodyHealth.FirstOrDefault().BodyHealthEffect.ToList();
            DataContext = null;
            DataContext = contextBody;
        }

    }
}
