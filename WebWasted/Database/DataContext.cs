using System.Data.Entity;
using WebWasted.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WebWasted
{
    public class DataContext : DbContext, IDataContext
    {

        public DataContext() : base("LeftOverDB")
        {
            if (!Database.Exists("LeftOverDB"))
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            }

        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
        
        public void LoadUser(User user)
        {
            this.Entry(user).Collection(o => o.Orders).Load();
        }
        
    }
}