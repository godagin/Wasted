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
    [Route("api/cart")]
    public class CartController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            using (DataContext context = new DataContext())
            {
                /*var userCart = from food in context.Foods 
                               join user in context.Users on food.BuyerID equals user.ID
                               where food.BuyerID == user.ID 
                               select food;
                */

                var userCart = from user in context.Users
                               join food in context.Foods on user.ID equals food.BuyerID
                               where food.BuyerID == user.ID
                               select food;



                return userCart.ToList();

            }
        }
        
        [HttpPost]
        public int Post([FromBody] CartArguments IDS)
        {
            Console.WriteLine("veikia????");
            using (DataContext context = new DataContext())
            {
                var findFood = (from food in context.Foods where food.ID == IDS.foodID select food).First();
                if ((findFood == null) || (IDS.userID == findFood.OwnerID))
                {
                    return -1;
                }

                if (findFood.BuyerID != IDS.userID)
                {
                    findFood.BuyerID = IDS.userID;
                    context.SaveChanges();
                }
              /*  else
                {
                    findFood.BuyerID = 0;
                    context.SaveChanges();
                }*/
                
                Console.WriteLine("veikia????");
                return findFood.BuyerID;
            }
        }
    }
}