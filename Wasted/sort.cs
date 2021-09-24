using System;
using System.Collections.Generic;

namespace Wasted
{
     class AlphabeticSortAToZ : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            return string.Compare(x.FoodName, y.FoodName);
        }
    }
    class AlphabeticSortZToA : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            return string.Compare(x.FoodName, y.FoodName) * (-1);
        }
    }
    class AmountSortLowToHigh : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.Amount == y.Amount)
                return string.Compare(x.FoodName, y.FoodName);
            else if (x.Amount > y.Amount)
                return 1;
            else if (x.Amount < y.Amount)
                return -1;
            else
                return 0;
        }
    }
    class AmountSortHighToLow : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.Amount == y.Amount)
                return string.Compare(x.FoodName, y.FoodName);
            else if (x.Amount < y.Amount)
                return 1;
            else if (x.Amount > y.Amount)
                return -1;
            else
                return 0;
        }
    }
}