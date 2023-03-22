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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollegeApp.UI
{
    /// <summary>
    /// Логика взаимодействия для PageGroups.xaml
    /// </summary>
    public partial class PageGroups : Page
    {
        public PageGroups()
        {
            InitializeComponent();
            DGridGroups.ItemsSource = CollegeBaseEntities.GetContext().Groups.ToList();
        }

        private void btnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditGroup window = new WndAddEditGroup(null);
            window.ShowDialog();
            DGridGroups.ItemsSource = CollegeBaseEntities.GetContext().Groups.ToList();
        }

        private void btnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(MessageBox.Show("Вы точно хотите удалить данную группу?","Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Group group = (sender as Button).DataContext as Group;
                    CollegeBaseEntities.GetContext().Groups.Remove(group);
                    CollegeBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!", "Успешное удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("При удалении группы произошли неполадки, необходимо удалить учебные планы по данной группе и повторить попытку.", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdateGroup_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditGroup window = new WndAddEditGroup((sender as Button).DataContext as Entities.Group);
            window.ShowDialog();
            DGridGroups.ItemsSource = CollegeBaseEntities.GetContext().Groups.ToList();
        }
    }
}
