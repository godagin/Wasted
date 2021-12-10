﻿using Microsoft.AspNetCore.Hosting;
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
            Order item = dataContext.Orders.Include("FoodOrder").Where(item => item.ID == ID).FirstOrDefault();
            return item;
        }

        public List<Food> GetUserOffers(int userID, IDataContext dataContext)
        {
            var myOffers = from food in dataContext.Foods where food.OwnerID.Equals(userID) select food;
            if (myOffers == null)
            {
                return new List<Food>();
            }
            return myOffers.ToList();
        }

        public List<Food> GetSearchedOffers(string searchString, IDataContext dataContext)
        {
            var query = from food in dataContext.Foods select food;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(offer => offer.Name.Contains(searchString) || offer.Description.Contains(searchString));
            }
            return query.ToList();
        }

        public List<Food> GetFirstOffers(IDataContext dataContext)
        {
            var queryFirst = (from food in dataContext.Foods orderby food.ExpDate ascending select food).Take(6);
            return queryFirst.ToList();
        }

        public List<Food> GetCheapestOffers(IDataContext dataContext)
        {
            int length = dataContext.Foods.Count();

            var query = (from food in dataContext.Foods orderby food.FullPrice descending select food).Skip(length/2);

            return query.ToList();
        }

        public Food CreateFoodOffer(GeneralFoodDto args, IDataContext dataContext)
        {
            Food food = null;
            try
            {
                switch (args.type)
                {
                    case 1:
                        food = new WeighedFood(args.owner, args.name, args.description, args.fullPrice, args.foodType, args.amount, args.expTime);
                        food.PhotoFileName = args.fileName;
                        break;
                    case 2:
                        food = new DiscreteFood(args.owner, args.name, args.description, args.fullPrice, args.foodType, (int)(args.amount), args.expTime);
                        food.PhotoFileName = args.fileName;
                        break;
                    default:
                        throw new Exception();
                        // creating simple food is not good since it doesn't have amount which breaks logic
                        // food = new Food(args.owner, args.name, args.description, args.fullPrice, args.foodType, args.expTime);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("The creation of a food offer failed.");
                Logger.Instance.Log(e);
                return null;
            }
            dataContext.Foods.Add(food);
            dataContext.Save();
            return food;
        }

        public int PlaceOrder(User user, int foodID, double amount, IDataContext dataContext)
        {
            Console.WriteLine("pirmas");
            Food food = FindItemByID(foodID, dataContext);

            if (user != null && food != null && user.ID != food.OwnerID)
            {
                Console.WriteLine(food.GetType().ToString() + " ");
                Order order = new Order();
                if (food.GetType() == typeof(WeighedFood) && ((WeighedFood)food).Weight >= amount)
                {
                    Console.WriteLine("trecias");
                    order.Amount = amount;
                    ((WeighedFood)food).Weight -= amount;

                }
                else if (food.GetType() == typeof(DiscreteFood) && ((DiscreteFood)food).Quantity >= amount)
                {
                    Console.WriteLine("ketvirtas");
                    order.Amount = amount;
                    ((DiscreteFood)food).Quantity -= (int)amount;
                }
                else
                {
                    Console.WriteLine("pirmas ne");
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
                Console.WriteLine("kazkoks ne");
                return -1;
            }

            return 1;
        }

        public int DeleteOffer(int foodID, IDataContext dataContext)
        {
            try
            {
                Food food = FindItemByID(foodID, dataContext);
                dataContext.Foods.Remove(food);
                dataContext.Save();
            }
            catch(Exception e)
            {
                Logger.Instance.Log(e);
                return -1;
            }
            return 1;
        }

        public int DeleteOrder(int orderID, IDataContext dataContext)
        {
            try
            {
                Order order = FindOrderByID(orderID, dataContext);
                Food food = FindItemByID(order.FoodOrder.ID, dataContext);
                if (food.GetType() == typeof(WeighedFood))
                {
                    ((WeighedFood)food).Weight += order.Amount;
                }
                else if (food.GetType() == typeof(DiscreteFood))
                {
                    ((DiscreteFood)food).Quantity += (int)order.Amount;
                }
                else
                {
                    return -1;
                }


                dataContext.Orders.Remove(order);
                dataContext.Save();
            }
            catch
            {
                Logger.Instance.Log(e);
                return -1;
            }
            return 1;
            
        }

        public int EditOffer(int foodID, GeneralFoodDto args, IDataContext dataContext)
        {
            Food food = FindItemByID(foodID, dataContext);

            food.Name = args.name;
            food.Description = args.description;
            food.FullPrice = args.fullPrice;
            food.Type = args.foodType;
            food.ExpDate = DateTime.Now.AddDays(args.expTime);
            food.PhotoFileName = args.fileName;

            if (args.type == 1)
            {
                ((WeighedFood)food).Weight = args.amount;
            }
            else if (args.type == 2)
            {
                ((DiscreteFood)food).Quantity = (int)args.amount;
            }
            dataContext.Save();
            return 1;
        }

        public int ApproveOrder(int orderID, Boolean isApproved, IDataContext dataContext)
        {
            try {
                Order order = FindOrderByID(orderID, dataContext);
                order.Approved = isApproved;
                dataContext.Save();
            }
            catch(Exception e)
            {
                Logger.Instance.Log(e);
                return -1;
            }
            return 1;
        }

    } 
}
