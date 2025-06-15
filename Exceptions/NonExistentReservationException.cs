using Hotel_Una.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Exceptions
{
    public class NonExistentReservationException : Exception
    {
        public Reservation Reservation { get; }
        public NonExistentReservationException(Reservation reservation)
        {
            Reservation = reservation;
        }

        public NonExistentReservationException(string? message, Reservation reservation) : base(message)
        {
            Reservation = reservation;
        }

        public NonExistentReservationException(string? message, Exception? innerException, Reservation reservation) : base(message, innerException)
        {
            Reservation = reservation;
        }

        protected NonExistentReservationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
