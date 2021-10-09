using System;
using System.Collections.Generic;

//added "add" methods that take food objects as parameters
//renamed userName->Name to make the project code more consistent

namespace Wasted
{
	class User
	{
		public String Name { get; set; }

		public List<Food> addedFoodOffers;
		public List<Food> addedCharityFoodOffers;

		public User(String name)
		{
			this.Name = name;
			addedFoodOffers = new List<Food>();
			addedCharityFoodOffers = new List<Food>();
		}

		//prideti pasiulyma

		public void AddFoodOffer(string foodName, string foodDescription, double fullPrice, int foodAmount)
		{
			addedFoodOffers.Add(new Food (foodName, foodDescription, fullPrice));
		}

		public void AddFoodOffer(Food newOffer)
        {
			addedFoodOffers.Add(newOffer);

		}

		public void RemoveFoodOffer(int offerID)
		{
			addedFoodOffers.RemoveAt(offerID);
		}

		public void RemoveFoodOffer(Food food) 
		{
			addedFoodOffers.Remove(food);
		}
		public void AddCharityFoodOffer(string foodName, string foodDescription, int foodAmount)
		{
			addedCharityFoodOffers.Add(new Food(foodName, foodDescription, 0));
		}

		public void RemoveCharityFoodOffer(int offerID)
		{
			addedCharityFoodOffers.RemoveAt(offerID);
		}
	}
}