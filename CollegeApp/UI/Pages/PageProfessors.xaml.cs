using CollegeApp.Entities;
using CollegeApp.UI.Windows;
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

namespace CollegeApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProfessors.xaml
    /// </summary>
    public partial class PageProfessors : Page
    {
        public PageProfessors()
        {
            InitializeComponent();
            DGridProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p=>p.LastName).ThenBy(p=>p.FirstName).ThenBy(p=>p.Patronymic).ToList();
        }

        private void btnAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditProfessor window = new WndAddEditProfessor(null);
            window.ShowDialog();
            DGridProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
        }

        private void btnDeleteProfessor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы точно хотите удалить данного преподавателя?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Professor professor = (sender as Button).DataContext as Professor;
                    CollegeBaseEntities.GetContext().Professors.Remove(professor);
                    CollegeBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                    DGridProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При удалении произошли неполадки, необходимо удалить учебную нагрузку преподавателя и повторить попытку.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdateProfessor_Click(object sender, RoutedEventArgs e)
        {
            Professor selectedProfessor = (sender as Button).DataContext as Professor;
            WndAddEditProfessor window = new WndAddEditProfessor(selectedProfessor);
            window.ShowDialog();
            DGridProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
        }
    }
}
