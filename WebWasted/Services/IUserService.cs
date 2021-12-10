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
        User FindUserByID(int ID);

        List<Order> GetOrderList(int userID);

        List<Order> GetCustomerList(int userID);

        int LoginUser(LoginUserDto args);

        User RegisterUser(User user);

    }
}
