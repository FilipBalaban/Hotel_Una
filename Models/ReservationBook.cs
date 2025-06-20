using Hotel_Una.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }
        public void AddReservation(Reservation reservation)
        {
            foreach(Reservation existingReservation in _reservations)
            {
                if (existingReservation.CausesConflicts(reservation))
                {
                    throw new ReservationConflictsException(existingReservation, reservation);
                }
            }
            _reservations.Add(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            if (!_reservations.Contains(reservation))
            {
                throw new NonExistentReservationException(reservation);
            }
            _reservations.Remove(reservation);
        }
        public void UpdateReservation(Reservation newReservation)
        {
            if (!_reservations.Any(r => r.ID == newReservation.ID))
            {
                throw new NonExistentReservationException(newReservation);
            }
            foreach (Reservation existingReservation in _reservations)
            {
                if (newReservation.CausesConflicts(existingReservation))
                {
                    throw new ReservationConflictsException(existingReservation, newReservation);
                }
            }
            
            _reservations[_reservations.IndexOf(_reservations.FirstOrDefault(r => r.ID == newReservation.ID))] = newReservation;
        }
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservations;
        }
    }
}
