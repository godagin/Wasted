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
        //private readonly IDataContext _dataContext;
        private readonly IUserService _userService;
        public LoginController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
           
            _userService = userService;
        }

        [HttpPost]
        public int Post([FromBody] LoginUserDto credentials)
        {
            using (IDataContext dataContext = new DataContext())
            {
                return _userService.LoginUser(credentials, dataContext);
            }
                
        }
    }
}
