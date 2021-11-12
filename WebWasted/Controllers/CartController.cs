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

    public class FoodOwner
    {
        public Food food;
        public User user;
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
        public List<FoodOwner> Get(int id)
        {

            /* var userCart = from food in context.Foods
                            where food.BuyerID == id
                            select food;
            */
            lock (DatabaseHandler.Instance.dc)
            {
                var userCart = DatabaseHandler.Instance.dc.Foods.Where(food => food.BuyerID == id);
                List<FoodOwner> foodOwners = new();
                foreach(var item in userCart)
                {
                    var user = DatabaseHandler.Instance.dc.Users.Find(item.OwnerID);
                    foodOwners.Add(new FoodOwner { food = item, user = user });
                }
               
                foreach(var item in foodOwners)
                {
                    Console.WriteLine(item.user.ContactEmail);
                }
                
                return foodOwners;
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