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
            optionsBuilder.UseSqlServer(_connectionString);
            return new HotelDbContext(optionsBuilder.Options);
        }
    }
}
