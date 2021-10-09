using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Entity;

namespace Wasted
{
    class DataContext : DbContext
    { 
        public DataContext() : base("LeftOverDB")
        {
            if (!Database.Exists("LeftOverDB"))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }
        

        public DbSet<Food> Foods { get; set; }

    }
}