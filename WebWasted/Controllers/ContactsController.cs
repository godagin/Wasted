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
            String email = "";

            using (DataContext context = new DataContext())
            {

                var owner = (from user in context.Users where user.ID == id select user).FirstOrDefault();

                if (owner == null)
                {
                    email = "no email";
                }    
                else
                {
                    email = owner.ContactEmail;
                }

                return email;

            }
        }

 
    }
}
