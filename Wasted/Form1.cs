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
            DatabaseHandler.GetHandler().LoadFoodList();

            DataContext dc = new DataContext();

            foreach (var item in dc.Foods)//load all existing items in dbo.Foods 
            {
                ListViewItem DBItm = new ListViewItem();
                DBItm.Text = item.Name;
                DBItm.SubItems.Add(item.Description);
                DBItm.SubItems.Add(item.FullPrice.ToString());
                lv_offer.Items.Add(DBItm);
            }
            
        }

        private void remove_offer_Click(object sender, EventArgs e)
        {
            FoodList.GetObject().RemoveAll(); //remove from Food List

            DatabaseHandler.GetHandler().RemoveAllFromFoodTable();

            lv_offer.Items.Clear();

        }

        private void add_new_offer_Click(object sender, EventArgs e)
        {
            lv_offer.BeginUpdate();
            int tempSize = FoodList.GetObject().GetList().Count();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            
            if (tempSize >= FoodList.GetObject().GetList().Count())
                return;
            else 
            {// add for from tempsize to FoodList length
                Food itm = FoodList.GetObject().GetList().Last();
                ListViewItem lvItm = new ListViewItem(itm.Name);
                lvItm.SubItems.Add(itm.Description);
                lvItm.SubItems.Add(itm.FullPrice.ToString());
                lv_offer.Items.Add(lvItm);
            }
            lv_offer.EndUpdate();

        }

        private void lv_offer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //MessageBox.Show("cia bus nauja lentele editinimui");
            if(lv_offer.SelectedItems.Count != 0)
            {
                ListViewItem lvItem = lv_offer.SelectedItems[0];
                int index = lv_offer.SelectedItems[0].Index;
                lv_offer.SelectedItems.Clear();
                lv_offer.Items.Remove(lvItem);

                Food foodItem = FoodList.GetObject().GetList()[index];
                FoodList.GetObject().RemoveItem(index);

                DatabaseHandler.GetHandler().RemoveItemFromFoodTable(foodItem);
            }
            
        }

        private void lv_offer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = lv_offer.ListViewItemSorter as ItemComparer;
            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                lv_offer.ListViewItemSorter = sorter;
            }
            
            if (e.Column == sorter.Column)
            {
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            lv_offer.Sort();
        }
    }
}
