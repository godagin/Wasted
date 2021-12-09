using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebWasted.Controllers;
//using WebWasted.Dummy;
using WebWasted.Models;
using WebWasted.Models.DTOs;

namespace WebWasted.Services
{
    //item service deals with items and orders of these items
    public class ItemService
    {
        IDataContext _dataContext;
        public ItemService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Food FindItemByID(int ID)
        {
            Food item = _dataContext.Foods.ToList().Find(item => item.ID == ID);
            return item;
        }

        public Order FindOrderByID(int ID)
        {
            Order item = _dataContext.Orders.ToList().Find(item => item.ID == ID);
            return item;
        }

        public List<Food> GetUserOffers(int userID)
        {
            var myOffers = from food in _dataContext.Foods where food.OwnerID.Equals(userID) select food;
            return myOffers.ToList();
        }

        public int CreateFoodOffer(GeneralFoodDto args)
        {
            Food food = null;
            try
            {
                switch (args.type)
                {
                    case 1:
                        food = new WeighedFood(args.owner, args.name, args.description, args.fullPrice, args.foodType, args.amount, args.expTime);
                        break;
                    case 2:
                        food = new DiscreteFood(args.owner, args.name, args.description, args.fullPrice, args.foodType, (int)(args.amount), args.expTime);
                        break;
                    default:
                        throw new Exception();
                        // creating simple food is not good since it doesn't have amount which breaks logic
                        // food = new Food(args.owner, args.name, args.description, args.fullPrice, args.foodType, args.expTime);
                }
            }
            catch //(Exception e)
            {
                //Console.WriteLine("The creation of a food offer failed.");
               // Logger.Instance.Log(e);
                return -1;
            }
            _dataContext.Foods.Add(food);
            _dataContext.Save();
            return 1;
        }

        public int PlaceOrder(User user, int foodID, double amount)
        {
            Food food = FindItemByID(foodID);

            if (user != null && food != null)
            {
                Order order = new Order();
                if (food.GetType() == typeof(WeighedFood) && ((WeighedFood)food).Weight >= amount)
                { 
                    order.Amount = amount;
                    ((WeighedFood)food).Weight -= amount;

                }
                else if(food.GetType() == typeof(DiscreteFood) && ((DiscreteFood)food).Quantity >= amount)
                {
                    order.Amount = amount;
                    ((DiscreteFood)food).Quantity -= (int)amount;
                }
                else
                {
                    return -1;
                }
                
                order.FoodOrder = food;
                order.Buyer = user;
                order.Approved = false;
                _dataContext.Orders.Add(order);
                user.Orders.Add(order);
                _dataContext.Save();
            }
            else
            {
                return -1;
            }

            return 1;
        }

        public int DeleteOrder(int orderID)
        {
            try
            {
                Order order = FindOrderByID(orderID);
                _dataContext.Orders.Remove(order);
                _dataContext.Save();
            }
            //catch(Exception e)
            catch
            {
                //Logger.Instance.Log(e);
                return -1;
            }

            return 1;
        }

        public int ApproveOrder(int orderID, Boolean isApproved)
        {
            try
            {
                Order order = FindOrderByID(orderID);
                order.Approved = isApproved;
                _dataContext.Save();
            }
            //catch(Exception e)
            catch
            {
                //Logger.Instance.Log(e);
                return -1;
            }

            return 1;
        }

    }
}
