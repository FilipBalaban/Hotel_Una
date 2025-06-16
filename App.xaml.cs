using Hotel_Una.Models;
using Hotel_Una.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Hotel_Una
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        public App()
        {
            _hotel = new Hotel("Slavorum's Suites");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_hotel)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
