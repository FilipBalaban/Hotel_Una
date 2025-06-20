using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Models
{
    public class Reservation
    {
        private static int _objectCounter;
        private bool _objectCounterIncreased;
        public int ID { get; }
        public int RoomNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ReservationDate { get; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfGuests { get; set; }

        // From DB
        public Reservation(int iD, int roomNum, string firstName, string lastName, DateTime startDate, DateTime endDate, int numberOfGuests)
        {
            ID = iD;
            RoomNum = roomNum;
            FirstName = firstName;
            LastName = lastName;
            ReservationDate = DateTime.Now;
            StartDate = startDate;
            EndDate = endDate;
            NumberOfGuests = numberOfGuests;
        }
        // From VM
        public Reservation(int roomNum, string firstName, string lastName, DateTime startDate, DateTime endDate, int numberOfGuests)
        {
            _objectCounter++;
            _objectCounterIncreased = true;
            ID = _objectCounter;
            RoomNum = roomNum;
            FirstName = firstName;
            LastName = lastName;
            ReservationDate = DateTime.Now;
            StartDate = startDate;
            EndDate = endDate;
            NumberOfGuests = numberOfGuests;
        }
        ~Reservation()
        {
            if (_objectCounterIncreased)
            {
                _objectCounter--;
            }
        }
        public bool CausesConflicts(Reservation reservation)
        {
            if(RoomNum != reservation.RoomNum || ID == reservation.ID)
            {
                return false;
            }
            return reservation.StartDate < EndDate && reservation.EndDate > StartDate;
        }
    }
}
