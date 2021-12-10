﻿using Microsoft.AspNetCore.Http;
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
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IItemService _itemService;
        //private readonly IDataContext _dataContext;
        public HomeController(IConfiguration configuration, IItemService itemService)
        {
            _configuration = configuration;
            _itemService = itemService;
        }

        [HttpGet]
        public IEnumerable<Food> GetFirst()
        {
            using(IDataContext dataContext = new DataContext())
            {
                return _itemService.GetFirstOffers(dataContext);
            }
        }


        [HttpGet]
        [Route("cheapest")]
        public IEnumerable<Food> GetCheapest()
        {
            using(IDataContext dataContext = new DataContext())
            {
                return _itemService.GetCheapestOffers(dataContext);
            }
        }
    }
}
