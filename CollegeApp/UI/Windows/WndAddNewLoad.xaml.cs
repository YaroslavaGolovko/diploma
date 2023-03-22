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
    /// Логика взаимодействия для WndAddNewLoad.xaml
    /// </summary>
    public partial class WndAddNewLoad : Window
    {
        private List<SubjectSemester> semesters;
        private string specialityId;
        private int qualificationId;
        private int startYear;
        private string academicYear;
        public WndAddNewLoad(List<Subject> subjects, string specialityId, int qualificationId, int startYear, string academicYear)
        {
            InitializeComponent();
            this.specialityId = specialityId;
            this.qualificationId = qualificationId;
            this.startYear = startYear;
            this.academicYear = academicYear;
            cmbSubjects.ItemsSource = subjects;
            cmbProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
            int cours = Int32.Parse(academicYear.Substring(0, 4)) - startYear;
            switch (cours)
            {
                case 0:
                    cbFirstSemester.Content = "1 семестр";
                    cbSecondSemester.Content = "2 семестр";
                    break;

                case 1:
                    cbFirstSemester.Content = "3 семестр";
                    cbSecondSemester.Content = "4 семестр";
                    break;

                case 2:
                    cbFirstSemester.Content = "5 семестр";
                    cbSecondSemester.Content = "6 семестр";
                    break;

                case 3:
                    cbFirstSemester.Content = "7 семестр";
                    cbSecondSemester.Content = "8 семестр";
                    break;
            }
        }

        private void cmbSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cmbProfessors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void SetEnabledButton()
        {
            if (cmbProfessors.SelectedItem != null && (cbFirstSemester.IsChecked==true || cbSecondSemester.IsChecked==true) && cmbSubjects.SelectedItem!=null)
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
            Subject selectedSubject = cmbSubjects.SelectedItem as Subject;
            string subjectName = selectedSubject.Name;
            Professor selectedProfessor = cmbProfessors.SelectedItem as Professor;
            int professorId = selectedProfessor.Id;
            semesters = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpeciality.SpecialityId == specialityId && s.SubjectSpeciality.QualificationId == qualificationId && s.SubjectSpeciality.StartYear == startYear && s.Syllabu.AcademicYear == academicYear).ToList();
            foreach (var semester in semesters)
            {
                if(CollegeBaseEntities.GetContext().SubjectProfessors.Where(s => s.ProfessorId == professorId && s.SubjectSemesterId == semester.Id).FirstOrDefault() != null)
                {
                    return;
                }
                else
                {
                    if (semester.Semester == 1 && cbFirstSemester.IsChecked == true && semester.SubjectSpeciality.Subject.Name == subjectName)
                    {
                        SubjectProfessor load = new SubjectProfessor();
                        load.SubjectSemesterId = semester.Id;
                        load.ProfessorId = professorId;
                        CollegeBaseEntities.GetContext().SubjectProfessors.Add(load);
                        CollegeBaseEntities.GetContext().SaveChanges();
                    }
                    if (semester.Semester == 2 && cbSecondSemester.IsChecked == true && semester.SubjectSpeciality.Subject.Name == subjectName)
                    {
                        SubjectProfessor load = new SubjectProfessor();
                        load.SubjectSemesterId = semester.Id;
                        load.ProfessorId = professorId;
                        CollegeBaseEntities.GetContext().SubjectProfessors.Add(load);
                        CollegeBaseEntities.GetContext().SaveChanges();
                    }
                }
            }
            MessageBox.Show("Нагрузка добавлена!","Успешное добавление",MessageBoxButton.OK,MessageBoxImage.Information);
            btnSave.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbSecondSemester_Unchecked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cbSecondSemester_Checked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cbFirstSemester_Checked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cbFirstSemester_Unchecked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewSubject window = new WndAddNewSubject();
            window.ShowDialog();
        }

        private void btnAddProfessor_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditProfessor window = new WndAddEditProfessor(null);
            window.ShowDialog();
            cmbProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
        }
    }
}
