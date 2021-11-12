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
               
                var userCart = from food in DatabaseHandler.Instance.dc.Foods
                               where food.BuyerID == id
                               select food;

                return userCart.ToList();
            
        }
        
        [HttpPost]
        public int Post([FromBody] CartArguments IDS)
        {
            var findFood = (from food in DatabaseHandler.Instance.dc.Foods where food.ID == IDS.foodID select food).First();
            /* if ((findFood == null) || (IDS.userID == findFood.OwnerID))
            {
                return -1;
            }*/
            if (findFood == null)
            {
                return -1;
            }
            findFood.BuyerID = IDS.userID;
            DatabaseHandler.Instance.dc.SaveChanges();
                

            return findFood.BuyerID;
            
        }
    }
}