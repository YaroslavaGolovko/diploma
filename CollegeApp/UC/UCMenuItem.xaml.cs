using CollegeApp.Classes;
using CollegeApp.UI;
using CollegeApp.UI.Pages;
using System;
using System.CodeDom;
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
using Control = CollegeApp.Classes.Control;

namespace CollegeApp.UC
{
    /// <summary>
    /// Логика взаимодействия для UCMenuItem.xaml
    /// </summary>
    public partial class UCMenuItem : UserControl
    {
        private ItemMenu currentItem;
        public UCMenuItem(ItemMenu itemMenu)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
            this.currentItem = itemMenu;
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.currentItem.Type == 1)
            {
                Control._currentFrame.Navigate(new PagePlans());
            }
            if (this.currentItem.Type == 2)
            {
                Control._currentFrame.Navigate(new PageLoads());
            }
            if (this.currentItem.Type == 3)
            {
                Control._currentFrame.Navigate(new PageSubjects());
            }
            if (this.currentItem.Type == 4)
            {
                Control._currentFrame.Navigate(new PageGroups());
            }
            if (this.currentItem.Type == 5)
            {
                Control._currentFrame.Navigate(new PageProfessors());
            }
            if (this.currentItem.Type == 6)
            {
                Control._currentFrame.Navigate(new PageDocuments());
            }
        }
    }
}
