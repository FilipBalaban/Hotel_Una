using Hotel_Una.Models;
using Hotel_Una.Stores;
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
        private readonly NavigationStore _navigationStore;
        private readonly NavigationSideBarViewModel _navigationSideBarViewModel;
        public App()
        {
            _hotel = new Hotel("Hotel Una");
            _navigationStore = new NavigationStore();
            _navigationSideBarViewModel = new NavigationSideBarViewModel(_navigationStore, _hotel);
            _navigationStore.CurrentViewModel = new ReservationOverviewViewModel(_hotel);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_hotel, _navigationStore)
            };
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
