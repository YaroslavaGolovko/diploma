using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для WndAddPlan.xaml
    /// </summary>
    public partial class WndAddPlan : Window
    {
        public WndAddPlan()
        {
            InitializeComponent();
            cmbSpecialities.ItemsSource = CollegeBaseEntities.GetContext().Specialities.ToList();
            cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            cmbStartYear.ItemsSource = CollegeBaseEntities.GetContext().Groups.Select(g => g.StartYear).Distinct().ToList();
            cmbAcademicYear.ItemsSource = CollegeBaseEntities.GetContext().Syllabus.Select(s => s.AcademicYear).Distinct().ToList();
        }

        private void cmbSpecialities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnableButton();
            if (cmbSpecialities.SelectedItem != null)
            {
                var speciality = cmbSpecialities.SelectedItem as Speciality;
                string id = speciality.Id;
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.Where(q => q.SpecialityId == id).ToList();
            }
            else
            {
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            }
        }

        private void cmbQualifications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnableButton();
        }

        private void cmbStartYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnableButton();
        }

        private void cmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnableButton();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool success = false;
                var speciality = cmbSpecialities.SelectedItem as Speciality;
                string specialityId = speciality.Id;
                var qualification = cmbQualifications.SelectedItem as Qualification;
                int qualificationId = qualification.Id;
                int startYear = Int32.Parse(cmbStartYear.SelectedItem.ToString());
                string academicYear=cmbAcademicYear.SelectedItem as string;
                List<Group> groups = CollegeBaseEntities.GetContext().Groups.Where(g => g.SpecialityId == specialityId && g.QualificationId == qualificationId && g.StartYear == startYear).ToList();
                if (groups != null)
                {
                    foreach (Group group in groups)
                    { 
                        if(CollegeBaseEntities.GetContext().Syllabus.Where(s=>s.GroupNumber==group.Number && s.AcademicYear == academicYear).FirstOrDefault() != null)
                        {
                            MessageBox.Show("Учебный план для группы " + group.Number + " на " + academicYear + " учебный год уже добавлен!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                            success = false;
                        }
                        else
                        {
                            Syllabu syllabus = new Syllabu();
                            syllabus.AcademicYear = academicYear;
                            syllabus.GroupNumber = group.Number;
                            CollegeBaseEntities.GetContext().Syllabus.Add(syllabus);
                            CollegeBaseEntities.GetContext().SaveChanges();
                            MessageBox.Show("Учебный план для группы " + group.Number + " на " + academicYear + " учебный год успешно добавлен!", "Данные сохранены", MessageBoxButton.OK, MessageBoxImage.Information);
                            success = true;
                        }
                    }
                }
                if (success)
                {
                    btnSave.IsEnabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("При добавлении учебного плана возникли неполадки. Проверьте правильность вводимых данных, а также соединение с сервером, и повторите попытку.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetEnableButton()
        {
            if(cmbSpecialities.SelectedItem!=null && cmbQualifications.SelectedItem != null && cmbStartYear.SelectedItem != null && cmbAcademicYear.SelectedItem != null)
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
