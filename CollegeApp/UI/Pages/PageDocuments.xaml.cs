using CollegeApp.Entities;
using CollegeApp.UI.Windows;
using DevExpress.Utils.CommonDialogs.Internal;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
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
using word = Microsoft.Office.Interop.Word;

namespace CollegeApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDocuments.xaml
    /// </summary>
    public partial class PageDocuments : System.Windows.Controls.Page
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
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.WorkProgramElectronicIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbWPElectronic_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.WorkProgramElectronicIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void cbWPTypewriter_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.WorkProgramTypewriterIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbWPTypewriter_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.WorkProgramTypewriterIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void cbCTPElectronic_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanElectronicIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbCTPElectronic_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanElectronicIsExist = false;
            btnSave.IsEnabled = true;
        }

        private void cbCTPTypewriter_Checked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
            row.CalendarThematicPlanTypewriterIsExist = true;
            btnSave.IsEnabled = true;
        }

        private void cbCTPTypewriter_Unchecked(object sender, RoutedEventArgs e)
        {
            DocumentRow row = (sender as System.Windows.Controls.CheckBox).DataContext as DocumentRow;
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
                    DGridDocuments.ItemsSource = DocumentRow.GetRows(documents);
                    DGridDocuments.Visibility = Visibility.Visible;
                    btnAddRow.IsEnabled = true;
                    btnDeleteRow.IsEnabled = true;
                    btnPrint.IsEnabled = true;
                }
                else
                {
                    DGridDocuments.Visibility = Visibility.Hidden;
                    btnDeleteRow.IsEnabled = false;
                    btnPrint.IsEnabled = true;
                }
            }
            else
            {
                DGridDocuments.Visibility = Visibility.Hidden;
                btnAddRow.IsEnabled = false;
                btnDeleteRow.IsEnabled = false;
                btnPrint.IsEnabled = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DocumentRow.SaveRow(DGridDocuments);
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

        private void tbWPTypewriter_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DocumentRow row = (sender as TextBox).DataContext as DocumentRow;
                string text = (sender as TextBox).Text;
                DateTime date = DateTime.Parse(text);
                if (text != null)
                {
                    row.WorkProgramTypewriterDate = date;
                }
                btnSave.IsEnabled = true;
            }
            catch { return; }
        }

        private void tbWPElectronic_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DocumentRow row = (sender as TextBox).DataContext as DocumentRow;
                string text = (sender as TextBox).Text;
                DateTime date = DateTime.Parse(text);
                if (text != null)
                {
                    row.WorkProgramElectronicDate = date;
                }
                btnSave.IsEnabled = true;
            }
            catch { return; }
        }

        private void tbCTPElectronic_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DocumentRow row = (sender as TextBox).DataContext as DocumentRow;
                string text = (sender as TextBox).Text;
                DateTime date = DateTime.Parse(text);
                if (text != null)
                {
                    row.CalendarThematicPlanElectronicDate = date;
                }
                btnSave.IsEnabled = true;
            }
            catch { return; }
        }

        private void tbCTPTypewriter_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DocumentRow row = (sender as TextBox).DataContext as DocumentRow;
                string text = (sender as TextBox).Text;
                DateTime date = DateTime.Parse(text);
                if (text != null)
                {
                    row.CalendarThematicPlanTypewriterDate = date;
                }
                btnSave.IsEnabled = true;
            }
            catch { return; }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            DocumentRow.PrintRows(DGridDocuments, cmbSpecialities, cmbQualifications, cmbStartYear, cmbAcademicYear, cmbProfessors);
        }
    }
}
