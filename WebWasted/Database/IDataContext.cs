using System;
using System.Data.Entity;
using WebWasted.Models;

namespace WebWasted
{
    public interface IDataContext : IDisposable
    {
        DbSet<Food> Foods { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }

        void Save();
        void LoadUser(User user);
    }
}