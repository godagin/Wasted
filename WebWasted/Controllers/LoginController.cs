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
            lock (DatabaseHandler.Instance.dc.Users)
            {
                var findUser = (from user in DatabaseHandler.Instance.dc.Users where user.UserName == Credentials.UserName && user.Password == Credentials.Password select user).FirstOrDefault();
                if (findUser == null)
                {
                    return -1;
                }
                //Console.WriteLine("yes " + findUser.ID);
                return findUser.ID;
            }
        }
    }
}
