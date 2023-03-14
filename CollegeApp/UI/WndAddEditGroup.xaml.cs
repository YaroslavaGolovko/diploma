using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для WndAddEditGroup.xaml
    /// </summary>
    public partial class WndAddEditGroup : Window
    {
        private Entities.Group _currentGroup;
        private string specialityId;
        private int qualificationId;
        private bool isNew;
        public WndAddEditGroup(Entities.Group selectedGroup)
        {
            InitializeComponent();
            cmbSpesialities.ItemsSource = CollegeBaseEntities.GetContext().Specialities.ToList();
            cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
            if (selectedGroup != null)
            {
                _currentGroup = selectedGroup;
                DataContext = _currentGroup;
                if (_currentGroup.SpecialityId == "09.02.01")
                    cmbSpesialities.SelectedIndex = 0;
                if (_currentGroup.SpecialityId == "09.02.06")
                    cmbSpesialities.SelectedIndex = 1;
                if (_currentGroup.SpecialityId == "09.02.07")
                    cmbSpesialities.SelectedIndex = 2;
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.ToList();
                cmbQualifications.SelectedIndex = (_currentGroup.QualificationId) - 1;
                tblName.Text = "Редактирование группы";
                isNew = false;
            }
            else
            {
                _currentGroup = new Entities.Group();
                DataContext = _currentGroup;
                tbNumber.Clear();
                tbStartYear.Clear();
                isNew = true;
            }
        }

        private void cmbSpesialities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
            if (cmbSpesialities.SelectedItem != null)
            {
                Speciality selectedSpeciality = cmbSpesialities.SelectedItem as Speciality;
                string text = selectedSpeciality.Id;
                cmbQualifications.ItemsSource = CollegeBaseEntities.GetContext().Qualifications.Where(q => q.SpecialityId == text).ToList();
                specialityId = text;
            }
        }

        private void cmbQualifications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetEnabledButton();
            if(cmbQualifications.SelectedItem != null)
            {
                Qualification selectedQualification = cmbQualifications.SelectedItem as Qualification;
                int id = selectedQualification.Id;
                qualificationId = id;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int startYear = Int32.Parse(tbStartYear.Text.ToString());
                int number = Int32.Parse(tbNumber.Text.ToString());
                if (number <= 0)
                {
                    MessageBox.Show("Номер группы не может быть отрицательным!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (startYear <= 0)
                {
                    MessageBox.Show("Год набора не может быть отрицательным!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _currentGroup.Number = number;
                _currentGroup.StartYear = startYear;
                _currentGroup.SpecialityId = specialityId;
                _currentGroup.QualificationId = qualificationId;
                if (isNew)
                {
                    CollegeBaseEntities.GetContext().Groups.Add(_currentGroup);
                }
                CollegeBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("При сохранении данных возникли неполадки. Проверьте вводимые данные.", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void tbStartYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }
        private void SetEnabledButton()
        {
            if(tbNumber.Text.Length>0 && tbStartYear.Text.Length>0 && cmbSpesialities.SelectedItem!=null && cmbQualifications.SelectedItem != null)
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
