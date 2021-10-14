using System.Collections.Generic;

namespace Wasted
{
    // singleton
    class FoodList
    {
        List<Food> FoodOffers;
        private static FoodList _obj = null;
        private FoodList()
        {
            FoodOffers = new List<Food>();
        }
        /*
        private FoodList(List<Food> foods)
        {
            FoodOffers = foods;
        }
        */
        public static FoodList GetObject()
        {
            if(_obj == null)
            {
                _obj = new FoodList();
            }
            return _obj;
        }

        public void AddCreatedFood(string name, string description, double price, double amount, int expDays = 2)
        {
            FoodOffers.Add(new Food(name, description, price, expDays));
        }
        public void AddCreatedFood(Food food)
        {
            FoodOffers.Add(food);
        }
        public List<Food> GetList()
        {
            return FoodOffers;
        }

        public void RemoveItem(int index)
        {
            FoodOffers.RemoveAt(index);
        }

        public void RemoveAll()
        {
            FoodOffers.Clear();
        }
        
    }
}
