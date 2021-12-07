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
//using WebWasted.Dummy;
using WebWasted.Services;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Xunit;
using Moq;

namespace WebWasted.Controllers
{
    //public delegate void CreateFoodDelegate(Food food);

    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        private readonly IWebHostEnvironment _env;
        public FoodsController(IConfiguration configuration, IDataContext dataContext, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _env = env;
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ItemService itemService = new ItemService(_dataContext);
            if(itemService.DeleteOffer(id) != 1)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] GeneralFoodDto args)
        {
            ItemService itemService = new ItemService(_dataContext);

            if(itemService.EditOffer(id, args) != 1)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("{searchString}")]
        public IEnumerable<Food> Get(string searchString)
        {
            ItemService itemService = new ItemService(_dataContext);
            return itemService.GetSearchedOffers(searchString);
        }




        //save food offer photo
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

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.jpg");
            }
        }
    }

}
