using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Controllers
{

    [ApiController]
    [Route("api/contacts")]

    public class ContactsController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ContactsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public String Get(int id)
        {
            Console.WriteLine("test");

            lock (DatabaseHandler.Instance.dc)
            {
                Console.WriteLine("test1");
                var owner = (from user in DatabaseHandler.Instance.dc.Users where user.ID == id select user).FirstOrDefault();

                if (owner == null)
                {
                    return "";
                }
   

                String json = " [ {\"Mail\": \"" + owner.ContactEmail + "\"} ]";
     
                Console.WriteLine(json);

                Console.WriteLine("test3");


                return json;
            }
            
        }

        

    }
}
