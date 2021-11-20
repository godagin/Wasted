using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using WebWasted.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

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
        private readonly IWebHostEnvironment _env;

        public FoodsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
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
                    //query = query.Where(offer => offer.Name.StartsWith(searchString) || offer.Description.StartsWith(searchString));

                }
                return query.ToList();
            }
            
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using(var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(fileName);
            }
            catch(Exception)
            {
                return new JsonResult("anonymous.jpg");
            }
        }

        /*
        [HttpGet("{id}")]      //e.g. https://localhost:5000/api/foods/3
        public IEnumerable<Food> Get(int id)
        {
            lock (DatabaseHandler.Instance.dc)
            {
                var myOffers = from food in DatabaseHandler.Instance.dc.Foods where food.OwnerID.Equals(id) select food;
                return myOffers.ToList();
            }  
        }
        */

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
