using System;
using System.Linq;
using System.Windows.Forms;

namespace Wasted
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // register to the events
            FoodList.GetObject().AddedToList += addItemListView;
            FoodList.GetObject().RemovedFromList += removeItemListView;
            FoodList.GetObject().EditedListItem += reloadListView;

            // load all food offers from dbo.Foods to FoodList
            DatabaseHandler.GetHandler().LoadFoodList();
        }

        private void remove_offer_Click(object sender, EventArgs e) //buginasi vel norint prideti
        {
            FoodList.GetObject().RemoveAll(); //remove from Food List

            DatabaseHandler.GetHandler().RemoveAllFromFoodTable();

            lv_offer.Items.Clear();
        }

        private void add_new_offer_Click(object sender, EventArgs e)
        {
            int tempSize = FoodList.GetObject().GetList().Count();
            Form2 form2 = new Form2();
            form2.ShowDialog();

            if (tempSize >= FoodList.GetObject().GetList().Count())
                return;
            else
            {
                Food item = FoodList.GetObject().GetList().Last();
            }
        }

        private void lv_offer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lv_offer.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if(item != null)
            {
                int index = item.Index;
                Form3 form3 = new Form3(FoodList.GetObject().GetList()[index]);
                form3.ShowDialog();
            }
            else
            {
                lv_offer.SelectedItems.Clear();
            }
        }

        private void reloadListView()
        {
            lv_offer.Items.Clear();
            foreach (Food food in FoodList.GetObject().GetList())
            {
                addItemListView(food);
            }
            lv_offer.Refresh();
        }

        private void addItemListView(Food food)
        {
            ListViewItem item = new ListViewItem();
            item.Text = food.Name;
            item.SubItems.Add(food.Description);
            item.SubItems.Add(food.FullPrice.ToString());
            lv_offer.Items.Add(item);
        }

        private void removeItemListView(int index)
        {
            lv_offer.Items.RemoveAt(index);
        }
    }
}

