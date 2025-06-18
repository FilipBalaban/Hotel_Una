using Hotel_Una.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel_Una.ViewModels
{
    public class ReservationOverviewViewModel: BaseViewModel
    {
        private ObservableCollection<ReservationViewModel> _reservations;
        private readonly Hotel _hotel;
        
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public Dictionary<string, string> SortPropertiesValuesToNames;

        public ObservableCollection<SortingItem> SortingPropertyItems { get; set; } = new ObservableCollection<SortingItem>()
        {
            new SortingItem("ID", "ID"), new SortingItem("Datum rezervacije", "ReservationDate"), new SortingItem("Check in", "StartDate"), new SortingItem("Check out", "EndDate"),
        };
        public ObservableCollection<SortingItem> SortingOrderItems { get; set; } = new ObservableCollection<SortingItem>()
        {
            new SortingItem("Opadajuće", "Descending"), new SortingItem( "Rastuće", "Ascending"),
        };
        public string SelectedSortingProperty { get; set; }
        public string SelectedSortingOrder { get; set; }
        public ICommand SortReservationsCommand { get; }
        public ReservationOverviewViewModel(Hotel hotel)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            _hotel = hotel;
            //LoadReservations();
        }
        private void LoadReservations()
        {
            //_hotel.Re
            //_hotel.AddReservation(new Reservation(1, "Jovan", "Jovanovic", new DateTime(2025, 1, 1), new DateTime(2025, 1, 7), 2));

            //_reservations.Clear();
            //foreach(Reservation reservation in _hotel.GetReservations())
            //{
            //    _reservations.Add(new ReservationViewModel(reservation));
            //}
        }
    }
}
