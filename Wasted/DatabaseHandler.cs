using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Wasted
{
    class DatabaseHandler
    {
        public DataContext dc = new DataContext();
        private static DatabaseHandler _obj = null;
        
        private DatabaseHandler()
        {

        }

        public static DatabaseHandler GetHandler()
        {
            if (_obj == null)
            {
                _obj = new DatabaseHandler();
            }
            return _obj;
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
