using CollegeApp.Entities;
using CollegeApp.UC;
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
    /// Логика взаимодействия для PageSubjects.xaml
    /// </summary>
    public partial class PageSubjects : Page
    {
        public PageSubjects()
        {
            InitializeComponent();
            Classes.Control.DGridSubjects = DGridSubjects;
            DGridSubjects.ItemsSource = CollegeBaseEntities.GetContext().Subjects.ToList();
        }

        private void btnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            WndAddEditSubject window = new WndAddEditSubject(null);
            window.ShowDialog();
            DGridSubjects.ItemsSource = CollegeBaseEntities.GetContext().Subjects.ToList();
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewCategory window = new WndAddNewCategory();
            window.ShowDialog();
        }

        private void btnAddIndex_Click(object sender, RoutedEventArgs e)
        {
            WndAddNewIndex wnd = new WndAddNewIndex();
            wnd.ShowDialog();
        }
    }
}
