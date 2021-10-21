using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    public static class ExtendedMethods
    {
        public static WeighedFood GetMostWeightingFood(this List<Food> foods)
        {
            WeighedFood maxFood = null;
            foreach(Food food in foods)
            {
                if(maxFood == null && food is WeighedFood)
                {
                    maxFood = (WeighedFood) food;
                }
                if(food is WeighedFood)
                {
                    if(((WeighedFood) food).Weight > maxFood.Weight)
                    {
                        maxFood = (WeighedFood) food;
                    }
                }
            }
            return maxFood;
        }

        public static DiscreteFood GetMostQuantityDiscreteFood(this List<Food> foods)
        {
            DiscreteFood maxFood = null;
            foreach (Food food in foods)
            {
                if (maxFood == null && food is DiscreteFood)
                {
                    maxFood = (DiscreteFood)food;
                }
                if (food is DiscreteFood)
                {
                    if (((DiscreteFood)food).Quantity > maxFood.Quantity)
                    {
                        maxFood = (DiscreteFood)food;
                    }
                }
            }
            return maxFood;
        }
    }
}
