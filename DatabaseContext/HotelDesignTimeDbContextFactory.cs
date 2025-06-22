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
            optionsBuilder.UseSqlite(@"Data Source=DESKTOP-92VTUS6\SQLEXPRESS;Initial Catalog=HotelUnaDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            return new HotelDbContext(optionsBuilder.Options);
        }
    }
}
