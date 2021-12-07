using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Models.DTOs
{
    public class GeneralFoodDto
    {
        public int type;
        public int owner;
        public string name;
        public string description;
        public double fullPrice;
        public double amount;
        public Category foodType;
        public int expTime = 3;
        public string fileName;
    }
}
