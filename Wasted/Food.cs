using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted
{
    class Food
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double FullPrice { get; set; }
        //public double Amount { get; set; }
        public FoodType Category { get; set; }

        public DateTime ExpDate { get; set; }
        public Food() { ID++; }
      
        public Food(string name, string description, double fullPrice, int expDays = 2)
        {
            this.Name = name;
            this.Description = description;
            this.FullPrice = fullPrice;
            //this.Amount = amount;
            this.ExpDate = DateTime.Now.AddDays(expDays);
            ID++;
        }

        public Food(string name, string description, int expDays = 2)
        {
            this.Name = name;
            this.Description = description;
            // this.Amount = amount;
            this.ExpDate = DateTime.Now.AddDays(expDays);
            ID++;
        }

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

        

/*
        //if amount is kg, g
        //veliau padaryt try and catch, kuriame grazintu reiksme ir pagal ja apdorotu tolimesnius veiksmus
        public double TakeFood(double take)
        {
            if (Amount <= take)
                return Amount - take;
            else throw new NotSuitableAmountException();
        }
*/

    }
}

