using MyRental.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRental.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> Types { get; set; }

    }
}
