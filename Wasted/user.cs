using System;

namespace Wasted
{
	class User
	{
		public String userName { get; set; }

		public int recentOfferID = 1;

		public List<Food> addedFoodOffers;
		public List<Food> addedCharityFoodOffers;

		public User(String userName)
		{
			this.userName = userName;
			addedFoodOffers = new List<Food>();
			addedCharityFoodOffers = new List<Food>();
		}

		//prideti pasiulyma

		public void addFoodOffer(List<Food> addedFoodOffers, string foodName, string foodDescription, double fullPrice, int amount)
		{
			addedFoodOffers.Add(new Food { FoodName = foodName, FoodDescription = foodDescription, FullPrice = fullPrice, Amount = amount, OfferID = recentOfferID});
			++recentOfferID;
			//set index? -->issaugoti paskutini suteikta offerID ir vis ++
		}

		public void addCharityFoodOffer(List<Food> addedCharityFoodOffers, string foodName, string foodDescription, int amount)
		{
			addedCharityFoodOffers.Add(new Food { FoodName = foodName, FoodDescription = foodDescription, Amount = amount });

			//
		}

		//metodas isimti pasiulyma(pagal indeksa?)

		public void removeFoodOffer(List<Food> addedFoodOffers, int offerID)
		{
			addedFoodOffers.RemoveAt(offerID - 1);
		}

		public void removeCharityFoodOffer(List<Food> addedCharityFoodOffers, int offerID)
		{
			addedCharityFoodOffers.RemoveAt(offerID - 1);
		}
	}
}