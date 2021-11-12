using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public int Post([FromBody] User user)
        {
            //Console.WriteLine(user.UserName + " " + user.Name + " " + user.Surname + " " + user.ContactEmail + " " + user.Password);
            lock(DatabaseHandler.Instance.dc){

                if (DatabaseHandler.Instance.dc.Users.Any(u => u.UserName == user.UserName))
                {

                    return -1;
                }

                User newUser = new User(user.UserName, user.Name, user.Surname, user.ContactEmail, user.Password);
                DatabaseHandler.Instance.dc.Users.Add(newUser);
                DatabaseHandler.Instance.dc.SaveChanges();

                return newUser.ID;
            }
                
        }
    }
}
