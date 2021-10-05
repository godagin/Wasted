﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wasted
{
    class ReadingFile
    {
        public void ReadFileCsv(string fileName, List<Food> foodList)
        {
            string line;
            try
            {
                StreamReader file = new StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    double price = Convert.ToDouble(data[2]);
                    double amount = Convert.ToDouble(data[3]);
                    Food food = new Food(data[0], data[1], price, amount);
                    foodList.Add(food);
                }
                file.Close();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Not valid arguments.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File with this name was not found.");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with file reading.");
            }


            /*public void ReadFileTxt(string fileName, List<Food> foodList)
            {
                string line;
                StreamReader file = new StreamReader(fileName);
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
            */

        }
    }

}