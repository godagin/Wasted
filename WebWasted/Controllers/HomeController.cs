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
        private readonly ItemService _itemService;
        //private readonly IDataContext _dataContext;
        public HomeController(IConfiguration configuration, ItemService itemService)
        {
            _configuration = configuration;
            _itemService = itemService;
        }

        [HttpGet]
        public IEnumerable<Food> GetFirst()
        {
            using(IDataContext dataContext = new DataContext())
            {
                return _itemService.GetFirstOffers(dataContext).ToList();
            }
        }


        [HttpGet]
        [Route("cheapest")]
        public IEnumerable<Food> GetCheapest()
        {
            using(IDataContext dataContext = new DataContext())
            {
                return _itemService.GetCheapestOffers(dataContext).ToList();
            }
        }
    }
}
