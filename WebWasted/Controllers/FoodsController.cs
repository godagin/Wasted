using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebWasted.Models;

namespace WebWasted.Controllers
{
    public delegate void CreateFoodDelegate(Food food);

    public class NewFoodArguments
    {
        public int type;
        public int owner;
        public string name;
        public string description;
        public double fullPrice;
        public double amount;
        public Category foodType;
        public int expTime = 3;
    }


    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FoodsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return DatabaseHandler.Instance.dc.Foods.ToList();
        }
        
        [HttpGet("{id}")]      //e.g. https://localhost:5000/api/foods/3
        public IEnumerable<Food> Get(int id)
        {
            var myOffers = from food in DatabaseHandler.Instance.dc.Foods where food.OwnerID.Equals(id) select food;
            return myOffers.ToList();
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] NewFoodArguments args)
        {
            Food food = null;
            switch (args.type)
            {
                case 1: // food obj is weighed
                    try
                    {
                        food = new WeighedFood(args.owner, args.name, args.description, args.fullPrice, args.foodType, args.amount, args.expTime);
                    }
                    catch(InvalidCastException)
                    {
                        Console.WriteLine("The creation of a weighed food offer failed.");
                    }
                    break;
                case 2: //food obj is discrete
                    try
                    {
                        food = new DiscreteFood(args.owner, args.name, args.description, args.fullPrice, args.foodType, (int)(args.amount), args.expTime);
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("The creation of a discrete food offer failed.");
                    }
                    break;
                default:
                    food = new Food(args.owner, args.name, args.description, args.fullPrice, args.foodType, args.expTime);
                    break;
            }

            return Ok();            
        }

    }
}
