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

            return string.Compare(x.Name, y.Name) * (-1);
        }
    }
    /*
    class AmountSortLowToHigh : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.Amount > y.Amount)
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
            if (x.Amount < y.Amount)
                return 1;
            else if (x.Amount > y.Amount)
                return -1;
            else
                return 0;
        }
    }

    class PriceSortLowToHigh : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.FullPrice == y.FullPrice) // Same price -> sort name A to Z
                return string.Compare(x.FoodName, y.FoodName);
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
                return string.Compare(x.FoodName, y.FoodName);
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
            if (x.OfferExpDate > y.OfferExpDate)
                return 1;
            else if (x.OfferExpDate < y.OfferExpDate)
                return -1;
            else
                return 0;
        }
    }
    class ExpSortHighToLow : IComparer<Food>
    {
        public int Compare(Food x, Food y)
        {
            if (x.OfferExpDate < y.OfferExpDate)
                return 1;
            else if (x.OfferExpDate > y.OfferExpDate)
                return -1;
            else
                return 0;
        }
    }

    */
}