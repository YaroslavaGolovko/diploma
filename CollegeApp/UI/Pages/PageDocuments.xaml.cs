using CollegeApp.Entities;
using CollegeApp.UI.Windows;
using System;
using System.Collections.Generic;
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

namespace CollegeApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDocuments.xaml
    /// </summary>
    public partial class PageDocuments : Page
    {
        private string specialityId;
        private int qualificationId;
        private int startYear;
        private string academicYear;
        private List<SubjectProfessor> _currentDocuments;
        public PageDocuments()
        {
            InitializeComponent();
            var professors= CollegeBaseEntities.GetContext().Professors.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ThenBy(p => p.Patronymic).ToList();
            professors.Insert(0, new Professor
            {
                LastName = "Все",FirstName="преподаватели",Patronymic=""
            });
            cmbSpecialities.ItemsSource = CollegeBaseEntities.GetContext().Specialities.ToList();
            cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            var academicYears = new List<TextBlock>();
            academicYears.Add(new TextBlock { Text = "2019-2020" });
            academicYears.Add(new TextBlock { Text = "2020-2021" });
            academicYears.Add(new TextBlock { Text = "2021-2022" });
            academicYears.Add(new TextBlock { Text = "2022-2023" });
            academicYears.Add(new TextBlock { Text = "2023-2024" });
            academicYears.Add(new TextBlock { Text = "2024-2025" });
            academicYears.Add(new TextBlock { Text = "2025-2026" });
            cmbAcademicYear.ItemsSource = academicYears;
            cmbProfessors.ItemsSource = professors;
            GetDataGrid();
            
        }

        private void cmbSpecialities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSpecialities.SelectedItem != null)
            {
                var selectedSpeciality = cmbSpecialities.SelectedItem as Speciality;
                specialityId = selectedSpeciality.Id;
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.Where(q => q.SpecialityId == specialityId).ToList();
            }
            else
            {
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            }
            GetDataGrid();
        }

        private void cmbQualifications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDataGrid();
        }

        private void cmbStartYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDataGrid();
        }

        private void cmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDataGrid();
        }

        private void cmbProfessors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDataGrid();
        }

        private void cbWPElectronic_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.WorkProgramElectronicIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbWPElectronic_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.WorkProgramElectronicIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void cbWPTypewriter_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.WorkProgramTypewriterIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbWPTypewriter_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.WorkProgramTypewriterIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void cbCTPElectronic_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanElectronicIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbCTPElectronic_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanElectronicIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void cbCTPTypewriter_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanTypewriterIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbCTPTypewriter_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanTypewriterIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void GetDataGrid()
        {
            if(cmbProfessors.SelectedItem!=null || (cmbSpecialities.SelectedItem!=null && cmbQualifications.SelectedItem!=null && cmbAcademicYear.SelectedItem!=null && cmbStartYear.SelectedItem != null))
            {
                var documents= CollegeBaseEntities.GetContext().SubjectProfessors.ToList();
                if (cmbProfessors.SelectedItem != null)
                {
                    if (cmbProfessors.SelectedIndex > 0)
                    {
                        Professor selectedProfessor = cmbProfessors.SelectedItem as Professor;
                        int professorId = selectedProfessor.Id;
                        documents = documents.Where(d => d.ProfessorId == professorId).ToList();
                    }
                }
                if (cmbSpecialities.SelectedItem != null)
                {
                    Speciality selectedSpeciality = cmbSpecialities.SelectedItem as Speciality;
                    specialityId = selectedSpeciality.Id;
                    documents = documents.Where(d => d.SubjectSemester.SubjectSpeciality.SpecialityId == specialityId).ToList();
                }
                if (cmbQualifications.SelectedItem != null)
                {
                    Qualification selectedQualification = cmbQualifications.SelectedItem as Qualification;
                    qualificationId = selectedQualification.Id;
                    documents = documents.Where(d => d.SubjectSemester.SubjectSpeciality.QualificationId == qualificationId).ToList();
                }
                if (cmbAcademicYear.SelectedItem != null)
                {
                    var selectedItem = cmbAcademicYear.SelectedItem as TextBlock;
                    academicYear = selectedItem.Text.ToString();
                    documents = documents.Where(d => d.SubjectSemester.Syllabu.AcademicYear == academicYear).ToList();
                }
                if (cmbStartYear.SelectedItem != null)
                {
                    var selectedYear = cmbStartYear.SelectedItem as TextBlock;
                    string text = selectedYear.Text.ToString();
                    startYear = int.Parse(text);
                    documents = documents.Where(d => d.SubjectSemester.Syllabu.Group.StartYear == startYear).ToList();
                }
                if (documents.Count > 0)
                {
                    _currentDocuments = documents;
                    DGridDocuments.ItemsSource = GetRows(documents);
                    DGridDocuments.Visibility = Visibility.Visible;
                    btnAddRow.IsEnabled = true;
                    btnDeleteRow.IsEnabled = true;
                }
                else
                {
                    DGridDocuments.Visibility = Visibility.Hidden;
                    btnAddRow.IsEnabled = false;
                    btnDeleteRow.IsEnabled = false;
                }
            }
            else
            {
                DGridDocuments.Visibility = Visibility.Hidden;
                btnAddRow.IsEnabled = false;
                btnDeleteRow.IsEnabled = false;
            }
        }

        private List<DocumentRow> GetRows(List<SubjectProfessor> documents)
        {
            var rows = new List<DocumentRow>();
            foreach (var document in documents)
            {
                DocumentRow row = new DocumentRow();
                row.Id = document.Id;
                row.SubjectSemesterId = document.SubjectSemesterId;
                var _currentDocument = document.Documents.FirstOrDefault();
                row.DocumentId = _currentDocument.Id;
                row.ProfessorFullName = document.Professor.FullName;
                row.ProfessorId = document.ProfessorId;
                row.SubjectName = document.SubjectSemester.SubjectSpeciality.Subject.Name;
                row.Note = _currentDocument.Note;
                row.Syllabus = document.SubjectSemester.Syllabu;
                row.SpecialityId = row.Syllabus.Group.SpecialityId;
                row.Qualification = row.Syllabus.Group.Qualification.Name;
                row.AcademicYear = row.Syllabus.AcademicYear;
                row.StartYear = row.Syllabus.Group.StartYear;
                row.Semester = document.SubjectSemester.Semester;
                int cours = Int32.Parse(row.AcademicYear.Substring(0, 4)) - row.StartYear;
                switch (cours)
                {
                    case 0:
                        if (document.SubjectSemester.Semester == 1)
                            row.SemesterVisible = 1;
                        if (document.SubjectSemester.Semester == 2)
                            row.SemesterVisible = 2;
                        break;

                    case 1:
                        if (document.SubjectSemester.Semester == 1)
                            row.SemesterVisible = 3;
                        if (document.SubjectSemester.Semester == 2)
                            row.SemesterVisible = 4;
                        break;

                    case 2:
                        if (document.SubjectSemester.Semester == 1)
                            row.SemesterVisible = 5;
                        if (document.SubjectSemester.Semester == 2)
                            row.SemesterVisible = 6;
                        break;

                    case 3:
                        if (document.SubjectSemester.Semester == 1)
                            row.SemesterVisible = 7;
                        if (document.SubjectSemester.Semester == 2)
                            row.SemesterVisible = 8;
                        break;
                }
                row.WorkProgramElectronicIsExist = false;
                row.WorkProgramTypewriterIsExist = false;
                row.CalendarThematicPlanElectronicIsExist = false;
                row.CalendarThematicPlanTypewriterIsExist = false;
                var _currentWorkProgramElectronic = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 1).FirstOrDefault();
                if (_currentWorkProgramElectronic != null)
                {
                    row.WorkProgramElectronicIsExist = true;
                    row.WorkProgramElectronicId = _currentWorkProgramElectronic.Id;
                    row.WorkProgramElectronicDate = _currentWorkProgramElectronic.Date;
                }
                var _currentWorkProgramTypewriter = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 2).FirstOrDefault();
                if (_currentWorkProgramTypewriter != null)
                {
                    row.WorkProgramTypewriterIsExist = true;
                    row.WorkProgramTypewriterId = _currentWorkProgramTypewriter.Id;
                    row.WorkProgramTypewriterDate = _currentWorkProgramTypewriter.Date;
                }
                var _currentCalendarThematicPlanElectronic = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 3).FirstOrDefault();
                if (_currentCalendarThematicPlanElectronic != null)
                {
                    row.CalendarThematicPlanElectronicIsExist = true;
                    row.CalendarThematicPlanElectronicId = _currentCalendarThematicPlanElectronic.Id;
                    row.CalendarThematicPlanElectronicDate = _currentCalendarThematicPlanElectronic.Date;
                }
                var _currentCalendarThematicPlanTypewriter = _currentDocument.DocumentSupplies.Where(s => s.SupplyTypeId == 4).FirstOrDefault();
                if (_currentCalendarThematicPlanTypewriter != null)
                {
                    row.CalendarThematicPlanTypewriterIsExist = true;
                    row.CalendarThematicPlanTypewriterId = _currentCalendarThematicPlanTypewriter.Id;
                    row.CalendarThematicPlanTypewriterDate = _currentCalendarThematicPlanTypewriter.Date;
                }
                if(rows.Where(r=>r.SubjectSemesterId==row.SubjectSemesterId && r.ProfessorId == row.ProfessorId || (r.ProfessorId==row.ProfessorId && r.SpecialityId==row.SpecialityId && r.Qualification==row.Qualification && r.StartYear==row.StartYear && r.AcademicYear==r.AcademicYear && r.Semester==row.Semester && r.SemesterVisible==row.SemesterVisible && r.SubjectName==row.SubjectName)).FirstOrDefault() == null)
                {
                    rows.Add(row);
                }
            }
            return rows;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<DocumentRow> rows = DGridDocuments.ItemsSource as List<DocumentRow>;
            foreach (var row in rows)
            {
                var _currentSubjectProfessors = CollegeBaseEntities.GetContext().Documents.Where(s => s.SubjectProfessor.ProfessorId == row.ProfessorId && s.SubjectProfessor.SubjectSemester.Semester == row.Semester && s.SubjectProfessor.SubjectSemester.Syllabu.Group.SpecialityId == row.SpecialityId && s.SubjectProfessor.SubjectSemester.Syllabu.Group.Qualification.Name == row.Qualification && s.SubjectProfessor.SubjectSemester.Syllabu.AcademicYear == row.AcademicYear && s.SubjectProfessor.SubjectSemester.Syllabu.Group.StartYear == row.StartYear).ToList();
                foreach(var item in _currentSubjectProfessors)
                {
                    if (row.WorkProgramElectronicIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 1).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 1;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 1).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.WorkProgramTypewriterIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 2).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 2;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 2).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.CalendarThematicPlanElectronicIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 3).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 3;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 3).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.CalendarThematicPlanTypewriterIsExist == true)
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 4).FirstOrDefault();
                        if (supply == null)
                        {
                            DocumentSupply documentSupply = new DocumentSupply();
                            documentSupply.DocumentId = item.Id;
                            documentSupply.SupplyTypeId = 4;
                            documentSupply.Date = DateTime.Now.Date;
                            CollegeBaseEntities.GetContext().DocumentSupplies.Add(documentSupply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    else
                    {
                        var supply = CollegeBaseEntities.GetContext().DocumentSupplies.Where(d => d.DocumentId == item.Id && d.SupplyTypeId == 4).FirstOrDefault();
                        if (supply != null)
                        {
                            CollegeBaseEntities.GetContext().DocumentSupplies.Remove(supply);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }
                    }
                    if (row.Note!=null)
                    {
                        item.Note = row.Note;
                    }
                    else
                    {
                        item.Note = null;
                    }
                    CollegeBaseEntities.GetContext().SaveChanges();
                }
                CollegeBaseEntities.GetContext().SaveChanges();
            }
            CollegeBaseEntities.GetContext().SaveChanges();
            GetDataGrid();
        }

        private void tbNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            DocumentRow row = (sender as TextBox).DataContext as DocumentRow;
            string text = (sender as TextBox).Text;
            if (text != null)
            {
                row.Note = text;
            }
            btnSave.IsEnabled = true;
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = DGridDocuments.SelectedItem as DocumentRow;
                if (selectedRow != null)
                {
                    if(MessageBox.Show("Вы точно хотите удалить данный документ?","Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var items = CollegeBaseEntities.GetContext().Documents.Where(d => d.Id == selectedRow.DocumentId || (d.SubjectProfessor.ProfessorId == selectedRow.ProfessorId && d.SubjectProfessor.SubjectSemester.Semester == selectedRow.Semester && d.SubjectProfessor.SubjectSemester.Syllabu.Group.SpecialityId == selectedRow.SpecialityId && d.SubjectProfessor.SubjectSemester.Syllabu.Group.Qualification.Name == selectedRow.Qualification && d.SubjectProfessor.SubjectSemester.Syllabu.AcademicYear == selectedRow.AcademicYear && d.SubjectProfessor.SubjectSemester.Syllabu.Group.StartYear == selectedRow.StartYear)).ToList();
                        if (items != null)
                        {
                            if (items.Count > 0)
                            {
                                CollegeBaseEntities.GetContext().Documents.RemoveRange(items);
                                CollegeBaseEntities.GetContext().SaveChanges();
                                MessageBox.Show("Документ успешно удален!", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                                GetDataGrid();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать документ для удаления!", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                    GetDataGrid();
                }
            }
            catch
            {
                MessageBox.Show("Во время удаления документа возникли неполадки. Повторите попытку позже.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                GetDataGrid();
            }
        }
        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewDocument window = new WndAddNewDocument(specialityId, qualificationId, startYear, academicYear);
            window.ShowDialog();
            GetDataGrid();
        }
    }
}
