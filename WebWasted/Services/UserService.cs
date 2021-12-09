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
    public class UserService
    {
        IDataContext _dataContext;
        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User FindUserByID(int ID)
        {
            User user = _dataContext.Users.ToList().Find(user => user.ID == ID);
            return user;
        }

        public List<Order> GetOrderList(int userID)
        {
            _dataContext.LoadUser(FindUserByID(userID));

            var ordersList = from order in _dataContext.Orders
                           where order.Buyer.ID == userID
                           select order;
            return ordersList.ToList(); 
        }

        public List<Order> GetCustomerList(int userID)
        {
            _dataContext.LoadUser(FindUserByID(userID));

            var ordersList = from order in _dataContext.Orders
                             where order.FoodOrder.OwnerID == userID
                             select order;
            return ordersList.ToList();
        }

        public int LoginUser(LoginUserDto args)
        {
            User loggedUser = (from user in _dataContext.Users 
                         where user.UserName == args.UserName && user.Password == args.Password 
                         select user).FirstOrDefault();
            if (loggedUser == null)
            {
                return -1;
            }
            return loggedUser.ID;
        } 

        public int RegisterUser(User user)
        {
            if (_dataContext.Users.Any(u => u.UserName == user.UserName))
            {
                return -1;
            }

            User newUser = new User(user.UserName, user.Name, user.Surname, user.ContactEmail, user.Password);
            _dataContext.Users.Add(newUser);
            _dataContext.Save();
            return 1;
        }  
    }
}
