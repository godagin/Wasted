using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Models.DTOs
{
    public class AddToCartDto
    {
        public int userID;
        public int foodID;
        public double amount;
    }
}
