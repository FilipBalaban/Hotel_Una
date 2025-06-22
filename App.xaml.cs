using Hotel_Una.DatabaseContext;
using Hotel_Una.DTOs;
using Hotel_Una.Models;
using Hotel_Una.Services.ReservationManagers;
using Hotel_Una.Stores;
using Hotel_Una.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-92VTUS6\SQLEXPRESS;Initial Catalog=HotelUnaDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private readonly HotelDbContextFactory _hotelDbContextFactory;
        private readonly DatabaseReservationManager _databaseReservationManager;
        public App()
        {
            _hotelDbContextFactory = new HotelDbContextFactory(CONNECTION_STRING);
            _databaseReservationManager = new DatabaseReservationManager(_hotelDbContextFactory);
            _hotel = new Hotel("Hotel Una", _databaseReservationManager);
            _navigationStore = new NavigationStore();
            _navigationSideBarViewModel = new NavigationSideBarViewModel(_navigationStore, _hotel);
            _navigationStore.CurrentViewModel = ReservationOverviewViewModel.LoadViewModel(_hotel);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_hotel, _navigationStore)
            };

            using (HotelDbContext dbContext = _hotelDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
