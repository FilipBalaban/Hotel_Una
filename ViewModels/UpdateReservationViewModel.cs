using Hotel_Una.Commands;
using Hotel_Una.Models;
using Hotel_Una.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel_Una.ViewModels
{
    public class UpdateReservationViewModel: BaseViewModel
    {
        private int _reservationID;
        public int ReservationID
        {
            get => _reservationID;
            set
            {
                _reservationID = value;
                OnPropertyChanged(nameof(ReservationID));
            }
        }
        public ICommand SearchCommand { get; }
        public ICommand UpdateReservationCommand { get; }
        public ICommand CancelCommand { get; }
        public UpdateReservationViewModel(Hotel hotel, NavigationService navigationService)
        {
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
