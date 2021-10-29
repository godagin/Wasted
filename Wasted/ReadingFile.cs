using System;
using System.IO;

namespace Wasted
{
    class ReadingFile
    {

        public ReadingFile()
        {

        }

        public void ReadFileCsv(string fileName)
        {
            string path = Path.GetFullPath(Directory.GetParent(Directory.GetCurrentDirectory())
               .Parent.FullName + "\\" + fileName + ".csv");
            string line;
            Food food;
            try
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
                        double weight = Convert.ToDouble(data[4]);
                        int type = Convert.ToInt32(data[3]);

                        if (data.Length < 6)
                        {
                            food = new WeighedFood(data[0], data[1], price, type, weight);
                        }
                        else
                        {
                            int days = Convert.ToInt32(data[5]);
                            food = new WeighedFood(data[0], data[1], price, type, weight, days);
                        }
                    }
                    else
                    {
                        int amount = Convert.ToInt32(data[4]);
                        int type = Convert.ToInt32(data[3]);

                        if (data.Length < 6)
                        {
                            food = new DiscreteFood(data[0], data[1], price, type, amount);
                        }
                        else
                        {
                            int days = Convert.ToInt32(data[5]);
                            food = new DiscreteFood(data[0], data[1], price, type, amount, days);
                        }
                    }

                    DatabaseHandler.GetHandler().AddItemToFoodTable(food);

                    FoodList.GetObject().AddCreatedFood(food);

                }
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc);
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
