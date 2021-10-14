using System;
using System.Collections.Generic;
using System.IO;
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
            MessageBox.Show("cia bus nauja lentele editinimui");
        }

        private void add_file_offer_Click(object sender, EventArgs e)
        {
            lv_offer.BeginUpdate();

            string path = Path.GetFullPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\file.csv");

            int index = FoodList.GetObject().GetList().Count();

            ReadingFile file = new ReadingFile();
            file.ReadFileCsv(path);

            while(index < FoodList.GetObject().GetList().Count())
            {
                Food itm = FoodList.GetObject().GetList()[index];
                ListViewItem lvItm = new ListViewItem(itm.Name);
                lvItm.SubItems.Add(itm.Description);
                lvItm.SubItems.Add(itm.FullPrice.ToString());
                lv_offer.Items.Add(lvItm);
                index++;
            }
            lv_offer.EndUpdate();
        }
        /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataContext dc = new DataContext();
            Search sr = new Search();
            List<Food> SearchedFood = new List<Food>();
            string input = search_bar.Text;
            
            if (!string.IsNullOrEmpty(input))
            {
                foreach(var item in dc.Foods)
                {
                    if(sr.MatchesName(input, item) || sr.MatchesInDescription(input, item))
                    {
                        ListViewItem item1 = new ListViewItem(item.Name);
                        item1.SubItems.Add(item.Description);
                        item1.SubItems.Add(item.FullPrice.ToString());
                        
                        SearchedFood.Add(item);
                    }

                }

                
            }
                Form3 form3 = new Form3();
                form3.ShowDialog();
        }*/
    }
}
