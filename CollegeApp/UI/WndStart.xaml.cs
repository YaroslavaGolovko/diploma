using CollegeApp.UI;
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

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WndStart : Window
    {
        public WndStart()
        {
            InitializeComponent();
            tbLogin.Focus();
        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Visibility == Visibility.Visible)
            {
                if (pbPassword.Password.Length > 0)
                {
                    labelHint.Visibility = Visibility.Hidden;
                }
                else
                {
                    labelHint.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            labelHint.Visibility = Visibility.Hidden;
            tbPassword.Text = pbPassword.Password;
            tbPassword.Visibility = Visibility.Visible;
            btnHidePassword.Visibility = Visibility.Visible;
            pbPassword.Visibility = Visibility.Hidden;
            btnShowPassword.Visibility = Visibility.Hidden;
        }

        private void btnHidePassword_Click(object sender, RoutedEventArgs e)
        {
            pbPassword.Password = tbPassword.Text;
            pbPassword.Visibility = Visibility.Visible;
            btnShowPassword.Visibility = Visibility.Visible;
            tbPassword.Visibility = Visibility.Hidden;
            btnHidePassword.Visibility = Visibility.Hidden;
            if (pbPassword.Password.Length == 0)
                labelHint.Visibility = Visibility.Visible;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать логин.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tbPassword.Visibility == Visibility.Visible)
            {
                if (tbPassword.Text.Length == 0)
                {
                    MessageBox.Show("Необходимо указать пароль.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if(Classes.Control.CheckEnter(tbLogin.Text,tbPassword.Text))
                {
                    MessageBox.Show("Добро пожаловать, "+Classes.Control._currentUser.Professor.FirstName+" "+Classes.Control._currentUser.Professor.Patronymic, "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                    WndWork window = new WndWork();
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Введены неверные данные для авторизации.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbLogin.Clear();
                    pbPassword.Clear();
                    tbPassword.Clear();
                }
            }
            if (pbPassword.Visibility == Visibility.Visible)
            {
                if (pbPassword.Password.Length == 0)
                {
                    MessageBox.Show("Необходимо указать пароль.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Classes.Control.CheckEnter(tbLogin.Text, pbPassword.Password))
                {
                    MessageBox.Show("Добро пожаловать, " + Classes.Control._currentUser.Professor.FirstName + " " + Classes.Control._currentUser.Professor.Patronymic+"!", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                    WndWork window = new WndWork();
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Введены неверные данные для авторизации.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbLogin.Clear();
                    pbPassword.Clear();
                    tbPassword.Clear();
                }
            }
        }
    }
}
