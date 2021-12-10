using NUnit.Framework;
using System;
using System.Linq;
using WebWasted;
using WebWasted.Models;
using WebWasted.Models.DTOs;
using WebWasted.Services;

namespace Tests
{
    public class ServiceTests
    {
        private IDataContext _dataContext;
        private IItemService _itemService;
        private IUserService _userService;
        private User testUser;
        private User testUser2;
        [OneTimeSetUp]
        public void Setup()
        {
            _dataContext = new DataContext();
            _itemService = new ItemService();
            _userService = new UserService();
            testUser = new User("abcd147896523test", "vardenis", "pavardenis", "vardenis.pavardenis@gmail.com", "password");
            testUser2 = new User("qwerty999test", "vardenis", "pavardenis", "vardenis.pavardenis@gmail.com", "password");
        }

        [Test, Order(1)]
        public void Create_User_Test()
        {
            var tempUser = _userService.RegisterUser(testUser, _dataContext);
           
            var found = _userService.FindUserByID(tempUser.ID, _dataContext);
            
            Assert.IsNotNull(found);
        }

        [Test, Order(2)]
        public void Create_Weighted_Food_Test()
        {
            GeneralFoodDto testDto = new GeneralFoodDto();
            testDto.type = 2;
            var user = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
            testDto.owner = user.ID;
            testDto.name = "ananasas";
            testDto.description = "Ispaniškas";
            testDto.fullPrice = 1.5;
            testDto.amount = 999;
            testDto.foodType= Category.Fruits;
            testDto.expTime = 3;

            var tempItem = _itemService.CreateFoodOffer(testDto, _dataContext);
            var found = _itemService.FindItemByID(tempItem.ID, _dataContext);
            Assert.IsNotNull(found);
        }

        [Test, Order(3)]
        public void Create_Discrete_Food_Test()
        {
            GeneralFoodDto testDto = new GeneralFoodDto();
            testDto.type = 1;
            var user = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
            testDto.owner = user.ID;
            testDto.name = "apelsinai";
            testDto.description = "Ispaniški";
            testDto.fullPrice = 1.5;
            testDto.amount = 55.9;
            testDto.foodType = Category.Fruits;
            testDto.expTime = 3;

            var tempItem = _itemService.CreateFoodOffer(testDto, _dataContext);
            var found = _itemService.FindItemByID(tempItem.ID, _dataContext);
            Assert.IsNotNull(found);
        }
        
        [Test, Order(4)]
        public void Find_Users_Offers_Test()
        {
            var tempUser = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
            
            var offers = _itemService.GetUserOffers(tempUser.ID, _dataContext);
            
            Assert.IsNotNull(offers);
        }
        
        [Test, Order(5)]
        public void Place_Order_Test()
        {
            var user = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
            var newUser = _userService.RegisterUser(testUser2, _dataContext);
            var offer = _itemService.GetUserOffers(user.ID, _dataContext).FirstOrDefault();

            GeneralFoodDto testDto = new GeneralFoodDto();
            testDto.type = 2;
            testDto.owner = newUser.ID;
            testDto.name = "morkos";
            testDto.description = "Lietuviskos";
            testDto.fullPrice = 8;
            testDto.amount = 60;
            testDto.foodType = Category.Vegetables;
            testDto.expTime = 7;

            var tempOffer = _itemService.CreateFoodOffer(testDto, _dataContext);
            _itemService.PlaceOrder(user, tempOffer.ID, 1, _dataContext);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, _itemService.PlaceOrder(newUser, offer.ID, 1, _dataContext));
                Assert.AreEqual(-1, _itemService.PlaceOrder(user, offer.ID, 1, _dataContext));
                Assert.AreEqual(-1, _itemService.PlaceOrder(newUser, offer.ID, 100000, _dataContext));
            });
        }
        [Test, Order(6)]
        public void Order_Test()
        {
            var user = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(_userService.GetCustomerList(user.ID, _dataContext));
                Assert.IsNotNull(_userService.GetOrderList(user.ID, _dataContext));
            });    
        }

        [Test, Order(7)]
        public void Login_Test()
        {
            var user = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
           
            LoginUserDto testDto = new LoginUserDto();
            testDto.Password = user.Password;
            testDto.UserName = user.UserName;
            
            _userService.LoginUser(testDto, _dataContext);
            Assert.AreEqual(user.ID, _userService.LoginUser(testDto, _dataContext));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var user = _dataContext.Users.Where(u => u.UserName == testUser.UserName).FirstOrDefault();
            
            foreach (var item in _userService.GetCustomerList(user.ID,_dataContext))
            {
                _dataContext.Orders.Remove(item);
            }

            foreach(var item in _itemService.GetUserOffers(user.ID, _dataContext))
            {
                _dataContext.Foods.Remove(item);
            }
            
            _dataContext.Users.Remove(user);

            var user2 = _dataContext.Users.Where(u => u.UserName == testUser2.UserName).FirstOrDefault();

            foreach (var item in _userService.GetCustomerList(user2.ID, _dataContext))
            {
                _dataContext.Orders.Remove(item);
            }

            foreach (var item in _itemService.GetUserOffers(user2.ID, _dataContext))
            {
                _dataContext.Foods.Remove(item);
            }

            _dataContext.Users.Remove(user2);

            _dataContext.Save();
        }
    }
}