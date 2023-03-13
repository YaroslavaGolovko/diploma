using CollegeApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для WndAddNewSubject.xaml
    /// </summary>
    public partial class WndAddNewSubject : Window
    {
        public WndAddNewSubject()
        {
            InitializeComponent();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetEnabledButton();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CollegeBaseEntities.GetContext().Subjects.Where(s => s.Name.ToLower() == tbName.Text.ToLower().ToString()).FirstOrDefault() != null)
                {
                    MessageBox.Show("Данная дисциплина уже существует в базе.", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Subject subject = new Subject();
                    subject.Name = tbName.Text;
                    CollegeBaseEntities.GetContext().Subjects.Add(subject);
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
    }
}
