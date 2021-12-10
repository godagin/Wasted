
using WebWasted.Models;

namespace WebWasted
{
    public class WeighedFood : Food
    {
        public double Weight { get; set; }

        public WeighedFood() : base() { }

        public WeighedFood(int owner, string name, string description, double fullPrice, Category type, double weight, int expDays = 2) 
            : base(owner, name, description, fullPrice, type, expDays)
        {
            Weight = weight;
        }
       /*
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
       */
    }
   
}
