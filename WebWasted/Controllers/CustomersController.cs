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
        //private readonly IDataContext _dataContext;
        private readonly IItemService _itemService;
        private readonly IUserService _userService;
        public CustomersController(IConfiguration configuration, 
            IItemService itemService, IUserService userService)
        {
            _configuration = configuration;
            //_dataContext = dataContext;
            _itemService = itemService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            using (IDataContext dataContext = new DataContext())
            {
                return _userService.GetCustomerList(id, dataContext);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ApproveOrderDto args)
        {
            using (IDataContext dataContext = new DataContext())
            {
                if (_itemService.ApproveOrder(args.orderID, args.isApproved, dataContext) != 1)
                {
                    return BadRequest();
                }
                return Ok();
            }
        }
    }
}
