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
        public DataContext() : base("FoodDB")
        {
            if (!Database.Exists("FoodDB"))
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }


        public DbSet <Food> foods { get; set; }

        
       
        

    }
}
