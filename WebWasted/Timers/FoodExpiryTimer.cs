using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted.Timers
{
    public class FoodExpiryTimer
    {
        IDataContext _dataContext;
        public FoodExpiryTimer(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void RemoveExpiredFood(Object stateInfo)
        {
                var foods = _dataContext.Foods.ToList();
                var expiredFoods = new List<Food>();

                foreach(Food food in foods)
                {
                    if ((food.ExpDate-DateTime.Now).TotalDays <= 0.0)
                    {
                        expiredFoods.Add(food);
                    }
                }
                if (expiredFoods != null)
                {
                    _dataContext.Foods.RemoveRange(expiredFoods);
                    _dataContext.Save();
                }
            
            
        }
           
    }
}
