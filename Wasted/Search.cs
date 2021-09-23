using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wasted
{
    class Search
    {
        public bool MatchesName(string input, Food food)
        {
            bool result = Regex.IsMatch(food.FoodName, @"(^|;|,)" + Regex.Escape(input) + @"($|;|,)");

            return result;
        }

        public bool MatchesInDescription(string input, Food food)
        {
            bool result = Regex.IsMatch(food.FoodDescription, @"(^|;|,)" + Regex.Escape(input) + @"($|;|,)");

            return result;
        }
    }
}
