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
        Food FindItemByID(int ID);
        
        Order FindOrderByID(int ID);
        
        List<Food> GetUserOffers(int userID);
        List<Food> GetSearchedOffers(string searchString);
        List<Food> GetFirstOffers();
        List<Food> GetCheapestOffers();

        Food CreateFoodOffer(GeneralFoodDto args);
        
        int PlaceOrder(User user, int foodID, double amount);      

        int DeleteOrder(int orderID);

        int DeleteOffer(int foodID);

        int ApproveOrder(int orderID, Boolean isApproved);
    }
}

