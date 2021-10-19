using System;
using System.IO;

namespace Wasted
{
    class ReadingFile
    {

        public ReadingFile()
        {

        }

        public void ReadFileCsv(string path)
        {            
            string line;
            Food food;
            if (File.Exists(path))
            {
                using StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    double price = Convert.ToDouble(data[2]);

                    //if that string contains ".", it means that it will be kg
            /*
                    if (data[3].Contains("."))
                    {
                        double weight = Convert.ToDouble(data[3]);
                        food = new WeighedFood(data[0], data[1], price, weight);
                    }
                    else
                    {
                        int amount = Convert.ToInt32(data[3]);
                        food = new DiscreteFood(data[0], data[1], price, amount);
                    }
            */

                    if (data[3].Contains("."))
                    {
                        double weight = Convert.ToDouble(data[3]);

                        if (data.Length == 5)
                        {
                            int days = Convert.ToInt32(data[4]);
                            food = new WeighedFood(data[0], data[1], price, weight, days);
                        }
                        else
                        {
                            food = new WeighedFood(data[0], data[1], price, weight);
                        }
                    }
                    else
                    {
                        int amount = Convert.ToInt32(data[3]);

                        if (data.Length >= 5)
                        {
                            int days = Convert.ToInt32(data[4]);
                            food = new DiscreteFood(data[0], data[1], price, amount, days);
                        }
                        else
                        {
                            food = new DiscreteFood(data[0], data[1], price, amount);
                        }
                    }

                    DatabaseHandler.GetHandler().AddItemToFoodTable(food);
                   
                    FoodList.GetObject().AddCreatedFood(food);
                    
                }
            }

            /*public void ReadFileTxt(string fileName, List<Food> foodList)
            {
                string[] data = line.Split(',');
                double price = Convert.ToDouble(data[2]);
                double amount = Convert.ToDouble(data[3]);
                Food food = new Food(data[0], data[1], price);
                foodList.Add(food);

                string line;
                StreamReader file = new StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
                    double price = Convert.ToDouble(data[2]);
                    double amount = Convert.ToDouble(data[3]);
                    Food food = new Food(data[0], data[1], price);
                    foodList.Add(food);
                }

                file.Close();
            }
            */

        }
    }

}
