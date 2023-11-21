using Admin.Components;
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
        }

        private void ImageAddBtn_Click(object sender, RoutedEventArgs e)
        {

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
                errorMessage += "Введите корректный урон головы!\n";
            }
            if (contextEffect.TorsoHpDecrease < 0 || contextEffect.TorsoHpDecrease > 80)
            {
                errorMessage += "Введите корректный урон грудной клетки!\n";
            }
            if (contextEffect.StomachHpDecrease < 0 || contextEffect.StomachHpDecrease > 70)
            {
                errorMessage += "Введите корректный урон живота!\n";
            }
            if (contextEffect.LeftHandHpDecrease < 0 || contextEffect.LeftHandHpDecrease > 60)
            {
                errorMessage += "Введите корректный урон голове!\n";
            }
            if (string.IsNullOrEmpty(errorMessage) == false)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            MessageBox.Show("Сохранение успешно!");
            NavigationService.GoBack();
            
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
