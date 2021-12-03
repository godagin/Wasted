using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebWasted.Models.DTOs;
using WebWasted.Dummy;
using WebWasted.Services;

namespace WebWasted.Controllers
{
    //public delegate void CreateFoodDelegate(Food food);

    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        public FoodsController(IConfiguration configuration, IDataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        //gets the general available food list
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _dataContext.Foods.ToList();
        }
        

        [HttpGet("{id}")]      //e.g. https://localhost:5000/api/foods/3
        public IEnumerable<Food> Get(int id)
        {
            ItemService itemService = new ItemService(_dataContext);
            
            return itemService.GetUserOffers(id);
        }

        //create food offer
        [HttpPost]
        public IActionResult Post([FromBody] GeneralFoodDto args)
        {
            ItemService itemService = new ItemService(_dataContext);
            if(itemService.CreateFoodOffer(args) != 1)
            {
                return BadRequest();
            }
            return Ok();            
        }
    }
}
