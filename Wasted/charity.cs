using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class Charity
    {
        public CharityInfo About = new CharityInfo();

        private List<Food> CharityOrders = new List<Food>(); //food has to have priority

        public Charity(string name)
        {
            About.Name = name;
            
        }
        
        public void AddCharityOrder(Food foodItem)
        {
            CharityOrders.Add(foodItem);
        }

        public void RemoveCharityOrder(Food foodItem)
        {
            CharityOrders.Remove(foodItem);
        }
       
        public void PrioritizeCharityOrder(Food foodItem)
        {
            RemoveCharityOrder(foodItem);
            CharityOrders.Insert(0, foodItem);
        }
/*
        public void VerifyCharity() /// so that fake charities wouldn't be created
        {
            if (!verified)
            {
                verified = true;
            }
        }
*/
    }
 
}
