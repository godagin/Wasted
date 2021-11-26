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
                var userOffers = from food in DatabaseHandler.Instance.dc.Foods
                               where food.OwnerID == id
                               select food;
                return userOffers.ToList();

           
            }

        }

        [HttpPost]
        public int Post([FromBody] AddedOfferArgs IDS)
        {
            lock (DatabaseHandler.Instance.dc)
            {

                var findItem = (from food in DatabaseHandler.Instance.dc.Foods
                               where food.OwnerID == IDS.userID
                               select food).FirstOrDefault();

                if (findItem != null)
                {
                    DatabaseHandler.Instance.RemoveItemFromFoodTable(findItem);
                }
                else
                {
                    Console.WriteLine("not found");
                    return -1;
                }

                return findItem.OwnerID;

            }

        }


    }
}