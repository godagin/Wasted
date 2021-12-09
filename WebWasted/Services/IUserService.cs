using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;
using WebWasted.Models.DTOs;

namespace WebWasted.Services
{
    public interface IUserService
    {
        public User FindUserByID(int ID, IDataContext dataContext);

        public List<Order> GetOrderList(int userID, IDataContext dataContext);

        public List<Order> GetCustomerList(int userID, IDataContext dataContext);

        public int LoginUser(LoginUserDto args, IDataContext dataContext);

        public int RegisterUser(User user, IDataContext dataContext);
    }
}
