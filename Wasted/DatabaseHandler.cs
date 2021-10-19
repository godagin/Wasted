
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

        public void LoadFoodList()
        {
            foreach (Food item in dc.Foods)
            {
                FoodList.GetObject().AddCreatedFood(item);
            }
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
            if(food.GetType() == typeof(WeighedFood))
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
