using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;

namespace WebWasted.Controllers
{
    public class CartArguments
    {
        public int userID;
        public int foodID;
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpPost]
        public int Post([FromBody] CartArguments IDS)
        {
            using (DataContext context = new DataContext())
            {
                var findFood = (from food in context.Foods where food.ID == IDS.foodID select food).First();

                if ((findFood == null) || (IDS.userID == findFood.OwnerID))
                {
                    return -1;
                }

                findFood.BuyerID = IDS.userID;
                
                return findFood.BuyerID;
            }
        }
    }
}