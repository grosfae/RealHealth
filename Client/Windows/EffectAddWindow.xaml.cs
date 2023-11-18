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
using System.Windows.Shapes;

namespace Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для EffectAddWindow.xaml
    /// </summary>
    public partial class EffectAddWindow : Window
    {
        public EffectAddWindow()
        {
            InitializeComponent();
            CheckEffects();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as Button).DataContext as Effect;
            if(selectedItem == null)
            {
                return;   
            }
            App.DB.BodyHealthEffect.Add(new BodyHealthEffect
            {
                BodyHealth = App.LoggedUser.BodyHealth.FirstOrDefault(),
                Effect = selectedItem
            });
            App.DB.SaveChanges();
            CheckEffects();
        }
        private void CheckEffects()
        {
            List<Effect> effects = new List<Effect>();
            foreach(var effect in App.DB.Effect)
            {
                var bodyHealths = App.DB.BodyHealthEffect.Where(x => x.BodyHealth.User.Id == App.LoggedUser.Id);
                if(!bodyHealths.Any(x => x.EffectId == effect.Id))
                {
                    effects.Add(effect);
                }
            }
            LvEffects.ItemsSource = effects.ToList();
        }
    }
}
