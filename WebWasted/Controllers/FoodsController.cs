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
            using(var dataContext = new DataContext())
            {
                return dataContext.Foods.ToList();
            }
        }
 
        [HttpPost]
        public IActionResult Post(int type, int owner, string name, string description, double fullPrice, double amount, Category foodType, int expTime = 3)
        {
            Food food= null;
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
                    dataContext.SaveChanges();
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
