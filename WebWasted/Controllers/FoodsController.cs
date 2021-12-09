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

using WebWasted.Services;

namespace WebWasted.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly IDataContext _dataContext;
        private readonly IItemService _itemService;

        public FoodsController(IConfiguration configuration, IItemService itemService)
        {
            _configuration = configuration;

            _itemService = itemService;
        }

        //gets the general available food list
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            using (IDataContext dataContext = new DataContext())
            {
                return dataContext.Foods.ToList();
            }

        }


        [HttpGet("{id}")]      //e.g. https://localhost:5000/api/foods/3
        public IEnumerable<Food> Get(int id)
        {
            using (IDataContext dataContext = new DataContext())
            {
                return _itemService.GetUserOffers(id, dataContext);
            }

        }

        //create food offer
        [HttpPost]
        public IActionResult Post([FromBody] GeneralFoodDto args)
        {
            using (IDataContext dataContext = new DataContext())
            {
                if (_itemService.CreateFoodOffer(args, dataContext) != null)
                {
                    return Ok();
                }
                return BadRequest();
            }

        }
    }
}
