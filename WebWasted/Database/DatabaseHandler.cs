
using System;

namespace WebWasted
{
    public class DatabaseHandler
    {
        //application start
        private static readonly Lazy<DatabaseHandler> lazy =
            new Lazy<DatabaseHandler>(() => new DatabaseHandler());

        public static DatabaseHandler Instance { get { return lazy.Value; } }

        public DataContext dc = new DataContext();
        
        private DatabaseHandler()
        {
            Food.FoodCreatedEvent += AddItemToFoodTable;
        }

        public void AddItemToFoodTable(Food item)
        {
            dc.Foods.Add(item);
            dc.SaveChanges();
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

        public void EditFoodTableItem(Food food)
        {
            dc.Foods.Find(food.ID).Name = food.Name;
            dc.Foods.Find(food.ID).Description = food.Description;
            dc.Foods.Find(food.ID).FullPrice = food.FullPrice;
            dc.Foods.Find(food.ID).Type = food.Type;
            dc.Foods.Find(food.ID).ExpDate = food.ExpDate;

            if (food.GetType() == typeof(WeighedFood))
            {
                ((WeighedFood)dc.Foods.Find(food.ID)).Weight = ((WeighedFood)food).Weight;
            }
            else if(food.GetType() == typeof(DiscreteFood))
            {
                ((DiscreteFood)dc.Foods.Find(food.ID)).Quantity = ((DiscreteFood)food).Quantity;
            }
            dc.SaveChanges();
        }
    }
}
