using System.Collections.Generic;
using System.Linq;

namespace Wasted
{
    public delegate void AddDelegate(Food food);
    public delegate void RemoveDelegate(int index);
    public delegate void EditDelegate();

    /// singleton
    class FoodList //this is publisher
    {
        public event AddDelegate AddedToList;
        public event RemoveDelegate RemovedFromList;
        public event EditDelegate EditedListItem;

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


        protected virtual void OnAddedToList() //examples showed that this should be a seperate class perhaps for readability
        {
            AddedToList?.Invoke(FoodOffers.Last());
        }

        public void AddCreatedFood(Food food)
        {
            FoodOffers.Add(food);
            OnAddedToList();
        }

        protected virtual void OnRemovedFromList(int index) //examples showed that this should be a seperate class
        {
            RemovedFromList?.Invoke(index);
        }

        public void RemoveItem(int index)
        {
            FoodOffers.RemoveAt(index);
            OnRemovedFromList(index);
        }

        protected virtual void OnEditedListItem() //examples showed that this should be a seperate class
        {
            EditedListItem?.Invoke();
        }

        public void EditItem(int index, string name, string description, double price, double amount = 0)//amount can be either weight or quantity
        {
            FoodOffers[index].Name = name;
            FoodOffers[index].Description = description;
            FoodOffers[index].FullPrice = price;
            if (FoodOffers[index].GetType() == typeof(WeighedFood))
            {
                ((WeighedFood)FoodOffers[index]).Weight = amount;
            }
            else if (FoodOffers[index].GetType() == typeof(DiscreteFood))
            {
                ((DiscreteFood)FoodOffers[index]).Quantity = (int)amount;
            }

            OnEditedListItem();
        }

        public void RemoveAll()
        {
            FoodOffers.Clear();
        }
        
    }
}
