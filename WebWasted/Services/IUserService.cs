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
        User FindUserByID(int ID, IDataContext dataContext);

        List<Order> GetOrderList(int userID, IDataContext dataContext);

        List<Order> GetCustomerList(int userID, IDataContext dataContext);

        int LoginUser(LoginUserDto args, IDataContext dataContext);

        User RegisterUser(User user, IDataContext dataContext);

    }
}
