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
        private readonly List<Room> _rooms;

        public string Name { get; }

        public Hotel(string name)
        {
            _rooms = new List<Room>()
            {
                new Room(1, 1, 3), new Room(2, 2, 1), new Room(3, 3, 2), new Room(4, 4, 2), new Room(5, 5, 2),
            };
            _reservationBook = new ReservationBook();
            Name = name;
        }
        public void AddReservation(Reservation reservation)
        {
            CheckRoomCompatibility(reservation);

            _reservationBook.AddReservation(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            _reservationBook.RemoveReservation(reservation);
        }
        public void UpdateReservation(Reservation newReservation)
        {
            CheckRoomCompatibility(newReservation);
            _reservationBook.UpdateReservation(newReservation);
        }
        public IEnumerable<Reservation> GetReservations()
        {
            return _reservationBook.GetReservations();
        }
        public IEnumerable<Room> GetRooms()
        {
            return _rooms;
        }
        private void CheckRoomCompatibility(Reservation reservation)
        {
            Room room = _rooms.FirstOrDefault(r => r.RoomNum == reservation.RoomNum);
            if (room == null)
            {
                throw new NonExistentRoomException(reservation.RoomNum);
            }
            if (room.Capacity < reservation.NumberOfGuests)
            {
                throw new InsufficientRoomCapacityException(room, reservation.NumberOfGuests);
            }
        }
    }
}
