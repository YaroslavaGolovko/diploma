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
    /// Логика взаимодействия для WndAddEditLoad.xaml
    /// </summary>
    public partial class WndAddEditLoad : Window
    {
        private LoadRow _currentRow;
        public WndAddEditLoad(LoadRow selectedRow)
        {
            InitializeComponent();
            _currentRow = selectedRow;
            DataContext = _currentRow;
            tblSubject.Text = "Дисциплина: " + _currentRow.SubjectName;
            cmbProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
            if (_currentRow.ProfessorId > 0)
            {
                Professor professor = CollegeBaseEntities.GetContext().Professors.Where(p => p.Id == _currentRow.ProfessorId).FirstOrDefault();
                cmbProfessors.SelectedItem = professor;
                tblName.Text = "Редактирование нагрузки";
            }
        }

        private void cmbProfessors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbProfessors.SelectedItem != null)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var semesters = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpecialityId == _currentRow.SubjectSpecialityId && s.Semester == _currentRow.Semester).ToList();
            foreach(var semester in semesters)
            {
                var selectedLoad = CollegeBaseEntities.GetContext().SubjectProfessors.Where(s => s.SubjectSemesterId == semester.Id && s.ProfessorId==_currentRow.ProfessorId).FirstOrDefault();
                if (selectedLoad == null)
                {
                    SubjectProfessor load = new SubjectProfessor();
                    load.SubjectSemesterId = semester.Id;
                    Professor professor = cmbProfessors.SelectedItem as Professor;
                    int id = professor.Id;
                    load.ProfessorId = id;
                    CollegeBaseEntities.GetContext().SubjectProfessors.Add(load);
                    CollegeBaseEntities.GetContext().SaveChanges();
                }
                else
                {
                    Professor professor = cmbProfessors.SelectedItem as Professor;
                    int id = professor.Id;
                    selectedLoad.ProfessorId = id;
                    CollegeBaseEntities.GetContext().SaveChanges();
                }
            }
            MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditProfessor window = new WndAddEditProfessor(null);
            window.ShowDialog();
            cmbProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
        }
    }
}
