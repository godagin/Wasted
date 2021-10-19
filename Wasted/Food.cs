using System;
using System.ComponentModel.DataAnnotations;

namespace Wasted
{
    public class Food
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double FullPrice { get; set; }
        public int Type { get; set; }
        public DateTime ExpDate { get; set; }

        public Food() { ID++; }

        public Food(string name, string description, int expDays = 2)
            : this()
        {
            this.Name = name;
            this.Description = description;
            this.FullPrice = 0;
            this.ExpDate = DateTime.Now.AddDays(expDays);
            Type = (int)Category.Default;
        }

        public Food(string name, string description, double fullPrice, int expDays = 2) 
            : this(name, description, expDays)
        {
            this.FullPrice = fullPrice;
        }

        [Flags]
        enum Category
        {
            Default = 0,
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

