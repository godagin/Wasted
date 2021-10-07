using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class WeighedFood
    {
        public double Weight { get; set; }

        public double TakeFood(double take)
        {
            if (Weight <= take)
            {
                //what if Quantity == take, Food Offer must be removed from list
                Weight -= take;
                return take; /// maybe return a new object with new quantity?
            }
            else
            {
                //same poroblem with Quantity = 0, offer must be removed
                double quantityTemp = Weight;
                Weight = 0;
                return quantityTemp;
                ///throw new NotSuitableAmountException(); // fix after merge
            }

        }
    }
}
