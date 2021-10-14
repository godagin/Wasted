using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wasted
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBoxQuantity.Enabled = false;
            textBoxWeight.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food food;
            string pricePattern = @"^\d+(\,|\.)?(\d{1,2})?$";
            string weightPattern = @"^\d+(\,|\.)?(\d{1,3})?$";
            string amountPattern = @"^\d+$";
            
            bool isPriceValid = Regex.IsMatch(textBoxPrice.Text, pricePattern);
            bool isWeightValid = Regex.IsMatch(textBoxWeight.Text, weightPattern);
            bool isAmountValid = Regex.IsMatch(textBoxQuantity.Text, amountPattern);
            
            if (!isPriceValid)
            {
                MessageBox.Show("Netinkamas kainos formatas! Bandykite dar kartą.");
            }
            else
            {
                if (RB_type_discrete.Checked && !RB_type_weighted.Checked && isAmountValid)
                {
                        food = new DiscreteFood(textBoxName.Text,
                        textBoxDescription.Text,
                        Double.Parse(textBoxPrice.Text),
                        int.Parse(textBoxQuantity.Text)
                        int.Parse(textBoxExpiration.Text));

                    DatabaseHandler.GetHandler().AddItemToFoodTable(food); //add entity to the add method

                    FoodList.GetObject().AddCreatedFood(food);
                }
                else if (!RB_type_discrete.Checked && RB_type_weighted.Checked && isWeightValid)
                {
                    food = new WeighedFood(textBoxName.Text,
                        textBoxDescription.Text,
                        Double.Parse(textBoxPrice.Text),
                        Double.Parse(textBoxWeight.Text),
                        int.Parse(textBoxExpiration.Text));

                    DatabaseHandler.GetHandler().AddItemToFoodTable(food); //add entity to the add method

                    FoodList.GetObject().AddCreatedFood(food);
                }
                else
                {
                    MessageBox.Show("Netinkamas formatas! Bandykite dar kartą.");

                    /*
                    //catch exceptions what if in the place of double we get a string OR empty
                    food = new Food(textBoxName.Text,
                        textBoxDescription.Text,
                        Double.Parse(textBoxPrice.Text));
                    */
                }
                //DatabaseHandler.GetHandler().AddItemToFoodTable(food); //add entity to the add method
            
                //FoodList.GetObject().AddCreatedFood(food); 
            }
            
            this.Close();
        }

        private void RB_type_weighted_CheckedChanged(object sender, EventArgs e)
        {
            textBoxWeight.Enabled = true;
            textBoxQuantity.Enabled = false;
        }

        private void RB_type_discrete_CheckedChanged(object sender, EventArgs e)
        {
            textBoxQuantity.Enabled = true;
            textBoxWeight.Enabled = false;
        }
    }
}
