using CollegeApp.Entities;
using Microsoft.Office.Interop.Word;
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
    public partial class WndAddSubject : System.Windows.Window
    {
        private string _currentSpecialityId;
        private int _currentPlanId;
        private int _currentQualificationId;
        private List<Syllabu> _currentPlans;
        private bool isShown = false;
        private int index;
        private string qty;
        public WndAddSubject(int planId,string specialityId, int qualificationId,int firstSemester, int secondSemester)
        {
            InitializeComponent();
            cbFirstSemester.Content = firstSemester + " семестр";
            cbSecondSemester.Content = secondSemester + " семестр";
            _currentSpecialityId = specialityId;
            _currentPlanId = planId;
            _currentQualificationId = qualificationId;
            var subjects = CollegeBaseEntities.GetContext().Subjects.OrderBy(s=>s.Name).ToList();
            cmbSubjects.ItemsSource = subjects;
            var categories = CollegeBaseEntities.GetContext().SubjectCategories.ToList();
            cmbCategories.ItemsSource = categories;
            var indexes = CollegeBaseEntities.GetContext().SubjectIndexes.OrderBy(s=>s.Name).ToList();
            cmbIndexes.ItemsSource = indexes;
            var plan = CollegeBaseEntities.GetContext().Syllabus.Where(s => s.Id == _currentPlanId).FirstOrDefault();
            if (plan != null)
            {
                _currentPlans = CollegeBaseEntities.GetContext().Syllabus.Where(s=>s.AcademicYear==plan.AcademicYear && s.Group.StartYear==plan.Group.StartYear && s.Group.SpecialityId==_currentSpecialityId && s.Group.QualificationId==_currentQualificationId).ToList();
            }
        }

        private void AddSubjectSpeciality(int subjectId, int categoryId, int startYear)
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
                        int categoryId = selectedCategory.Id;
                        var selectedSubject = cmbSubjects.SelectedItem as Subject;
                        int subjectId = selectedSubject.Id;
                        var _currentSubject = CollegeBaseEntities.GetContext().SubjectSpecialities.
                            Where(s => s.SpecialityId == _currentSpecialityId && s.StartYear == startYear 
                            && s.QualificationId == _currentQualificationId && s.CategoryId == categoryId 
                            && s.SubjectId == subjectId && s.IndexName == index).FirstOrDefault();
                        if (_currentSubject == null)
                        {
                            AddSubjectSpeciality(subjectId, categoryId, startYear);
                        }
                        _currentSubject = CollegeBaseEntities.GetContext().SubjectSpecialities.
                            Where(s => s.SpecialityId == _currentSpecialityId && s.StartYear == startYear 
                            && s.QualificationId == _currentQualificationId && s.CategoryId == categoryId 
                            && s.SubjectId == subjectId && s.IndexName == index).FirstOrDefault();
                        int _currentId = _currentSubject.Id;
                        if (cbFirstSemester.IsChecked == true)
                        {
                            SubjectSemester selectedSemester = CollegeBaseEntities.GetContext().SubjectSemesters.
                                Where(s => s.SubjectSpecialityId == _currentId && s.Semester == 1 
                                && s.SyllabusId == _currentPlanId).FirstOrDefault();
                            if (selectedSemester == null)
                            {
                                SubjectSemester semester = new SubjectSemester();
                                semester.SubjectSpecialityId = _currentSubject.Id;
                                semester.SyllabusId = item.Id;
                                semester.Semester = 1;
                                semester.TotalQtyHours = Int32.Parse(qty);
                                CollegeBaseEntities.GetContext().SubjectSemesters.Add(semester);
                                CollegeBaseEntities.GetContext().SaveChanges();
                                if (isShown == false)
                                {
                                    MessageBox.Show("Дисциплина успешно добавлена в учебный план!", 
                                        "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                                    btnSave.IsEnabled = false;
                                    isShown = true;
                                }
                            }
                            else
                            {
                                if (isShown == false)
                                {
                                    MessageBox.Show("Данная дисциплина уже добавлена в учебный план.", 
                                        "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                                    isShown = true;
                                }
                            }
                        }
                        if (cbSecondSemester.IsChecked == true)
                        {
                            SubjectSemester selectedSemester = CollegeBaseEntities.GetContext().SubjectSemesters.
                                Where(s => s.SubjectSpecialityId == _currentId && s.Semester == 2 && s.SyllabusId == _currentPlanId).FirstOrDefault();
                            if (selectedSemester == null)
                            {
                                SubjectSemester semester = new SubjectSemester();
                                semester.SubjectSpecialityId = _currentSubject.Id;
                                semester.SyllabusId = item.Id;
                                semester.Semester = 2;
                                semester.TotalQtyHours = Int32.Parse(qty);
                                CollegeBaseEntities.GetContext().SubjectSemesters.Add(semester);
                                CollegeBaseEntities.GetContext().SaveChanges();
                                if (isShown == false)
                                {
                                    MessageBox.Show("Дисциплина успешно добавлена в учебный план!", 
                                        "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                                    btnSave.IsEnabled = false;
                                    isShown = true;
                                }
                            }
                            else
                            {
                                if (isShown == false)
                                {
                                    MessageBox.Show("Данная дисциплина уже добавлена в учебный план.", 
                                        "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                                    isShown = true;
                                }
                            }
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                if (isShown == false)
                {
                    MessageBox.Show("При добавлении дисциплины возникли неполадки. " +
                        "Проверьте вводимые данные, а также наличие добавляемой дисциплины в учебном плане.", 
                        "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void tbTotalQty_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
            qty = tbTotalQty.Text;
        }

        private void SetEnabledButton()
        {
            if(cmbSubjects.SelectedItem!=null && cmbCategories.SelectedItem != null && (cbFirstSemester.IsChecked==true || cbSecondSemester.IsChecked==true) && cmbIndexes.SelectedItem!=null && tbTotalQty.Text.Length > 0)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void cmbIndexes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
            SubjectIndex selectedIndex = cmbIndexes.SelectedItem as SubjectIndex;
            index = selectedIndex.Id;
        }

        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditSubject window = new WndAddEditSubject(null);
            window.ShowDialog();
            var subjects = CollegeBaseEntities.GetContext().Subjects.OrderBy(s => s.Name).ToList();
            cmbSubjects.ItemsSource = subjects;
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewCategory window = new WndAddNewCategory();
            window.ShowDialog();
            var categories = CollegeBaseEntities.GetContext().SubjectCategories.ToList();
            cmbCategories.ItemsSource = categories;
        }

        private void btnAddIndex_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewIndex window = new WndAddNewIndex();
            window.ShowDialog();
            var indexes = CollegeBaseEntities.GetContext().SubjectIndexes.OrderBy(s => s.Name).ToList();
            cmbIndexes.ItemsSource = indexes;
        }

        private void cbFirstSemester_Checked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cbFirstSemester_Unchecked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cbSecondSemester_Checked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }

        private void cbSecondSemester_Unchecked(object sender, RoutedEventArgs e)
        {
            SetEnabledButton();
        }
    }
}
