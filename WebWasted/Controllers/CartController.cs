using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;
using WebWasted.Models.DTOs;
using WebWasted.Services;


///NOTES:
    // + // pasidaryt item service ir user service kad atsiskirtu logika nuo get ir post
    // + // panaikinti lock, naudojant dependency injection datacontext'ui ir datacontext kurima perkelti i startup
    // + // get ir post funkciju duomenims is body gauti susikurti dto's kazkur atskirai?
    // + // pakeisti IDS i koki kitoki pavadinima
    // 
    // + // sutvarkyti funkcionaluma idejimo i krepseli, kad detu po tam tikra kieki 


namespace WebWasted.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        public CartController(IConfiguration configuration, IDataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        //gets the cart items of user specified by ID
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            UserService userService = new UserService(_dataContext);
            return userService.GetOrderList(id);
        }

        //adds to cart
        [HttpPost]
        public IActionResult Post([FromBody] AddToCartDto args)
        {
            UserService userService = new UserService(_dataContext);
            ItemService itemService = new ItemService(_dataContext);

            if( itemService.PlaceOrder(userService.FindUserByID(args.userID), args.foodID, args.amount) != 1)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}