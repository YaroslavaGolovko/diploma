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
    /// Логика взаимодействия для WndAddNewDocument.xaml
    /// </summary>
    public partial class WndAddNewDocument : Window
    {
        private string specialityId;
        private int qualificationId;
        private int startYear;
        private string academicYear;
        public WndAddNewDocument(string specialityId, int qualificationId, int startYear, string academicYear)
        {
            InitializeComponent();
            this.specialityId = specialityId;
            this.qualificationId = qualificationId;
            this.startYear = startYear;
            this.academicYear = academicYear;
            cmbProfessors.ItemsSource = CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
            List<SubjectSemester> subjects = new List<SubjectSemester>();
            var allSubjects = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpeciality.SpecialityId == specialityId && s.SubjectSpeciality.QualificationId == qualificationId && s.Syllabu.Group.StartYear == startYear && s.Syllabu.AcademicYear == academicYear).ToList();
            foreach(var subject in allSubjects)
            {
                if(subjects.Where(s=>s.SubjectSpeciality.Subject.Name==subject.SubjectSpeciality.Subject.Name).FirstOrDefault() == null)
                {
                    subjects.Add(subject);
                }
            }
            subjects = subjects.OrderBy(s => s.SubjectSpeciality.Subject.Name).ToList();
            cmbSubjects.ItemsSource = subjects;
        }

        private void cmbProfessors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cmbSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isShow = false;
                var selectedProfessor = cmbProfessors.SelectedItem as Professor;
                int professorId = selectedProfessor.Id;
                var selectedSubject = cmbSubjects.SelectedItem as SubjectSemester;
                int subjectId = selectedSubject.SubjectSpeciality.SubjectId;
                var items = CollegeBaseEntities.GetContext().SubjectProfessors.
                    Where(s => s.SubjectSemester.SubjectSpeciality.SpecialityId == specialityId 
                    && s.SubjectSemester.SubjectSpeciality.QualificationId == qualificationId 
                    && s.SubjectSemester.Syllabu.Group.StartYear == startYear && s.SubjectSemester.Syllabu.AcademicYear 
                    == academicYear && s.SubjectSemester.SubjectSpeciality.SubjectId==subjectId && s.ProfessorId==professorId).ToList();
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        int subjectProfessorId = item.Id;
                        if (CollegeBaseEntities.GetContext().Documents.
                            Where(d => d.SubjectProfessorId == subjectProfessorId).FirstOrDefault() == null)
                        {
                            Document document = new Document();
                            document.SubjectProfessorId = item.Id;
                            document.Note = null;
                            CollegeBaseEntities.GetContext().Documents.Add(document);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                        else
                        {
                            isShow = true;
                            MessageBox.Show("Документ уже добавлен.", 
                                "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        CollegeBaseEntities.GetContext().SaveChanges();
                    }
                    CollegeBaseEntities.GetContext().SaveChanges();
                    if(isShow==false)
                        MessageBox.Show("Документ успешно добавлен!",
                            "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnSave.IsEnabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Во время добавления документа произошли неполадки. " +
                    "Повторите попытку позже.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetEnabledButton()
        {
            if(cmbProfessors.SelectedItem!=null && cmbSubjects.SelectedItem != null)
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
