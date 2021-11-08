using System;
using System.ComponentModel.DataAnnotations;
using WebWasted.Models;

namespace WebWasted
{
    public class Food
    {
        [Key]
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public int BuyerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double FullPrice { get; set; }
        public Category Type { get; set; }
        public DateTime ExpDate { get; set; }

        protected Food()
        {

        }
        
        public Food(int owner, string name, string description, Category type, int expDays)
        {
            this.OwnerID = owner;
            this.Name = name;
            this.Description = description;
            this.FullPrice = 0;
            this.ExpDate = DateTime.Now.AddDays(expDays);
            //Type = (int)Category.Default;
            this.Type = type;
        }

        public Food(int owner, string name, string description, double fullPrice, Category type, int expDays) 
            : this(owner, name, description, type, expDays)
        {    
            this.FullPrice = fullPrice;
            this.ExpDate = DateTime.Now.AddDays(expDays);
        }

        public double CalcPrice(int discountPercentage)
        {
            double price;
            price = FullPrice * (1 - discountPercentage / 100);
            return price;
        }
        
        public int GetShelfDays()
        {
            return (int)(this.ExpDate - DateTime.Now).TotalDays;
        }
    }
}

