using CollegeApp.Entities;
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

namespace CollegeApp.UC
{
    /// <summary>
    /// Логика взаимодействия для UCSubject.xaml
    /// </summary>
    public partial class UCSubject : UserControl
    {
        private Subject subject;
        public UCSubject()
        {
            InitializeComponent();
        }
        public UCSubject(Subject subject)
        {
            InitializeComponent();
            this.subject = subject;
        }

        private void btnDeleteSubject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы точно хотите удалить данную дисциплину?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Subject selectedSubject = (sender as Button).DataContext as Subject;
                    CollegeBaseEntities.GetContext().Subjects.Remove(selectedSubject);
                    CollegeBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Дисциплина успешно удалена!", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Classes.Control.DGridSubjects.ItemsSource = CollegeBaseEntities.GetContext().Subjects.ToList();
                }
            }
            catch
            {
                MessageBox.Show("При удалении дисциплины возникли неполадки. Проверьте, чтобы по дисциплине отсутствовала нагрузка, и повторите попытку позже.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
