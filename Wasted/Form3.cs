using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wasted

    //REIKIA PALIKTI TIK VIENĄ LAUKELĮ KIEKIUI
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
            textBoxExpiration.Text = food.GetShelfDays().ToString();
            comboBoxType.Text = comboBoxType.Items[food.Type].ToString();
         
            if (food.GetType() == typeof(WeighedFood))
            {
                RB_weighed.Checked = true;
                textBoxAmount.Text = ((WeighedFood)food).Weight.ToString();
            } 
            else if(food.GetType() == typeof(DiscreteFood))
            {
                RB_discrete.Checked = true;
                textBoxAmount.Text = ((DiscreteFood)food).Quantity.ToString();
            }
            else
            {
                textBoxAmount.Enabled = false;
            }
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
            bool isAmountInt = Regex.IsMatch(textBoxAmount.Text, @"^\d+$");
            bool isAmountDouble = Regex.IsMatch(textBoxAmount.Text, @"^\d+(\,|\.)?(\d{1,3})?$");
            bool isPriceValid = Regex.IsMatch(textBoxPrice.Text, @"^\d+(\,|\.)?(\d{1,2})?$");
            bool isExpirationValid = Regex.IsMatch(textBoxExpiration.Text, @"^\d*$");

            if (isPriceValid && isExpirationValid)
            {
                if (isAmountInt)
                {
                    var amount = int.Parse(textBoxAmount.Text);
                    Food food = FoodList.GetObject().GetList()[Index];
                    DatabaseHandler.GetHandler().RemoveItemFromFoodTable(food);
                    //FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text), (double)amount);
                    FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text), comboBoxType.SelectedIndex, int.Parse(textBoxExpiration.Text), (double)amount);

                    //if food is weighed and chosen to convert to discrete
                    if (FoodList.GetObject().GetList()[Index].GetType() == typeof(WeighedFood) && RB_discrete.Checked)
                    {
                        FoodList.GetObject().ChangeFoodTypeToDiscrete(Index, food, amount);
                    }
                    //if food is discrete
                    else if (FoodList.GetObject().GetList()[Index].GetType() == typeof(DiscreteFood) && RB_weighed.Checked)
                    {
                        FoodList.GetObject().ChangeFoodTypeToWeighed(Index, food, (double)amount);
                    }

                    DatabaseHandler.GetHandler().AddItemToFoodTable(FoodList.GetObject().GetList()[Index]);

                    this.Close();

                }
                else if (isAmountDouble)
                {
                    var amount = Double.Parse(textBoxAmount.Text);
                    Food food = FoodList.GetObject().GetList()[Index];
                    DatabaseHandler.GetHandler().RemoveItemFromFoodTable(food);
                    //FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text), amount);
                    FoodList.GetObject().EditItem(Index, textBoxName.Text, textBoxDescription.Text, Double.Parse(textBoxPrice.Text), comboBoxType.SelectedIndex, int.Parse(textBoxExpiration.Text), amount);

                    //if food is weighed and chosen to convert to discrete
                    if (FoodList.GetObject().GetList()[Index].GetType() == typeof(WeighedFood) && RB_discrete.Checked)
                    {
                        FoodList.GetObject().ChangeFoodTypeToDiscrete(Index, food, (int)amount);
                    }
                    //if food is discrete
                    else if (FoodList.GetObject().GetList()[Index].GetType() == typeof(DiscreteFood) && RB_weighed.Checked)
                    {
                        FoodList.GetObject().ChangeFoodTypeToWeighed(Index, food, amount);
                    }

                    DatabaseHandler.GetHandler().AddItemToFoodTable(FoodList.GetObject().GetList()[Index]);

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Netinkamas kiekio formatas! Bandykite dar kartą.");
                }
            }
            else
            {
                MessageBox.Show("Netinkamas kainos arba galiojimo laiko formatas! Bandykite dar kartą. ");
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
