using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Во время загрузки приложения произошли неполадки. Повторите попытку позже.", "Ошибка обработки!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Environment.Exit(0);
        }
    }
}
