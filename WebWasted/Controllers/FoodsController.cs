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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebWasted.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IItemService _itemService;
        //private readonly IDataContext _dataContext;
        private readonly IWebHostEnvironment _env;
        public FoodsController(IConfiguration configuration, IWebHostEnvironment env, IItemService itemService)
        {
            _configuration = configuration;
            _env = env;
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
        /*
        [HttpGet("{id}")]      //e.g. https://localhost:5000/api/foods/3
        public IEnumerable<Food> Get(int id)
        {
            using (IDataContext dataContext = new DataContext())
            {
                return _itemService.GetUserOffers(id, dataContext);
            }

        }
        */

        //create food offer
        [HttpPost]
        public IActionResult Post([FromBody] GeneralFoodDto args)
        {
            using (IDataContext dataContext = new DataContext())
            {
                if (_itemService.CreateFoodOffer(args, dataContext) != 1)
                {
                    return BadRequest();
                }
                return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (IDataContext dataContext = new DataContext())
            {
                if (_itemService.DeleteOffer(id, dataContext) != 1)
                {
                    return BadRequest();
                }
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] GeneralFoodDto args)
        {
            using (IDataContext dataContext = new DataContext())
            {
                if (_itemService.EditOffer(id, args, dataContext) != 1)
                {
                   return BadRequest();
                }
                return Ok();
            }
        }

        [HttpGet("{searchString}")]
        public IEnumerable<Food> Get(string searchString)
        {
            using (IDataContext dataContext = new DataContext())
            {
                return _itemService.GetSearchedOffers(searchString, dataContext);
            }
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
