using System;
using System.Collections.Generic;

namespace Wasted
{
    class Food
    {
       
        public Food(string foodName, string foodDescription, double fullPrice, double amount)
        {
            this.FoodName = foodName;
            this.FoodDescription = foodDescription;
            this.FullPrice = fullPrice;
            this.Amount = amount;
        }


        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public double FullPrice { get; set; }
        public double Amount { get; set; }


       public double CalcPrice(int discountPercentage)
        {
            double price;
            price = FullPrice * (1 - discountPercentage / 100);
            return price;
        }

        public string SetExpDate (int days)
        {
            return DateTime.Now.AddDays(days).ToString("dd.MM.yy");
        }

        
        //if amount is kg, g
        public double TakeFood(double take)
        {
           return Amount - take;
        }


    }
}
