using Admin.Components;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Admin.Pages
{
    /// <summary>
    /// Логика взаимодействия для EffectEditPage.xaml
    /// </summary>
    public partial class EffectEditPage : Page
    {
        Effect contextEffect;
        public EffectEditPage(Effect effect)
        {
            InitializeComponent();
            contextEffect = effect;
            DataContext = contextEffect;
            CbHealingMethod.ItemsSource = App.DB.HealingMethod.ToList();
        }

        private void ImageAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png|*.jpeg|*.jpeg"
            };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                contextEffect.MainIcon = File.ReadAllBytes(dialog.FileName);
                DataContext = null;
                DataContext = contextEffect;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            if (string.IsNullOrWhiteSpace(contextEffect.Name))
            {
                errorMessage += "Заполните название!\n";
            }
            if (string.IsNullOrWhiteSpace(contextEffect.Description))
            {
                errorMessage += "Заполните описание!\n";
            }
            if (contextEffect.HealingMethod == null)
            {
                errorMessage += "Выберите метод лечения!\n";
            }
            if (contextEffect.HeadHpDecrease < 0 || contextEffect.HeadHpDecrease > 35)
            {
                errorMessage += "Введите корректный урон по голове!\n";
            }
            if (contextEffect.TorsoHpDecrease < 0 || contextEffect.TorsoHpDecrease > 80)
            {
                errorMessage += "Введите корректный урон по грудной клетке!\n";
            }
            if (contextEffect.StomachHpDecrease < 0 || contextEffect.StomachHpDecrease > 70)
            {
                errorMessage += "Введите корректный урон по животу!\n";
            }
            if (contextEffect.LeftHandHpDecrease < 0 || contextEffect.LeftHandHpDecrease > 60)
            {
                errorMessage += "Введите корректный урон по левой руке!\n";
            }
            if (contextEffect.RightHandHpDecrease < 0 || contextEffect.RightHandHpDecrease > 60)
            {
                errorMessage += "Введите корректный урон по правой руке!\n";
            }
            if (contextEffect.LeftLegHpDecrease < 0 || contextEffect.LeftLegHpDecrease > 65)
            {
                errorMessage += "Введите корректный урон по левой ноге!\n";
            }
            if (contextEffect.RightLegHpDecrease < 0 || contextEffect.RightLegHpDecrease > 65)
            {
                errorMessage += "Введите корректный урон по правой ноге!\n";
            }
            if (string.IsNullOrEmpty(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            MessageBox.Show("Сохранение успешно!");
            NavigationService.GoBack();
            
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
