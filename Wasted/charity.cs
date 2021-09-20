using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class Charity
    {
        public string Name { get; set; }
        public string Contacts { get; set; }
        public string About { get; set; }
        
        private bool verified;

        private List<Food> CharityOrders; //food has to have priority

        public Charity(string name)
        {
            this.Name = name;
            verified = false;
            CharityOrders = new List<Food>();
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

        public void VerifyCharity() /// so that fake charities wouldn't be created
        {
            if (!verified)
            {
                verified = true;
            }
        }
    }
 
}
