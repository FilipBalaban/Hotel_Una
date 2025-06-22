using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Una.DatabaseContext
{
    public class HotelDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
    {
        public HotelDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R16IC6C;Initial Catalog=HotelUnaDb;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            return new HotelDbContext(optionsBuilder.Options);
        }
    }
}
