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
            DatabaseHandler.LoadFoodList();
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
            
            DatabaseHandler.RemoveAllFromFoodTable();

            lv_offer.BeginUpdate();

            foreach (ListViewItem item in lv_offer.SelectedItems) //remove from ListView
            {
                lv_offer.Items.Remove(item);
            }
            lv_offer.EndUpdate();
        }

        private void add_new_offer_Click(object sender, EventArgs e)
        {
            lv_offer.BeginUpdate();
            int tempSize = FoodList.GetObject().GetList().Count();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            MessageBox.Show(tempSize.ToString());
            MessageBox.Show(FoodList.GetObject().GetList().Count().ToString());
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
            MessageBox.Show(lv_offer.SelectedItems.ToString());
        }
    }
}
