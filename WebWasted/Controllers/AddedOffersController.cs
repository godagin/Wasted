using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;

namespace WebWasted.Controllers
{
    public class AddedOfferArgs
    {
        public int userID;
        public int foodID;
    }

    [ApiController]
    [Route("api/addedoffers")]
    public class AddedOffersController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AddedOffersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public List<Food> Get(int id)
        {

            lock (DatabaseHandler.Instance.dc)
            {
                var userOffers = DatabaseHandler.Instance.dc.Foods.Where(food => food.OwnerID == id);
                                
                return userOffers.ToList();

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddedOfferArgs IDS)
        {
            lock (DatabaseHandler.Instance.dc)
            {
                var findItem = (DatabaseHandler.Instance.dc.Foods.Where(food => food.OwnerID == IDS.userID)).FirstOrDefault();
                
                if (findItem != null)
                {
                    DatabaseHandler.Instance.RemoveItemFromFoodTable(findItem);
                    foreach(Order order in DatabaseHandler.Instance.dc.Orders)
                    {
                        if (order.FoodOrder.ID == IDS.foodID)
                        {
                            DatabaseHandler.Instance.dc.Orders.Remove(order);
                            DatabaseHandler.Instance.dc.SaveChanges();
                        }

                    }

                }
                else
                {
                    return BadRequest();
                }

                return Ok();

            }
        }
    }
}
