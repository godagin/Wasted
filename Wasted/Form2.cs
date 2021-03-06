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
            string expirationPattern = @"^\d*$";

            bool isPriceValid = Regex.IsMatch(textBoxPrice.Text, pricePattern);
            bool isWeightValid = Regex.IsMatch(textBoxWeight.Text, weightPattern);
            bool isAmountValid = Regex.IsMatch(textBoxQuantity.Text, amountPattern);
            bool isExpirationValid = Regex.IsMatch(textBoxExpiration.Text, expirationPattern);

            if (!isPriceValid || !isExpirationValid)
            {
                if (!isExpirationValid && !isPriceValid)
                MessageBox.Show("Netinkamas kainos ir galiojimo dienų formatas! Bandykite dar kartą.");
                else if (!isPriceValid)
                MessageBox.Show("Netinkamas kainos formatas! Bandykite dar kartą.");
                else if (!isExpirationValid)
                MessageBox.Show("Netinkamas galiojimo dienų formatas! Bandykite dar kartą.");
            }
            else
            {
                if (RB_type_discrete.Checked && !RB_type_weighted.Checked && isAmountValid)
                {

                    if (textBoxExpiration.Text == "")
                    {
                        food = new DiscreteFood(name: textBoxName.Text,
                        description: textBoxDescription.Text,
                        fullPrice: Double.Parse(textBoxPrice.Text),
                        type: comboBoxCateg.SelectedIndex,
                        quantity: int.Parse(textBoxQuantity.Text));
                    }
                    else
                    {
                        food = new DiscreteFood(name: textBoxName.Text,
                        description: textBoxDescription.Text,
                        fullPrice: Double.Parse(textBoxPrice.Text),
                        type: comboBoxCateg.SelectedIndex,
                        quantity: int.Parse(textBoxQuantity.Text),
                        expDays: int.Parse(textBoxExpiration.Text));
                    }

                    DatabaseHandler.GetHandler().AddItemToFoodTable(food); //add entity to the add method

                    FoodList.GetObject().AddCreatedFood(food);

                    this.Close();
                }
                else if (!RB_type_discrete.Checked && RB_type_weighted.Checked && isWeightValid)
                {

                    if (textBoxExpiration.Text == "")
                    {
                        food = new WeighedFood(name: textBoxName.Text,
                        description: textBoxDescription.Text,
                        fullPrice: Double.Parse(textBoxPrice.Text),
                        type: comboBoxCateg.SelectedIndex,
                        weight: Double.Parse(textBoxWeight.Text));
                    }
                    else
                    {
                        food = new WeighedFood(name: textBoxName.Text,
                        description: textBoxDescription.Text,
                        fullPrice: Double.Parse(textBoxPrice.Text),
                        type: comboBoxCateg.SelectedIndex,
                        weight: Double.Parse(textBoxWeight.Text),
                        expDays: int.Parse(textBoxExpiration.Text));

                    }
                    DatabaseHandler.GetHandler().AddItemToFoodTable(food); //add entity to the add method

                    FoodList.GetObject().AddCreatedFood(food);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Netinkamas kiekio formatas! Bandykite dar kartą.");
                }
            }
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
        private void comboBoxCateg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
    }
}
