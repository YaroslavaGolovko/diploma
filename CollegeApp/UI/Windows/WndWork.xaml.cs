using CollegeApp.Classes;
using CollegeApp.UC;
using MaterialDesignThemes.Wpf;
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
using Control = CollegeApp.Classes.Control;

namespace CollegeApp.UI
{
    /// <summary>
    /// Логика взаимодействия для WndWork.xaml
    /// </summary>
    public partial class WndWork : Window
    {
        private ItemMenu _itemPlans;
        private ItemMenu _itemLoads;
        private ItemMenu _itemSubjects;
        private ItemMenu _itemGroups;
        private ItemMenu _itemProfessors;
        public WndWork()
        {
            InitializeComponent();
            Control._currentFrame = mainFrame;
            Control._currentFrame.Navigate(new PagePlans());

            /*var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Services"));
            menuSchedule.Add(new SubItem("Meetings"));
            var item1 = new ItemMenu("Нагрузка", menuSchedule, PackIconKind.Schedule);*/

            _itemPlans = new ItemMenu("Учебные планы", new UserControl(), PackIconKind.DriveDocument);
            _itemLoads = new ItemMenu("Нагрузка", new UserControl(), PackIconKind.DocumentSign);
            _itemSubjects = new ItemMenu("Дисциплины", new UserControl(), PackIconKind.BookAccount);
            _itemGroups = new ItemMenu("Группы", new UserControl(), PackIconKind.PeopleGroup);
            _itemProfessors = new ItemMenu("Преподаватели", new UserControl(), PackIconKind.Man);
            _itemPlans.Type = 1;
            _itemLoads.Type = 2;
            _itemSubjects.Type = 3;
            _itemGroups.Type = 4;
            _itemProfessors.Type = 5;
            Menu.Children.Add(new UCMenuItem(_itemPlans));
            Menu.Children.Add(new UCMenuItem(_itemLoads));
            Menu.Children.Add(new UCMenuItem(_itemSubjects));
            Menu.Children.Add(new UCMenuItem(_itemGroups));
            Menu.Children.Add(new UCMenuItem(_itemProfessors));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы точно хотите выйти из учетной записи?","Подтверждение выхода",MessageBoxButton.YesNo,MessageBoxImage.Question)==
                MessageBoxResult.Yes)
            {
                Classes.Control._currentUser = null;
                WndStart window = new WndStart();
                window.Show();
                this.Close();
            }
        }
    }
}
