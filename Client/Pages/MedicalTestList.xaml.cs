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
    /// Логика взаимодействия для MedicalTestList.xaml
    /// </summary>
    public partial class MedicalTestList : Page
    {
        public MedicalTestList()
        {
            InitializeComponent();
            LvMedicalTests.ItemsSource = App.DB.MedicalTest.ToList();
        }

        private void ViewTestBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as Button).DataContext as MedicalTest;
            NavigationService.Navigate(new MedicalTestView(selectedItem));
        }
    }
}
