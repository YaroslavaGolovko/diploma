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
    /// Логика взаимодействия для WndAddNewCategory.xaml
    /// </summary>
    public partial class WndAddNewCategory : Window
    {
        public WndAddNewCategory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CollegeBaseEntities.GetContext().SubjectCategories.Where(s=>s.Id.ToLower()==tbIndex.Text.ToLower().ToString() && s.Name.ToLower()==tbName.Text.ToLower().ToString()).FirstOrDefault() != null)
                {
                    MessageBox.Show("Данная категория уже существует в базе.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    SubjectCategory category = new SubjectCategory();
                    category.Id = tbIndex.Text;
                    category.Name = tbName.Text;
                    CollegeBaseEntities.GetContext().SubjectCategories.Add(category);
                    CollegeBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnSave.IsEnabled = false;
                }
            }
            catch
            {
                MessageBox.Show("При сохранении данных возникли неполадки. Проверьте вводимые данные, а также подключение к серверу, и повторите попытку позже.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetEnabledButton()
        {
            if(tbIndex.Text.Length>0 && tbName.Text.Length > 0)
            {
                btnSave.IsEnabled = true;
            }
            else
            {
                btnSave.IsEnabled = false;
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void tbIndex_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }
    }
}
