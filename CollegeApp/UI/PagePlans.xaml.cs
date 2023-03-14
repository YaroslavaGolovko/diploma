using CollegeApp.Classes;
using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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

namespace CollegeApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PagePlans.xaml
    /// </summary>
    public partial class PagePlans : Page
    {
        private List<SubjectRow> _currentRows;
        private List<Qualification> qualifications;
        private List<Group> groups;
        private string specialityId;
        private Syllabu plan;
        private Syllabu _requiredPlan;
        int firstSemester;
        int secondSemester;
        public PagePlans()
        {
            InitializeComponent();
            var specialities = CollegeBaseEntities.GetContext().Specialities.ToList();
            cmbSpecialities.ItemsSource = specialities;
            qualifications = CollegeBaseEntities.GetContext().Qualifications.ToList();
            cmbQualifications.ItemsSource = qualifications;
            groups = CollegeBaseEntities.GetContext().Groups.ToList();
            cmbGroups.ItemsSource = groups;
            GetPlan();
        }

        private List<SubjectRow> GetRows(int planId)
        {
            _requiredPlan = CollegeBaseEntities.GetContext().Syllabus.Where(s => s.Id == planId).FirstOrDefault();
            specialityId = _requiredPlan.Group.SpecialityId;
            List<SubjectRow> rows = new List<SubjectRow>();
            var group = _requiredPlan.Group;
            var qualification = _requiredPlan.Group.Qualification;
            int qualificationId = qualification.Id;
            int startYear = group.StartYear;
            string academicYear = _requiredPlan.AcademicYear;
            var subjects = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s=>s.QualificationId==qualificationId && s.StartYear==startYear).ToList();
            foreach (var subject in subjects)
            {
                if (CollegeBaseEntities.GetContext().SubjectSemesters.Where(s =>s.SyllabusId == planId && s.SubjectSpecialityId==subject.Id).FirstOrDefault() != null)
                {
                    SubjectRow row = new SubjectRow();
                    row.IdSubjectSpeciality = subject.Id;
                    row.Index = subject.SubjectIndex.Name;
                    row.Name = subject.Subject.Name;
                    row.GroupNumber = group.Number;
                    var attestation = subject.Attestations.Where(a => a.Syllabu.GroupNumber == row.GroupNumber).ToList();
                    if (attestation != null)
                    {
                        var columnExam = attestation.Where(s => s.AttestationFormId == 1).FirstOrDefault();
                        if (columnExam != null)
                            row.Exam = columnExam.Qty;
                        var columnOffset = attestation.Where(s => s.AttestationFormId == 2).FirstOrDefault();
                        if (columnOffset != null)
                            row.Offset = columnOffset.Qty;
                        var columnDiffOffset = attestation.Where(s => s.AttestationFormId == 3).FirstOrDefault();
                        if (columnDiffOffset != null)
                            row.DiffOffset = columnDiffOffset.Qty;
                        var columnCourseProject = attestation.Where(s => s.AttestationFormId == 4).FirstOrDefault();
                        if (columnCourseProject != null)
                            row.CourseProject = columnCourseProject.Qty;
                        var columnCourseWork = attestation.Where(s => s.AttestationFormId == 5).FirstOrDefault();
                        if (columnCourseWork != null)
                            row.CourseWork = columnCourseWork.Qty;
                        var columnTestWork = attestation.Where(s => s.AttestationFormId == 6).FirstOrDefault();
                        if (columnTestWork != null)
                            row.TestWork = columnTestWork.Qty;
                        var columnOther = attestation.Where(s => s.AttestationFormId == 7).FirstOrDefault();
                        if (columnOther != null)
                            row.OtherAttestation = columnOther.Qty;
                    }
                    var plan = subject.SubjectSemesters.Where(s => s.SyllabusId == planId).ToList();
                    var firstSemester = plan.Where(s => s.Semester == 1).FirstOrDefault();
                    if (firstSemester != null)
                    {
                        var load = CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == firstSemester.Id).ToList();
                        if (load != null)
                        {
                            var columnMaxLoad = load.Where(s => s.LoadTypeId == 1).FirstOrDefault();
                            if (columnMaxLoad != null)
                                row.Semester1MaxLoad = columnMaxLoad.QtyHours;
                            var columnIndependentLoad = load.Where(s => s.LoadTypeId == 2).FirstOrDefault();
                            if (columnIndependentLoad != null)
                                row.Semester1IndependentLoad = columnIndependentLoad.QtyHours;
                            var columnConsultationLoad = load.Where(s => s.LoadTypeId == 3).FirstOrDefault();
                            if (columnConsultationLoad != null)
                                row.Semester1ConsultationLoad = columnConsultationLoad.QtyHours;
                            var columnNecessaryLoad = load.Where(s => s.LoadTypeId == 4).FirstOrDefault();
                            if (columnNecessaryLoad != null)
                                row.Semester1NecessaryLoad = columnNecessaryLoad.QtyHours;
                            var columnLectureLoad = load.Where(s => s.LoadTypeId == 5).FirstOrDefault();
                            if (columnLectureLoad != null)
                                row.Semester1LectureLoad = columnLectureLoad.QtyHours;
                            var columnPracticeLoad = load.Where(s => s.LoadTypeId == 6).FirstOrDefault();
                            if (columnPracticeLoad != null)
                                row.Semester1PracticeLoad = columnPracticeLoad.QtyHours;
                            var columnLabLoad = load.Where(s => s.LoadTypeId == 7).FirstOrDefault();
                            if (columnLabLoad != null)
                                row.Semester1LaboratoryLoad = columnLabLoad.QtyHours;
                            var columnSeminarLoad = load.Where(s => s.LoadTypeId == 8).FirstOrDefault();
                            if (columnSeminarLoad != null)
                                row.Semester1SeminarLoad = columnSeminarLoad.QtyHours;
                            var columnProjectionLoad = load.Where(s => s.LoadTypeId == 9).FirstOrDefault();
                            if (columnProjectionLoad != null)
                                row.Semester1ProjectionLoad = columnProjectionLoad.QtyHours;
                            var columnIndProjectLoad = load.Where(s => s.LoadTypeId == 10).FirstOrDefault();
                            if (columnIndProjectLoad != null)
                                row.Semester1IndProjectLoad = columnIndProjectLoad.QtyHours;
                        }
                    }
                    var secondSemester = plan.Where(s => s.Semester == 2).FirstOrDefault();
                    if (secondSemester != null)
                    {
                        var load = CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == secondSemester.Id).ToList();
                        if (load != null)
                        {
                            var columnMaxLoad = load.Where(s => s.LoadTypeId == 1).FirstOrDefault();
                            if (columnMaxLoad != null)
                                row.Semester2MaxLoad = columnMaxLoad.QtyHours;
                            var columnIndependentLoad = load.Where(s => s.LoadTypeId == 2).FirstOrDefault();
                            if (columnIndependentLoad != null)
                                row.Semester2IndependentLoad = columnIndependentLoad.QtyHours;
                            var columnConsultationLoad = load.Where(s => s.LoadTypeId == 3).FirstOrDefault();
                            if (columnConsultationLoad != null)
                                row.Semester2ConsultationLoad = columnConsultationLoad.QtyHours;
                            var columnNecessaryLoad = load.Where(s => s.LoadTypeId == 4).FirstOrDefault();
                            if (columnNecessaryLoad != null)
                                row.Semester2NecessaryLoad = columnNecessaryLoad.QtyHours;
                            var columnLectureLoad = load.Where(s => s.LoadTypeId == 5).FirstOrDefault();
                            if (columnLectureLoad != null)
                                row.Semester2LectureLoad = columnLectureLoad.QtyHours;
                            var columnPracticeLoad = load.Where(s => s.LoadTypeId == 6).FirstOrDefault();
                            if (columnPracticeLoad != null)
                                row.Semester2PracticeLoad = columnPracticeLoad.QtyHours;
                            var columnLabLoad = load.Where(s => s.LoadTypeId == 7).FirstOrDefault();
                            if (columnLabLoad != null)
                                row.Semester2LaboratoryLoad = columnLabLoad.QtyHours;
                            var columnSeminarLoad = load.Where(s => s.LoadTypeId == 8).FirstOrDefault();
                            if (columnSeminarLoad != null)
                                row.Semester2SeminarLoad = columnSeminarLoad.QtyHours;
                            var columnProjectionLoad = load.Where(s => s.LoadTypeId == 9).FirstOrDefault();
                            if (columnProjectionLoad != null)
                                row.Semester2ProjectionLoad = columnProjectionLoad.QtyHours;
                            var columnIndProjectLoad = load.Where(s => s.LoadTypeId == 10).FirstOrDefault();
                            if (columnIndProjectLoad != null)
                                row.Semester2IndProjectLoad = columnIndProjectLoad.QtyHours;
                        }
                    }

                    var subjectName = CollegeBaseEntities.GetContext().SubjectSpecialities.Where(s => s.SubjectIndex.Name == row.Index && s.SpecialityId == specialityId).FirstOrDefault();
                    if (subjectName != null)
                    {
                        var requiredRow = rows.Where(r => r.Index == row.Index && r.Name == row.Name).FirstOrDefault();
                        if (requiredRow == null)
                        {
                            if (CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpecialityId == row.IdSubjectSpeciality && s.Syllabu.AcademicYear == academicYear && s.SyllabusId == _requiredPlan.Id) != null)
                            {
                                rows.Add(row);
                            }
                        }
                    }
                }
            }
            return rows;
        }

        private void cmbSpecialities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbQualifications.ItemsSource = qualifications.Where(q => q.Speciality == cmbSpecialities.SelectedItem as Speciality).ToList();
            cmbGroups.ItemsSource = groups.Where(g => g.Speciality == cmbSpecialities.SelectedItem as Speciality).ToList();
            GetPlan();
        }

        private void cmbQualifications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbGroups.ItemsSource = groups.Where(g => g.Qualification == cmbQualifications.SelectedItem as Qualification).ToList();
            GetPlan();
        }

        private void cmbStartYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbGroups.ItemsSource = groups.Where(g => g.StartYear.ToString()==cmbStartYear.SelectedItem as string).ToList();
            GetPlan();
        }

        private void cmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPlan();
        }

        private void GetPlan()
        {
            var filteredGroups = groups;
            var filteredQualification = qualifications;
            int qualificationId;
            int selectedStartYear;
            string selectedAcademicYear = "";
            int selectedGroupNumber = 0;
            if (cmbSpecialities.SelectedItem !=null)
            {
                Speciality selectedSpeciality = cmbSpecialities.SelectedItem as Speciality;
                specialityId = selectedSpeciality.Id;
                filteredGroups = groups.Where(g => g.SpecialityId == specialityId).ToList();
                filteredQualification = qualifications.Where(q => q.SpecialityId == specialityId).ToList();
                cmbQualifications.ItemsSource = filteredQualification;
                cmbGroups.ItemsSource = filteredGroups;
            }
            else
            {
                cmbQualifications.ItemsSource = qualifications;
                cmbGroups.ItemsSource = groups;
            }
            if (cmbQualifications.SelectedItem!=null)
            {
                Qualification selectedQualification = cmbQualifications.SelectedItem as Qualification;
                qualificationId = selectedQualification.Id;
                filteredGroups = groups.Where(g => g.QualificationId == qualificationId).ToList();
                cmbGroups.ItemsSource = filteredGroups;
            }
            if (cmbStartYear.SelectedItem!=null)
            {
                var selectedYear = cmbStartYear.SelectedItem as TextBlock;
                string text = selectedYear.Text.ToString();
                selectedStartYear = Int32.Parse(text);
                var currentGroups = cmbGroups.ItemsSource as List<Group>;
                filteredGroups = currentGroups.Where(g => g.StartYear == selectedStartYear).ToList();
                cmbGroups.ItemsSource = filteredGroups;
            }
            if (cmbAcademicYear.SelectedItem!=null)
            {
                var selectedYear = cmbAcademicYear.SelectedItem as TextBlock;
                selectedAcademicYear = selectedYear.Text.ToString();
            }
            if (cmbGroups.SelectedItem!=null)
            {
                Group selectedGroup = cmbGroups.SelectedItem as Group;
                selectedGroupNumber = selectedGroup.Number;
            }
            if (cmbSpecialities.SelectedItem != null && cmbQualifications.SelectedItem!=null && cmbStartYear.SelectedItem!=null && cmbAcademicYear.SelectedItem!=null && cmbGroups.SelectedItem != null)
            {
                tblInstruction.Visibility = Visibility.Hidden;
                plan = CollegeBaseEntities.GetContext().Syllabus.Where(s => s.GroupNumber == selectedGroupNumber && s.AcademicYear == selectedAcademicYear).FirstOrDefault();
                if (plan != null)
                {
                    btnAddRow.IsEnabled = true;
                    btnDeleteRow.IsEnabled = true;
                    Classes.Control._currentPlan = plan;
                    int cours = Int32.Parse(plan.AcademicYear.Substring(0, 4)) - plan.Group.StartYear;
                    switch (cours)
                    {
                        case 0:
                            textSemester1.Content = "Семестр 1";
                            textSemester2.Content = "Семестр 2";
                            firstSemester = 1;
                            secondSemester = 2;
                            break;

                        case 1:
                            textSemester1.Content = "Семестр 3";
                            textSemester2.Content = "Семестр 4";
                            firstSemester = 3;
                            secondSemester = 4;
                            break;

                        case 2:
                            textSemester1.Content = "Семестр 5";
                            textSemester2.Content = "Семестр 6";
                            firstSemester = 5;
                            secondSemester = 6;
                            break;

                        case 3:
                            textSemester1.Content = "Семестр 7";
                            textSemester2.Content = "Семестр 8";
                            firstSemester = 7;
                            secondSemester = 8;
                            break;
                    }
                    int id = plan.Id;
                    _currentRows = GetRows(id);
                    DGridPlan.ItemsSource = null;
                    DGridPlan.ItemsSource = _currentRows;
                    tblResult.Visibility = Visibility.Hidden;
                    if (_currentRows.Count > 0)
                    {
                        tblData.Visibility = Visibility.Hidden;
                        DGridPlan.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        tblData.Visibility = Visibility.Visible;
                        DGridPlan.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    tblResult.Visibility = Visibility.Visible;
                    DGridPlan.Visibility = Visibility.Hidden;
                    btnAddRow.IsEnabled = false;
                    btnDeleteRow.IsEnabled = false;
                }
            }
            else
            {
                tblInstruction.Visibility = Visibility.Visible;
                DGridPlan.Visibility = Visibility.Hidden;
                tblResult.Visibility = Visibility.Hidden;
                tblData.Visibility = Visibility.Hidden;
                btnAddRow.IsEnabled = false;
                btnDeleteRow.IsEnabled = false;

            }
            btnSave.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities.SubjectRow.SaveRow(_currentRows, _requiredPlan);
                MessageBox.Show("Данные успешно обновлены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("При сохранении данных возникли неполадки. Повторите попытку позже.", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            WndAddSubject window = new WndAddSubject(Classes.Control._currentPlan.Id, Classes.Control._currentPlan.Group.SpecialityId,Classes.Control._currentPlan.Group.QualificationId,firstSemester,secondSemester);
            window.ShowDialog();
            CollegeBaseEntities.GetContext().SaveChanges();
            GetPlan();
        }

        private void DGridPlan_CurrentCellChanged(object sender, EventArgs e)
        {
            btnSave.IsEnabled = true;
        }

        private void tbExam_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Exam = text;
            }
        }

        private void tbOffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Offset = text;
            }
        }

        private void tbDiffOffset_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.DiffOffset = text;
            }
        }

        private void tbCourseProject_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.CourseProject = text;
            }
        }

        private void tbCourseWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.CourseWork = text;
            }
        }

        private void tbTestWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.TestWork = text;
            }
        }

        private void tbOtherAttestation_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.OtherAttestation = text;
            }
        }

        private void tbSemester1MaxLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1MaxLoad = text;
            }
        }

        private void tbSemester1IndependentLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1IndependentLoad = text;
            }
        }

        private void tbSemester1ConsultationLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1ConsultationLoad = text;
            }
        }

        private void tbSemester1NecessaryLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1NecessaryLoad = text;
            }
        }

        private void tbSemester1LectureLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1LectureLoad = text;
            }
        }

        private void tbSemester1PracticeLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1PracticeLoad = text;
            }
        }

        private void tbSemester1LaboratoryLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1LaboratoryLoad = text;
            }
        }

        private void tbSemester1SeminarLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1SeminarLoad = text;
            }
        }

        private void tbSemester1ProjectionLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1ProjectionLoad = text;
            }
        }

        private void tbSemester1IndProjectLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester1IndProjectLoad = text;
            }
        }

        private void tbSemester2MaxLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2MaxLoad = text;
            }
        }

        private void tbSemester2IndependentLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2IndependentLoad = text;
            }
        }

        private void tbSemester2ConsultationLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2ConsultationLoad = text;
            }
        }

        private void tbSemester2NecessaryLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2NecessaryLoad = text;
            }
        }

        private void tbSemester2LectureLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2LectureLoad = text;
            }
        }

        private void tbSemester2PracticeLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2PracticeLoad = text;
            }
        }

        private void tbSemester2LaboratoryLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2LaboratoryLoad = text;
            }
        }

        private void tbSemester2SeminarLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2SeminarLoad = text;
            }
        }

        private void tbSemester2ProjectionLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2ProjectionLoad = text;
            }
        }

        private void tbSemester2IndProjectLoad_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubjectRow row = (sender as TextBox).DataContext as SubjectRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Semester2IndProjectLoad = text;
            }
        }

        private void cmbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPlan();
        }

        private void btnAddPlan_Click(object sender, RoutedEventArgs e)
        {
            WndAddPlan window = new WndAddPlan();
            window.ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            Entities.SubjectRow.DeleteRow(DGridPlan);
            GetPlan();
        }
    }
}
