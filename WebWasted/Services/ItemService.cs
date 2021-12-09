using Microsoft.AspNetCore.Hosting;
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

        public List<Food> GetUserOffers(int userID)
        {
            var myOffers = from food in _dataContext.Foods where food.OwnerID.Equals(userID) select food;
            return myOffers.ToList();
        }

        public List<Food> GetSearchedOffers(string searchString)
        {
            var query = from food in _dataContext.Foods select food;
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(offer => offer.Name.Contains(searchString) || offer.Description.Contains(searchString));
            }
            return query.ToList();
        }

        public List<Food> GetFirstOffers()
        {
            var queryFirst = (from food in _dataContext.Foods orderby food.ExpDate ascending select food).Take(6);
            return queryFirst.ToList();
        }

        public List<Food> GetCheapestOffers()
        {
            int length = _dataContext.Foods.Count();
            var query = (from food in _dataContext.Foods orderby food.FullPrice descending select food).Skip(length/2);
            return query.ToList();
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
            //catch (Exception e)
            catch
            {
                //Console.WriteLine("The creation of a food offer failed.");
                //Logger.Instance.Log(e);
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
                else if (food.GetType() == typeof(DiscreteFood) && ((DiscreteFood)food).Quantity >= amount)
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

        public int DeleteOffer(int foodID)
        {
            try
            {
                Food food = FindItemByID(foodID);
                _dataContext.Foods.Remove(food);
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

        public int EditOffer(int foodID, GeneralFoodDto args)
        {
            Food food = FindItemByID(foodID);

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

            return 1;
        }
    }
}
