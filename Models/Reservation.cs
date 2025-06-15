using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Models
{
    public class Reservation
    {
        int ID { get; }
        int RoomID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime ReservationDate { get; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        int NumberOfGuests { get; set; }

        // From DB
        public Reservation(int iD, int roomID, string firstName, string lastName, DateTime startDate, DateTime endDate, int numberOfGuests)
        {
            ID = iD;
            RoomID = roomID;
            FirstName = firstName;
            LastName = lastName;
            ReservationDate = DateTime.Now;
            StartDate = startDate;
            EndDate = endDate;
            NumberOfGuests = numberOfGuests;
        }
        // From VM
        public Reservation(int roomID, string firstName, string lastName, DateTime startDate, DateTime endDate, int numberOfGuests)
        {
            RoomID = roomID;
            FirstName = firstName;
            LastName = lastName;
            ReservationDate = DateTime.Now;
            StartDate = startDate;
            EndDate = endDate;
            NumberOfGuests = numberOfGuests;
        }
        public bool CausesConflicts(Reservation reservation)
        {
            if(ID != reservation.ID)
            {
                return false;
            }
            return reservation.StartDate < EndDate && reservation.EndDate > StartDate;
        }
    }
}
