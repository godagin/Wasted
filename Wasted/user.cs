using System;

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

		public void addFoodOffer(string foodName, string foodDescription, double fullPrice, int amount)
		{
			addedFoodOffers.Add(new Food { FoodName = foodName, FoodDescription = foodDescription, FullPrice = fullPrice, Amount = amount});
		}

		public void addCharityFoodOffer(string foodName, string foodDescription, int amount)
		{
			addedCharityFoodOffers.Add(new Food { FoodName = foodName, FoodDescription = foodDescription, Amount = amount });
		}

		//metodas isimti pasiulyma(pagal indeksa?)

		public void removeFoodOffer(int offerID)
		{
			addedFoodOffers.RemoveAt(offerID);
		}

		public void removeCharityFoodOffer(int offerID)
		{
			addedCharityFoodOffers.RemoveAt(offerID);
		}
	}
}