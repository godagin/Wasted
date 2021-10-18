using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class WeighedFood : Food
    {
        public double Weight { get; set; }

        public WeighedFood() { ID++; }

        public WeighedFood(string name, string description, double fullPrice, double weight, int expDays = 2) : base(name, description, fullPrice, expDays)
        {
            Weight = weight;
        }
       
        public double TakeFood(double take)
        {
            if (Weight <= take)
            {
                //what if Weight == take, Food Offer must be removed from list
                Weight -= take;
                return take; /// maybe return a new object with new Weight?
            }
            else
            {
                //same poroblem with Weight = 0, offer must be removed
                double quantityTemp = Weight;
                Weight = 0;
                return quantityTemp;
                ///throw new NotSuitableAmountException(); // fix after merge
            }

        }

    }
   
}
