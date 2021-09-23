using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class ReadingFiles
    {
        public void ReadFileTxt(string fileName, List<Food> foodList)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                double price = Convert.ToDouble(data[2]);
                double amount = Convert.ToDouble(data[3]);
                Food food = new Food(data[0], data[1], price, amount);
                foodList.Add(food);
            }

            file.Close();
        }
    }
}
