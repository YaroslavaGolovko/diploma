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
using System.Windows.Shapes;

namespace CollegeApp.UI.Windows
{
    /// <summary>
    /// Логика взаимодействия для WndAddEditProfessor.xaml
    /// </summary>
    public partial class WndAddEditProfessor : Window
    {
        private Professor _currentProfessor;
        public WndAddEditProfessor(Professor selectedProfessor)
        {
            InitializeComponent();
            tbLastName.Focus();
            if(selectedProfessor != null)
            {
                tblName.Text = "Редактирование преподавателя";
                _currentProfessor = selectedProfessor;
                DataContext = _currentProfessor;
            }
            else
            {
                _currentProfessor = new Professor();
                DataContext = _currentProfessor;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentProfessor.LastName = tbLastName.Text;
                _currentProfessor.FirstName = tbFirstName.Text;
                _currentProfessor.Patronymic = tbPatronymic.Text;
                if (CollegeBaseEntities.GetContext().Professors.Where(p => p.LastName == _currentProfessor.LastName 
                && p.FirstName==_currentProfessor.FirstName && p.Patronymic==_currentProfessor.Patronymic).FirstOrDefault() != null)
                {
                    MessageBox.Show("Данный преподаватель уже добавлен!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (_currentProfessor.Id == 0)
                {
                    CollegeBaseEntities.GetContext().Professors.Add(_currentProfessor);
                }
                CollegeBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("При сохранении данных возникли неполадки. Проверьте вводимые данные.", 
                    "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void tbFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void tbPatronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void SetEnabledButton()
        {
            if (tbLastName.Text.Length > 0 && tbFirstName.Text.Length > 0 && tbPatronymic.Text.Length > 0)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }
    }
}
