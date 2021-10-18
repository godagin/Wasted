using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted
{
    public class Food
    {
        [Key]
        public int ID { get; set; }
        public string fieldToText { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double FullPrice { get; set; }
        public int Type { get; set; }
        public DateTime ExpDate { get; set; }

        public Food() { ID++; }
      
        public Food(string name, string description, double fullPrice, int expDays = 2)
        {
            this.Name = name;
            this.Description = description;
            this.FullPrice = fullPrice;
            //this.Amount = amount;

            Type = (int)Category.Other;

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

        [Flags]
        enum Category
        {
            Vegetables = 1,
            Fruits = 2,
            Fish_and_Seafood = 3,
            Meat_and_Poultry = 4,
            Dairy = 5,
            Grains_Beans_and_Nuts = 6,
            Sweets = 7,
            Soups = 8,
            Meals = 9,
            Bakery = 10,
            Confectionery = 11,
            Other = 12
        };

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
    }
}

