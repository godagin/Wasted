using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Controllers
{

    public class LoginArguments
    {
        public String UserName;
        public String Password;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public int Post([FromBody] LoginArguments Credentials)
        {
            using(DataContext context = new DataContext())
            {
                var findUser = (from user in context.Users where user.UserName == Credentials.UserName && user.Password == Credentials.Password select user).First();
                if(findUser == null)
                {
                    return -1;
                }
                //Console.WriteLine("yes " + findUser.ID);
                return findUser.ID;
            }
        }
    }
}
