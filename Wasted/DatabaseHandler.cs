using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Wasted
{
    class DatabaseHandler
    {
        public DataContext dc = new DataContext();
        public DatabaseHandler()
        {

        }
        
        public void AddItemToFoodTable(Food item)
        {
            dc.Foods.Add(item);
            dc.SaveChanges();
        }

        public void LoadFoodList()
        {
            foreach(Food item in dc.Foods)
            {
                FoodList.GetObject().AddCreatedFood(item);
            }    
        }


        public void RemoveItemFromFoodTable(Food item)
        {
            dc.Foods.Remove(item);
            dc.SaveChanges();
        }

        public void RemoveAllFromFoodTable()
        {
            foreach (Food item in dc.Foods) //remove from database table
            {
                dc.Foods.Remove(item);
            }
            dc.SaveChanges();
        }
    }
}
