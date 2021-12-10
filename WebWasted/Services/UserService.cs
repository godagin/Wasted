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
        private readonly IDataContext _dataContext;
        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public User FindUserByID(int ID)
        {
            User user = _dataContext.Users.Where(user => user.ID == ID).FirstOrDefault();
            return user;
        }

        public List<Order> GetOrderList(int userID)
        {
            _dataContext.LoadUser(FindUserByID(userID));
            Console.WriteLine(userID);
            var orderList = _dataContext.Orders.Include("FoodOrder").Where(order => order.Buyer.ID == userID);
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

        public List<Order> GetCustomerList(int userID)
        {
            _dataContext.LoadUser(FindUserByID(userID));

            var ordersList = _dataContext.Orders.Include("FoodOrder").Include("Buyer").Where(order => order.FoodOrder.OwnerID == userID);

            foreach (var order in ordersList)
            {
                Console.WriteLine(order.FoodOrder);
            }
            /*
            var ordersList = from order in dataContext.Orders
                             where order.FoodOrder.OwnerID == userID
                             select order;
            */
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

        public User RegisterUser(User user)
        {
            //Console.WriteLine("atejo");
            if (_dataContext.Users.Any(u => u.UserName == user.UserName))
            {
                return null;
            }

            User newUser = user;
            _dataContext.Users.Add(newUser);
            _dataContext.Save();
            return newUser;
        }  
    }
}
