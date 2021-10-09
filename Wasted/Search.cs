using System.Text.RegularExpressions;

namespace Wasted
{
    class Search
    {
        public bool MatchesName(string input, Food food)
        {
            bool result = Regex.IsMatch(food.Name, @"(^|;|,)" + Regex.Escape(input) + @"($|;|,)");

            return result;
        }

        public bool MatchesInDescription(string input, Food food)
        {
            bool result = Regex.IsMatch(food.Description, @"(^|;|,)" + Regex.Escape(input) + @"($|;|,)");

            return result;
        }
    }
}
