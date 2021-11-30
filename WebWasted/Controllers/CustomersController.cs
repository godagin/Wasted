using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;

namespace WebWasted.Controllers
{
    public class OrderArg
    {
        public int orderID;
        public Boolean isApproved;
    }

    [ApiController]
    [Route("api/customers")]
    
    public class CustomersController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CustomersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            lock (DatabaseHandler.Instance.dc)
            {
                var customerList = DatabaseHandler.Instance.dc.Orders.Where(order => order.FoodOrder.OwnerID == id);

                return customerList.ToList();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderArg orderArg)
        {
            lock (DatabaseHandler.Instance.dc)
            {

                var findOrder = (DatabaseHandler.Instance.dc.Orders.Where(order => order.ID == orderArg.orderID)).FirstOrDefault();
                if (findOrder != null)
                {
                    findOrder.Approved = orderArg.isApproved;
                    DatabaseHandler.Instance.dc.SaveChanges();
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
