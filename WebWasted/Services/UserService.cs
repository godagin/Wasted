using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Controllers;
using WebWasted.Models;
using WebWasted.Models.DTOs;

namespace WebWasted.Services
{
    //user service deals with users
    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public User FindUserByID(int ID, IDataContext dataContext)
        {
            User user = dataContext.Users.Where(user => user.ID == ID).FirstOrDefault();
            return user;
        }

        public List<Order> GetOrderList(int userID, IDataContext dataContext)
        {
            dataContext.LoadUser(FindUserByID(userID, dataContext));
            Console.WriteLine(userID);
            var orderList = dataContext.Orders.Include("FoodOrder").Where(order => order.Buyer.ID == userID);
           /* var orderList = from order in dataContext.Orders
                           where order.Buyer.ID == userID
                           select order;
          */
            foreach(var order in orderList)
            {
                Console.WriteLine(order.FoodOrder);
            }
           
            
            return orderList.ToList(); 
        }

        public List<Order> GetCustomerList(int userID, IDataContext dataContext)
        {
            dataContext.LoadUser(FindUserByID(userID, dataContext));

            var ordersList = from order in dataContext.Orders
                             where order.FoodOrder.OwnerID == userID
                             select order;
            return ordersList.ToList();
        }

        public int LoginUser(LoginUserDto args, IDataContext dataContext)
        {
            User loggedUser = (from user in dataContext.Users 
                         where user.UserName == args.UserName && user.Password == args.Password 
                         select user).FirstOrDefault();
            if (loggedUser == null)
            {
                return -1;
            }
            return loggedUser.ID;
        } 

        public int RegisterUser(User user, IDataContext dataContext)
        {
            if (dataContext.Users.Any(u => u.UserName == user.UserName))
            {
                return -1;
            }

            User newUser = new User(user.UserName, user.Name, user.Surname, user.ContactEmail, user.Password);
            dataContext.Users.Add(newUser);
            dataContext.Save();
            return 1;
        }  
    }
}
