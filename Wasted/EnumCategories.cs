using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class EnumCategories
    {
        [Flags]
        enum FoodType { Vegetables = 1, Fruits = 2, Fish_and_Seafood = 3, Meat_and_Poultry = 4, Dairy = 5, Grains_Beans_and_Nuts = 6,
            Sweets = 7, Soups = 8, Meals = 9, Other = 10 };

    }
}
