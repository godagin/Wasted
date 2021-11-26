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
            lock (DatabaseHandler.Instance.dc)
            {
                return DatabaseHandler.Instance.dc.Foods.ToList();
            }

        }
        [HttpGet("{searchString}")]
        public IEnumerable<Food> Get(string searchString)
        {
            lock (DatabaseHandler.Instance.dc)
            {
                var query = from food in DatabaseHandler.Instance.dc.Foods select food;
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(offer => offer.Name.Contains(searchString) || offer.Description.Contains(searchString));
                }
                return query.ToList();
            }

        }
        
        //1uzd paspaudziam checkout i console parasyt kad issicheckoutino per eventa controlleris iskviecia
        //hadleris zinute gali but skirtingu type kad butut generic
        
        //2uzd padaryt uzloginima i faila kad ivyko exception

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
                        //right way butu i faila
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
