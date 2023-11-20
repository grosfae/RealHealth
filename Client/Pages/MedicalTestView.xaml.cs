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
    /// Логика взаимодействия для MedicalTestView.xaml
    /// </summary>
    public partial class MedicalTestView : Page
    {
        MedicalTest contextTest;

        public List<MedicalAnswer> medicalAnswers = new List<MedicalAnswer>();
        public MedicalTestView(MedicalTest medicalTest)
        {
            InitializeComponent();
            contextTest = medicalTest;
            DataContext = contextTest;
            LvQuestions.ItemsSource = contextTest.MedicalQuestion;

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AnswerBtn_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;

            foreach(var item in medicalAnswers)
            {
                result += item.Score;
            }

            TbAnswer.Text = contextTest.MedicalScore.FirstOrDefault(x => x.MinScore <= result && x.MaxScore >= result).FullName;

            LvQuestions.IsEnabled = false;
            AnswerBtn.Visibility = Visibility.Collapsed;
            BackBtn.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ComboBox).SelectedItem as MedicalAnswer;
            if(selectedItem == null)
            {
                return;
            }
            if(medicalAnswers.Count(x => x.MedicalQuestionId == selectedItem.MedicalQuestionId) > 0)
            {
                medicalAnswers.Remove(medicalAnswers.FirstOrDefault(x => x.MedicalQuestionId == selectedItem.MedicalQuestionId));
            }
            medicalAnswers.Add(selectedItem);
        }
    }
}
