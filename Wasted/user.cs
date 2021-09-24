using System;
using System.Collections.Generic;

namespace Wasted
{
	class User
	{
		public String userName { get; set; }

		public List<Food> addedFoodOffers;
		public List<Food> addedCharityFoodOffers;

		public User(String userName)
		{
			this.userName = userName;
			addedFoodOffers = new List<Food>();
			addedCharityFoodOffers = new List<Food>();
		}

		//prideti pasiulyma

		public void AddFoodOffer(string foodName, string foodDescription, double fullPrice, int amount)
		{
			addedFoodOffers.Add(new Food (foodName, foodDescription, fullPrice, amount));
		}

		public void AddCharityFoodOffer(string foodName, string foodDescription, double fullPrice, int amount)
		{
			addedCharityFoodOffers.Add(new Food(foodName, foodDescription, 0, amount));
		}

		//metodas isimti pasiulyma(pagal indeksa?)

		public void RemoveFoodOffer(int offerID)
		{
			addedFoodOffers.RemoveAt(offerID);
		}

		public void RemoveCharityFoodOffer(int offerID)
		{
			addedCharityFoodOffers.RemoveAt(offerID);
		}
	}
}