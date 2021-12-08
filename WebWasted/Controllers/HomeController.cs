using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Services;

namespace WebWasted
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        public HomeController(IConfiguration configuration, IDataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Food> GetFirst()
        {
            ItemService itemService = new ItemService(_dataContext);
            return itemService.GetFirstOffers().ToList();
        }

        
        //[HttpGet]
        //public IEnumerable<Food> GetCheapest()
        //{
        //    ItemService itemService = new ItemService(_dataContext);
        //    return itemService.GetCheapestOffers().ToList();
        //}
    }
}
