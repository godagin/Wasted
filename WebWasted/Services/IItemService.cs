using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Models;
using WebWasted.Models.DTOs;

namespace WebWasted.Services
{
    public interface IItemService
    {
        Food FindItemByID(int ID, IDataContext dataContext);
        
        Order FindOrderByID(int ID, IDataContext dataContext);
        
        List<Food> GetUserOffers(int userID, IDataContext dataContext);

        Food CreateFoodOffer(GeneralFoodDto args, IDataContext dataContext);
        
        int PlaceOrder(User user, int foodID, double amount, IDataContext dataContext);      

        int DeleteOrder(int orderID, IDataContext dataContext);

        int ApproveOrder(int orderID, Boolean isApproved, IDataContext dataContext);
    }
}

