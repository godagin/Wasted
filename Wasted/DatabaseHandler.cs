using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Wasted
{
    class DatabaseHandler
    {
        public DatabaseHandler()
        {

        }
        
        public static void AddItemToFoodTable(Food item)
        {
            DataContext dc = new DataContext();
            dc.Foods.Add(item);
            dc.SaveChanges();
        }

        public static void LoadFoodList()
        {
            DataContext dc = new DataContext();
            foreach(Food item in dc.Foods)
            {
                FoodList.GetObject().AddCreatedFood(item);
            }
            
        }


        public static void RemoveItemFromFoodTable(Food item)
        {
            DataContext dc = new DataContext();
            dc.Foods.Remove(item);
            dc.SaveChanges();
        }

        public static void RemoveAllFromFoodTable()
        {
            DataContext dc = new DataContext();
            foreach (Food item in dc.Foods) //remove from database table
            {
                dc.Foods.Remove(item);
            }
            dc.SaveChanges();
        }
    }
}
