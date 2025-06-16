using Hotel_Una.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.ViewModels
{
    public class ReservationViewModel
    {
        private readonly Reservation _reservation;

        public int ID => _reservation.ID;
        public int RoomNum => _reservation.RoomNum;
        public string FirstName => _reservation.FirstName;
        public string LastName => _reservation.LastName;
        public DateTime ReservationDate => _reservation.ReservationDate;
        public DateTime StartDate => _reservation.StartDate;
        public DateTime EndDate => _reservation.EndDate;
        public int NumberOfGuests => _reservation.NumberOfGuests;

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
