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
    /// Логика взаимодействия для WndAddNewIndex.xaml
    /// </summary>
    public partial class WndAddNewIndex : Window
    {
        public WndAddNewIndex()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CollegeBaseEntities.GetContext().SubjectIndexes.Where(s => s.Name.ToLower() == tbName.Text.ToLower().ToString()).FirstOrDefault() != null)
                {
                    MessageBox.Show("Данный индекс уже существует в базе.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    SubjectIndex index = new SubjectIndex();
                    index.Name = tbName.Text;
                    CollegeBaseEntities.GetContext().SubjectIndexes.Add(index);
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
            if (tbName.Text.Length > 0)
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
    }
}
