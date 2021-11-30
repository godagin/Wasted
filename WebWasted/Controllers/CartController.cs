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


        //gets the cart items of user specified by ID
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            lock (DatabaseHandler.Instance.dc)
            {
                var userCart = from order in DatabaseHandler.Instance.dc.Orders
                               where order.Buyer.ID == id
                               select order;

                return userCart.ToList();
            }
        }
        
       //prideti i krepseli
        [HttpPost]
        public IActionResult Post([FromBody] CartArguments IDS)
        {
            lock (DatabaseHandler.Instance.dc)
            {
                //finds item in database
                Food findItem = DatabaseHandler.Instance.dc.Foods.ToList().Find(
                    delegate (Food item)
                    {
                        return item.ID == IDS.foodID;
                    }
                );
                User findUser = DatabaseHandler.Instance.dc.Users.ToList().Find(
                   delegate (User user)
                   {
                       return user.ID == IDS.userID;
                   }
               );

                //if item found, creates an order 
                if (findItem != null)
                {
                    Order order = new Order();
                    order.FoodOrder = findItem;
                    order.Buyer = findUser;
                    order.Amount = 1;//pakeisti!!!! IR prideti patikrinima
                    order.Approved = false;
                    DatabaseHandler.Instance.dc.Orders.Add(order);

                    findUser.Orders.Add(order);
                    DatabaseHandler.Instance.dc.SaveChanges();
                }
                else
                {
                   // Console.WriteLine("not found");
                    return BadRequest();
                }

                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            lock (DatabaseHandler.Instance.dc)
            {
 
                var findOrder = (DatabaseHandler.Instance.dc.Orders.Where(order => order.ID == id)).FirstOrDefault();

                if (findOrder != null)
                {
                    DatabaseHandler.Instance.RemoveItemFromOrderTable(findOrder);
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