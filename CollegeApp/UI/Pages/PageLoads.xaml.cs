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

namespace CollegeApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageLoads.xaml
    /// </summary>
    public partial class PageLoads : Page
    {
        private List<Subject> subjects;
        private string idSpeciality;
        private int idQualification;
        private string textAcademicYear;
        private int textStartYear;
        private List<TextBlock> academicYears;
        public PageLoads()
        {
            InitializeComponent();
            cmbSpecialities.ItemsSource = CollegeBaseEntities.GetContext().Specialities.ToList();
            cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            subjects = new List<Subject>();
            academicYears = new List<TextBlock>();
            academicYears.Add(new TextBlock { Text = "2019-2020" });
            academicYears.Add(new TextBlock { Text = "2020-2021" });
            academicYears.Add(new TextBlock { Text = "2021-2022" });
            academicYears.Add(new TextBlock { Text = "2022-2023" });
            academicYears.Add(new TextBlock { Text = "2023-2024" });
            academicYears.Add(new TextBlock { Text = "2024-2025" });
            academicYears.Add(new TextBlock { Text = "2025-2026" });
            cmbAcademicYear.ItemsSource = academicYears;
        }

        private void btnDeleteLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadRow _currentRow = (sender as Button).DataContext as LoadRow;
                if (_currentRow.ProfessorId == 0)
                {
                    MessageBox.Show("На данную дисциплину преподаватель не назначен.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(MessageBox.Show("Вы точно хотите удалить нагрузку?","Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        SubjectProfessor load = CollegeBaseEntities.GetContext().SubjectProfessors.Where(s => s.ProfessorId == _currentRow.ProfessorId && s.SubjectSemesterId == _currentRow.SubjectSemesterId).FirstOrDefault();
                        int id = load.Id;

                        Document document = CollegeBaseEntities.GetContext().Documents.Where(d => d.SubjectProfessorId == id).FirstOrDefault();
                        if (document != null)
                        {
                            CollegeBaseEntities.GetContext().Documents.Remove(document);
                            CollegeBaseEntities.GetContext().SaveChanges();
                        }

                        load = CollegeBaseEntities.GetContext().SubjectProfessors.Where(s => s.ProfessorId == _currentRow.ProfessorId && s.SubjectSemesterId == _currentRow.SubjectSemesterId).FirstOrDefault();
                        id = load.Id;
                        CollegeBaseEntities.GetContext().SubjectProfessors.Remove(load);
                        CollegeBaseEntities.GetContext().SaveChanges();


                        MessageBox.Show("Нагрузка удалена!", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        GetLoad();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("При удалении данных произошли неполадки. Повторите попытку позже.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            /*
            TextBlock year = cmbAcademicYear.SelectedItem as TextBlock;
            string yearText = year.Text.ToString();
            var semesters = CollegeBaseEntities.GetContext().SubjectSemesters.Where(s => s.SubjectSpecialityId == _currentRow.SubjectSpecialityId && s.Semester == _currentRow.Semester && s.Syllabu.AcademicYear ==yearText).ToList();
            foreach (var semester in semesters)
            {
                if(CollegeBaseEntities.GetContext().SubjectLoads.Where(s=>s.SubjectSemesterId==semester.Id).FirstOrDefault() != null)
                {
                    var list = CollegeBaseEntities.GetContext().SubjectLoads.Where(s => s.SubjectSemesterId == semester.Id).ToList();
                    CollegeBaseEntities.GetContext().SubjectLoads.RemoveRange(list);
                    CollegeBaseEntities.GetContext().SaveChanges();
                }
                CollegeBaseEntities.GetContext().SubjectSemesters.Remove(semester);
                CollegeBaseEntities.GetContext().SaveChanges();
            }
            CollegeBaseEntities.GetContext().SaveChanges();
            MessageBox.Show("удалено");
            GetLoad();
            */
        }

        private void cmbSpecialities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSpecialities.SelectedItem!=null)
            {
                Speciality speciality = cmbSpecialities.SelectedItem as Speciality;
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.Where(q => q.SpecialityId == speciality.Id).ToList();
            }
            else
            {
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            }
            GetLoad();
        }

        private void cmbQualifications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetLoad();
        }

        private void cmbStartYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetLoad();
        }

        private void cmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetLoad();
        }

        private void btnUpdateLoad_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditLoad window = new WndAddEditLoad((sender as Button).DataContext as LoadRow);
            window.ShowDialog();
            GetLoad();
        }

        private void btnAddLoad_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewLoad window = new WndAddNewLoad(subjects, idSpeciality, idQualification, textStartYear, textAcademicYear);
            window.ShowDialog();
            GetLoad();
        }

        private void GetLoad()
        {
            if (cmbSpecialities.SelectedItem != null && cmbQualifications.SelectedItem != null && cmbStartYear.SelectedItem != null && cmbAcademicYear.SelectedItem != null)
            {
                Speciality speciality = cmbSpecialities.SelectedItem as Speciality;
                string specialityId = speciality.Id;
                Qualification qualification = cmbQualifications.SelectedItem as Qualification;
                int qualificationId = qualification.Id;
                TextBlock selectedStartYear = cmbStartYear.SelectedItem as TextBlock;
                int startYear = Int32.Parse(selectedStartYear.Text.ToString());
                TextBlock selectedAcademicYear = cmbAcademicYear.SelectedItem as TextBlock;
                string academicYear = selectedAcademicYear.Text.ToString();
                var _currentRows = Entities.LoadRow.GetRows(specialityId, qualificationId, startYear, academicYear, subjects);
                idSpeciality = specialityId;
                idQualification = qualificationId;
                textStartYear = startYear;
                textAcademicYear = academicYear;
                DGridLoads.ItemsSource = null;
                DGridLoads.ItemsSource = _currentRows;
                if (_currentRows.Count > 0)
                {
                    DGridLoads.Visibility = Visibility.Visible;
                    btnAddLoad.IsEnabled = true;
                    tblResult.Visibility = Visibility.Hidden;
                }
                else
                {
                    DGridLoads.Visibility = Visibility.Hidden;
                    btnAddLoad.IsEnabled = false;
                    tblResult.Visibility = Visibility.Visible;
                }
            }
            else
            {
                DGridLoads.Visibility = Visibility.Hidden;
                btnAddLoad.IsEnabled = false;
            }
        }
    }
}
