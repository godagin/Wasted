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
    public class ItemService : IItemService
    { 
        public ItemService()
        {
        }

        public Food FindItemByID(int ID, IDataContext dataContext)
        {
            Food item = dataContext.Foods.Where(item => item.ID == ID).FirstOrDefault();
            return item;
        }

        public Order FindOrderByID(int ID, IDataContext dataContext)
        {
            Order item = dataContext.Orders.Where(item => item.ID == ID).FirstOrDefault();
            return item;
        }

        public List<Food> GetUserOffers(int userID, IDataContext dataContext)
        {
            var myOffers = from food in dataContext.Foods where food.OwnerID.Equals(userID) select food;
            return myOffers.ToList();
        }

        public int CreateFoodOffer(GeneralFoodDto args, IDataContext dataContext)
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
            dataContext.Foods.Add(food);
            dataContext.Save();
            return 1;
        }

        public int PlaceOrder(User user, int foodID, double amount, IDataContext dataContext)
        {
            Console.WriteLine("pirmas");
            Food food = FindItemByID(foodID, dataContext);

            if (user != null && food != null)
            {
                Console.WriteLine("antras");
                Order order = new Order();
                if (food.GetType() == typeof(WeighedFood) && ((WeighedFood)food).Weight >= amount)
                {
                    Console.WriteLine("trecias");
                    order.Amount = amount;
                    ((WeighedFood)food).Weight -= amount;

                }
                else if(food.GetType() == typeof(DiscreteFood) && ((DiscreteFood)food).Quantity >= amount)
                {
                    Console.WriteLine("ketvirtas");
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
                dataContext.Orders.Add(order);
                user.Orders.Add(order);
                dataContext.Save();
            }
            else
            {
                return -1;
            }

            return 1;
        }


        public int DeleteOrder(int orderID, IDataContext dataContext)
        {
            try
            {
                Order order = FindOrderByID(orderID, dataContext);
                dataContext.Orders.Remove(order);
                dataContext.Save();
            }
            //catch(Exception e)
            catch
            {
                //Logger.Instance.Log(e);
                return -1;
            }

            return 1;
        }

        public int ApproveOrder(int orderID, Boolean isApproved, IDataContext dataContext)
        {
            try
            {
                Order order = FindOrderByID(orderID, dataContext);
                order.Approved = isApproved;
                dataContext.Save();
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
