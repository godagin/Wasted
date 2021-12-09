using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;

namespace WebWasted.Controllers
{


    public class DummyHandler
    {
        
        public DummyHandler(string message)
        {
            Console.WriteLine(message);
        }


    }


    public delegate void DummyDelegate(string message);

    [ApiController]
    [Route("api/dummy")]
    public class DummyController : ControllerBase
    {

        
        public event DummyDelegate DummyEvent;


        private readonly IConfiguration _configuration;

        public DummyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected virtual void OnAddRequest() //examples showed that this should be a seperate method perhaps for readability
        {
           // FoodCreatedEvent?.Invoke(this);
        }

      


    }
}