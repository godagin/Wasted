using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wasted
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //object of entity class which holds all methods
            DataContext dc = new DataContext();
            //object of food class to take input
            Food food = new Food(textBox1.Text, textBox2.Text, 1, 0);
            //add entity to the add method
            dc.foods.Add(food);
            //insert it into table
            dc.SaveChanges();
            
            
            //FoodList.GetObject().AddCreatedFood(textBox1.Text, textBox2.Text, 0, 1);
            
            this.Close();
        }
        
    }
}
