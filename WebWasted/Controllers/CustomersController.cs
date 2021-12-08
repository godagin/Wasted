using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;
using WebWasted.Services;
using WebWasted.Models.DTOs;

namespace WebWasted.Controllers
{
    [ApiController]
    [Route("api/customers")]
 
    public class CustomersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        public CustomersController(IConfiguration configuration, IDataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [HttpGet("{id}")] 
        public List<Order> Get(int id)
        {
            UserService userService = new UserService(_dataContext);
            return userService.GetCustomerList(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ApproveOrderDto args)
        {
            ItemService itemService = new ItemService(_dataContext);
            if (itemService.ApproveOrder(args.orderID, args.isApproved) != 1)
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
