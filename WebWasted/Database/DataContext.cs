using System.Data.Entity;
using WebWasted.Models;

namespace WebWasted
{
    public class DataContext : DbContext
    { 
        public DataContext() : base("LeftOverDB")
        {
            if (!Database.Exists("LeftOverDB"))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }
        

        public DbSet<Food> Foods { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}