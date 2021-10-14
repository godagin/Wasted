using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wasted
{
    public partial class Form3 : Form
    {
        private int Index = 0;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Food food)
        {
            InitializeComponent();

            Index = FoodList.GetObject().GetList().IndexOf(food);
         
            textBoxName.Text = food.Name;
            textBoxDescription.Text = food.Description;
            textBoxPrice.Text = food.FullPrice.ToString();
            
            if (food.GetType() == typeof(WeighedFood))
            {
                RB_weighed.Checked = true;
                textBoxWeight.Text = ((WeighedFood)food).Weight.ToString();
                textBoxQuantity.Enabled = false;
            } 
            else if(food.GetType() == typeof(DiscreteFood))
            {
                RB_discrete.Checked = true;
                textBoxQuantity.Text = ((DiscreteFood)food).Quantity.ToString();
                textBoxWeight.Enabled = false;
            }
            else
            {
                textBoxQuantity.Enabled = false;
                textBoxWeight.Enabled = false;
            }

            RB_discrete.Enabled = false;
            RB_weighed.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void bin_Click(object sender, EventArgs e)
        {
            Food food = FoodList.GetObject().GetList()[Index];
            FoodList.GetObject().RemoveItem(Index);
            DatabaseHandler.GetHandler().RemoveItemFromFoodTable(food);
            this.Close();
        }


        private void submit_changes_Click(object sender, EventArgs e)
        {
            double amount;
            if (FoodList.GetObject().GetList()[Index].GetType() == typeof(WeighedFood))
            {
                amount = Double.Parse(textBoxWeight.Text);
                FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text), amount);
            }
            else if (FoodList.GetObject().GetList()[Index].GetType() == typeof(DiscreteFood))
            {
                amount = Double.Parse(textBoxQuantity.Text);
                FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text), amount);
            }
            FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text));

            DatabaseHandler.GetHandler().EditFoodTableItem(FoodList.GetObject().GetList()[Index]);

            this.Close();
        }
    }
}
