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

        [HttpGet("{id}")]
        public IEnumerable<Food> Get(int id)
        {
            using (DataContext context = new DataContext())
            {   
               /* var userCart = from food in context.Foods
                               where food.BuyerID == id
                               select food;
               */

                var userC = from food in context.Foods
                            join user in context.Users
                            on food.BuyerID equals user.ID
                            where food.BuyerID == id
                            select new { food.Name, food.Description, food.FullPrice, user.ContactEmail };

               // return userCart.ToList();
                return userC.ToList();
            }
        }

        [HttpPost]
        public int Post([FromBody] CartArguments IDS)
        {
            Food findItem = DatabaseHandler.Instance.dc.Foods.ToList().Find(
                delegate (Food item)
                {
                    return item.ID == IDS.foodID;
                }
            );

            if (findItem != null)
            {
                findItem.BuyerID = IDS.userID;
                DatabaseHandler.Instance.dc.SaveChanges();
            }
            else
            {
                Console.WriteLine("not found");
                return -1;
            }

            return findItem.BuyerID;
        }

    }
}