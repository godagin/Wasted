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
using System.Data.Entity;

namespace WebWasted.Controllers
{
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
        public async Task<IEnumerable<Food>> Get()
        {
            using (var dataContext = new DataContext())
            {
                return await dataContext.Foods.ToListAsync();
            }
        }

        [HttpGet("{id}")]      //e.g. https://localhost:5000/api/foods/3
        public IEnumerable<Food> Get(int id)
        {
            Lazy<List<Food>> offersLazy = new Lazy<List<Food>>();

            using (var dataContext = new DataContext())
            {
                var myOffers = from food in dataContext.Foods where food.OwnerID.Equals(id) select food;
                foreach (var item in myOffers)
                {
                    offersLazy.Value.Add(item);
                }
            }
            return offersLazy.Value.ToList();
        }


        [HttpPost]
        public async Task<IActionResult> Post(int type, int owner, string name, string description, double fullPrice, double amount, Category foodType, int expTime = 3)
        {

            Food food = null;

            switch (type)
            {

                case 1: // food obj is weighed
                    try
                    {
                        food = new WeighedFood(owner, name, description, fullPrice, foodType, amount, expTime);
                    }

                    catch(InvalidCastException)

                    {
                        Console.WriteLine("The creation of a weighed food offer failed.");
                    }
                    break;
                case 2:
                    try
                    {
                        food = new DiscreteFood(owner, name, description, fullPrice, foodType, (int)amount, expTime);
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("The creation of a discrete food offer failed.");
                    }
                    break;
                default:
                    food = new Food(owner, name, description, foodType, expTime);
                    break;
            }
            
            using (var dataContext = new DataContext())
            {
                    dataContext.Foods.Add(food);
                    await dataContext.SaveChangesAsync();
                    return Ok();
            }
        }
        /*
        [HttpPut]
        public JsonResult Put(Food food)
        {
            string query = @"
                    update dbo.Foods set
                    Name = '" + food.Name + @"'
                    ,Description = '" + food.Description + @"'
                    ,FullPrice = '" + food.FullPrice + @"'
                    where ID = '" + food.ID + @"'
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("FoodsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Foods
                    where ID = '" + id + @"'
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("FoodsAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
        */
    }
}
