﻿using Microsoft.AspNetCore.Http;
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
            
            using(DataContext context = new DataContext())
            {

                if (context.Users.Any(u => u.UserName == user.UserName))
                {
                    //Console.WriteLine("if");
                    return -1;
                }
                //Console.WriteLine("ne if");
                User newUser = new User(user.UserName, user.Name, user.Surname, user.ContactEmail, user.Password);
                context.Users.Add(newUser);
                context.SaveChanges();
                //Console.WriteLine(newUser.ID);
                return newUser.ID;

            }
        }
    }
}