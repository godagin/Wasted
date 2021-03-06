using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Wasted
{
    public delegate void AddDelegate(Food food);
    public delegate void RemoveDelegate(int index); 


    /// singleton
    class FoodList //this is publisher
    {
        public event AddDelegate AddedToList;
        public event RemoveDelegate RemovedFromList;
        public event EventHandler EditedListItem;

        List<Food> FoodOffers;
        private static FoodList _obj = null;
        private FoodList()
        {
            //this.AddedToListView += new ListViewHandler(this.AddCreatedFood);
            FoodOffers = new List<Food>();
        }
        
        public static FoodList GetObject()
        {
            if(_obj == null)
            {
                _obj = new FoodList();
            }
            return _obj;
        }

        public List<Food> GetList()
        {
            return FoodOffers;
        }

        protected virtual void OnAddedToList() //examples showed that this should be a seperate method perhaps for readability
        {
            AddedToList?.Invoke(FoodOffers.Last());
        }

        public void AddCreatedFood(Food food)
        {
            FoodOffers.Add(food);
            OnAddedToList();
        }

        protected virtual void OnRemovedFromList(int index) //examples showed that this should be a seperate method
        {
            RemovedFromList?.Invoke(index);
        }

        public void RemoveItem(int index)
        {
            FoodOffers.RemoveAt(index);
            OnRemovedFromList(index);
        }

        protected virtual void OnEditedListItem(EventArgs e) //examples showed that this should be a seperate method
        {
            EditedListItem?.Invoke(this, e);
        }

        public void EditItem(int index, string name, string description, double price, int type, int expDays, double amount = 0)//amount can be either weight or quantity
        {
            FoodOffers[index].Name = name;
            FoodOffers[index].Description = description;
            FoodOffers[index].FullPrice = price;
            FoodOffers[index].Type = type;
            FoodOffers[index].ExpDate = DateTime.Now.AddDays(expDays);

            if (FoodOffers[index].GetType() == typeof(WeighedFood))
            {
                ((WeighedFood)FoodOffers[index]).Weight = amount;
            }
            else if (FoodOffers[index].GetType() == typeof(DiscreteFood))
            {
                ((DiscreteFood)FoodOffers[index]).Quantity = (int)amount;
            }

            OnEditedListItem(EventArgs.Empty);
        }

        public void ChangeFoodTypeToWeighed(int index, Food food, double amount)
        {
            FoodOffers.RemoveAt(index);

            WeighedFood weighed = new WeighedFood(food.Name, food.Description, food.FullPrice, food.Type, amount, food.GetShelfDays());//naujas sukurs nauja ID
            weighed.ID = food.ID;

            FoodOffers.Insert(index, weighed);
        }

        public void ChangeFoodTypeToDiscrete(int index, Food food, int amount)
        {
            FoodOffers.RemoveAt(index); 
            
            DiscreteFood discrete = new DiscreteFood(food.Name, food.Description, food.FullPrice, food.Type, amount, food.GetShelfDays());//naujas sukurs nauja ID
            discrete.ID = food.ID;

            FoodOffers.Insert(index, discrete);
        }

        public void RemoveAll()
        {
            FoodOffers.Clear();
        }
      
        public void AddCreatedFood(string name, string description, double price, double amount, int expDays = 2)
        {
            FoodOffers.Add(new Food(name, description, price, expDays));
        }
        
    }
}
