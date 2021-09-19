using System;

namespace Wasted
{
    class Food
    {
        private string foodName;
        private string foodDescription;
        private double fullPrice;
        private int amount;


        public Food()
        {
            FoodName = this.foodName;
            FoodDescription = this.foodDescription;
            FullPrice = this.fullPrice;
            Amount = this.amount;
        }


        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public double FullPrice { get; set; }
        public int Amount { get; set; }


       public double CalcPrice(int discountPercentage)
        {
            double price;
            price = fullPrice * (1 - discountPercentage / 100);
            return price;
        }

        public string SetExpDate (int days)
        {
            return DateTime.Now.AddDays(days).ToString("dd.MM.yy");
        }

        //if amount is an integer
        public int TakeFood (int take)
        {
            return amount - take;
        }
        //if amount is kg, g
        public double TakeFood(double take)
        {
           return amount - take;
        }

    }
}
