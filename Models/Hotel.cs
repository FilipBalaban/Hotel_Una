using Hotel_Una.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }

        public Hotel(string name)
        {
            _reservationBook = new ReservationBook();
            Name = name;
        }
        public void AddReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            _reservationBook.RemoveReservation(reservation);
        }
        public void UpdateReservation(Reservation reservation)
        {
            _reservationBook.UpdateReservation(reservation);
        }
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationBook.GetReservations();
        }
    }
}
