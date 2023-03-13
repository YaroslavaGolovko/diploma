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

namespace CollegeApp.UI
{
    /// <summary>
    /// Логика взаимодействия для WndAddSubject.xaml
    /// </summary>
    public partial class WndAddSubject : Window
    {
        private string _currentSpecialityId;
        private int _currentPlanId;
        private int _currentQualificationId;
        private int _currentSemester;
        private List<Syllabu> _currentPlans;
        private bool isShown = false;
        private string index;
        private string qty;
        public WndAddSubject(int planId,string specialityId, int qualificationId)
        {
            InitializeComponent();
            _currentSpecialityId = specialityId;
            _currentPlanId = planId;
            _currentQualificationId = qualificationId;
            var subjects = CollegeBaseEntities.GetContext().Subjects.ToList();
            cmbSubjects.ItemsSource = subjects;
            var categories = CollegeBaseEntities.GetContext().SubjectCategories.ToList();
            cmbCategories.ItemsSource = categories;
            var plan = CollegeBaseEntities.GetContext().Syllabus.Where(s => s.Id == _currentPlanId).FirstOrDefault();
            if (plan != null)
            {
                _currentPlans = CollegeBaseEntities.GetContext().Syllabus.Where(s=>s.AcademicYear==plan.AcademicYear && s.Group.StartYear==plan.Group.StartYear && s.Group.SpecialityId==_currentSpecialityId && s.Group.QualificationId==_currentQualificationId).ToList();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isShown = false;
                if (_currentPlans != null)
                {
                    foreach (Syllabu item in _currentPlans)
                    {
                        var startYear = item.Group.StartYear;
                        var selectedCategory = cmbCategories.SelectedItem as SubjectCategory;
                        string categoryId = selectedCategory.Id;
                        var selectedSubject = cmbSubjects.SelectedItem as Subject;
                        int subjectId = selectedSubject.Id;
                        var _currentSubject = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s => s.SpecialityId == _currentSpecialityId && s.StartYear == startYear && s.QualificationId == _currentQualificationId && s.CategoryId == categoryId && s.SubjectId == subjectId && s.IndexName == index).FirstOrDefault();
                        if (_currentSubject == null)
                        {
                            SubjectSpeciality subject = new SubjectSpeciality();
                            subject.SpecialityId = _currentSpecialityId;
                            subject.SubjectId = subjectId;
                            subject.CategoryId = categoryId;
                            subject.IndexName = index;
                            subject.QualificationId = _currentQualificationId;
                            subject.StartYear = startYear;
                            CollegeBaseEntities.GetContext().SubjectSpecialities.Add(subject);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                        _currentSubject = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s => s.SpecialityId == _currentSpecialityId && s.StartYear == startYear && s.QualificationId == _currentQualificationId && s.CategoryId == categoryId && s.SubjectId == subjectId && s.IndexName == index).FirstOrDefault();
                        int _currentId = _currentSubject.Id;
                        SubjectSemester selectedSemester = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpecialityId == _currentId && s.Semester == _currentSemester && s.SyllabusId == _currentPlanId).FirstOrDefault();
                        if (selectedSemester == null)
                        {
                            SubjectSemester semester = new SubjectSemester();
                            semester.SubjectSpecialityId = _currentSubject.Id;
                            semester.SyllabusId = item.Id;
                            semester.Semester = _currentSemester;
                            semester.TotalQtyHours = Int32.Parse(qty);
                            CollegeBaseEntities.GetContext().SubjectSemesters.Add(semester);
                            CollegeBaseEntities.GetContext().SaveChanges();
                            if (isShown == false)
                            {
                                MessageBox.Show("Дисциплина успешно добавлена в учебный план!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                                btnSave.IsEnabled = false;
                                isShown = true;
                            }
                        }
                        else
                        {
                            if (isShown == false)
                            {
                                MessageBox.Show("Данная дисциплина уже добавлена в учебный план.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                                isShown = true;
                            }
                        }
                    }
                    if (isShown == true)
                    {
                        this.Close();
                    }
                }
            }

            catch(Exception ex)
            {
                if (isShown == false)
                {
                    MessageBox.Show("При добавлении дисциплины возникли неполадки. Проверьте вводимые данные, а также наличие добавляемой дисциплины в учебном плане.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    btnSave.IsEnabled = true;
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cmbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void tbIndex_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
            index = tbIndex.Text;
        }

        private void cmbSemesters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
            if (cmbSemesters.SelectedIndex==0 || cmbSemesters.SelectedIndex == 2 || cmbSemesters.SelectedIndex == 4 || cmbSemesters.SelectedIndex==6)
            {
                _currentSemester = 1;
            }
            else
            {
                _currentSemester = 2;
            }
        }

        private void tbTotalQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
            qty = tbTotalQty.Text;
        }

        private void SetEnabledButton()
        {
            if(cmbSubjects.SelectedItem!=null && cmbCategories.SelectedItem != null && cmbSemesters.SelectedItem != null && tbIndex.Text.Length>0 && tbTotalQty.Text.Length > 0)
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
