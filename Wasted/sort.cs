using System;
using System.Collections.Generic;

namespace Wasted
{
    class AlphabeticSortAToZ : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.Name == y.Name) // Same name -> sort price low to high
            {
                if (x.FullPrice > y.FullPrice)
                    return 1;
                else if (x.FullPrice < y.FullPrice)
                    return -1;
                else
                    return 0;
            }
            else
                return string.Compare(x.Name, y.Name);  
        }
    }
    class AlphabeticSortZToA : IComparer<Food>
    {
        public int Compare(Food x, Food y) // Same name -> sort price low to high
        {
            if (x.Name == y.Name)
            {
                if (x.FullPrice > y.FullPrice)
                    return 1;
                else if (x.FullPrice < y.FullPrice)
                    return -1;
                else
                    return 0;
            }
            else
                return string.Compare(x.Name, y.Name) * (-1);
        }
    }
    class PriceSortLowToHigh : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.FullPrice == y.FullPrice) // Same price -> sort name A to Z
                return string.Compare(x.Name, y.Name);
            else if (x.FullPrice > y.FullPrice)
                return 1;
            else if (x.FullPrice < y.FullPrice)
                return -1;
            else
                return 0;
        }
    }
    class PriceSortHighToLow : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.FullPrice == y.FullPrice) // Same price -> sort name A to Z 
                return string.Compare(x.Name, y.Name);
            else if (x.FullPrice < y.FullPrice)
                return 1;
            else if (x.FullPrice > y.FullPrice)
                return -1;
            else
                return 0;
        }
    }

    class ExpSortLowToHigh : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.ExpDate > y.ExpDate)
                return 1;
            else if (x.ExpDate < y.ExpDate)
                return -1;
            else
                return 0;
        }
    }
    class ExpSortHighToLow : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.ExpDate < y.ExpDate)
                return 1;
            else if (x.ExpDate > y.ExpDate)
                return -1;
            else
                return 0;
        }
    }
}