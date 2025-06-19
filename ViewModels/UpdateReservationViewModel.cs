using Hotel_Una.Commands;
using Hotel_Una.Models;
using Hotel_Una.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel_Una.ViewModels
{
    public class UpdateReservationViewModel: BaseViewModel
    {
        private int _reservationID;
        private UIElement _reservationInputContentControl;
        public int ReservationID
        {
            get => _reservationID;
            set
            {
                _reservationID = value;
                OnPropertyChanged(nameof(ReservationID));
            }
        }
        public UIElement ReservationInputContentControl
        {
            get => _reservationInputContentControl;
            set
            {
                _reservationInputContentControl = value;
                OnPropertyChanged(nameof(ReservationInputContentControl));
            }
        }
        public ReservationViewModel ReservationViewModel { get; set; }
        public ICommand SearchCommand { get; }
        public ICommand UpdateReservationCommand { get; }
        public ICommand CancelCommand { get; }
        public UpdateReservationViewModel(Hotel hotel, NavigationService navigationService)
        {
            SearchCommand = new SearchCommand(hotel, this);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
