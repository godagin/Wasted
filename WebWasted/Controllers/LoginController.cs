using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models.DTOs;
using WebWasted.Services;

namespace WebWasted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IDataContext _dataContext;
        public LoginController(IConfiguration configuration, IDataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [HttpPost]
        public int Post([FromBody] LoginUserDto credentials)
        {
            UserService userService = new UserService(_dataContext);
            return userService.LoginUser(credentials);
        }
    }
}
