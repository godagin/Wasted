using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Services;

namespace WebWasted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;

        public RegisterController(IConfiguration configuration, IDataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [HttpPost]
        public int Post([FromBody] User user)
        {
            UserService userService = new UserService(_dataContext);

            //returns ID if everything is fine
            return userService.RegisterUser(user); 
        }
    }
}
