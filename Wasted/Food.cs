using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wasted
{
    class Food
    {

        public Food() { ID++; }
      
        public Food(string foodName, string foodDescription, double fullPrice, double amount)
        {
            this.FoodName = foodName;
            this.FoodDescription = foodDescription;
            this.FullPrice = fullPrice;
            this.Amount = amount;
            ID++;
        }

        public Food(string foodName, string foodDescription, double amount)
        {
            this.FoodName = foodName;
            this.FoodDescription = foodDescription;
            this.Amount = amount;
            ID++;
        }

        [Key]
        public int ID { get; set; }
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

        public string SetExpDate(int days)
        {
            return DateTime.Now.AddDays(days).ToString("dd.MM.yy");
        }


        //if amount is kg, g
        public double TakeFood(double take)
        {
            if (Amount <= take)
                return Amount - take;
            else throw new NotSuitableAmountException();
        }

    }
}

