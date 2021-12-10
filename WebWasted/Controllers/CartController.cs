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
        //private readonly IDataContext _dataContext;
        private readonly IItemService _itemService;
        private readonly IUserService _userService;
        public CartController(IConfiguration configuration,
            IItemService itemService, IUserService userService)
        {
            _configuration = configuration;
            _itemService = itemService;
            _userService = userService;
        }

        //gets the cart items of user specified by ID
        [HttpGet("{id}")]
        public List<Order> Get(int id)
        {
            using (IDataContext dataContext = new DataContext())
            {
                return _userService.GetOrderList(id, dataContext);
            }
        }
                

        //adds to cart
        [HttpPost]
        public IActionResult Post([FromBody] AddToCartDto args)
        {
            using (IDataContext dataContext = new DataContext())
            {
                Console.WriteLine(args.amount);
                if ( _itemService.PlaceOrder(_userService.FindUserByID(args.userID, dataContext), args.foodID, args.amount, dataContext) != 1)
                {
                    return BadRequest();
                }

                return Ok();
            }
                
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (IDataContext dataContext = new DataContext())
            {
                if (_itemService.DeleteOrder(id, dataContext) != 1)
                {
                    return BadRequest();
                }
                return Ok();
            }
                
        }
    }
}
