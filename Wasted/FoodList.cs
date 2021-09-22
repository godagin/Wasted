using System;
using System.Collections.Generic;
using System.Text;

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

        public void AddCreatedFood(string name, string description, double price, double amount)
        {
            FoodOffers.Add(new Food(name, description, price, amount));
        }
    }
}
