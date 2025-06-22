using Hotel_Una.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.Services.ReservationManagers
{
    public interface IReservationManager
    {
        public Task AddReservation(Reservation reservation);
        public Task RemoveReservation(Reservation reservation);
        public Task UpdateReservation(Reservation newReservation);
        public Task<IEnumerable<Reservation>> GetReservations();
    }
}
