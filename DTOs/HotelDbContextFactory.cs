using Hotel_Una.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.DTOs
{
    public class HotelDbContextFactory
    {
        private readonly string _connectionString;
        public HotelDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public HotelDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R16IC6C;Initial Catalog=HotelUnaDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            return new HotelDbContext(optionsBuilder.Options);
        }
    }
}
