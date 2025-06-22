using Hotel_Una.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.DatabaseContext
{
    public class HotelDbContext: DbContext
    {
        public HotelDbContext(DbContextOptions options): base(options) { }
        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
