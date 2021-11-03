
namespace WebWasted
{
    public class DiscreteFood : Food
    {
        public int Quantity { get; set; }

        public DiscreteFood() : base() { }

        public DiscreteFood(string name, string description, double fullPrice, int type, int quantity, int expDays = 2) 
            : base(name, description, fullPrice, type, expDays)
        {
            Quantity = quantity;
        }
       
        public int TakeFood(int take)
        {
            if (Quantity <= take)
            {
                //what if Quantity == take, Food Offer must be removed from list
                Quantity -= take;
                return take; /// maybe return a new object with new quantity?
            }
            else
            {
                //same poroblem with Quantity = 0, offer must be removed
                int quantityTemp = Quantity;
                Quantity = 0;
                return quantityTemp;
                ///throw new NotSuitableAmountException(); // fix after merge
            }
            
        }
    }
}
