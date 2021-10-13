﻿using System;
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
            DatabaseHandler dbH = new DatabaseHandler();
            dbH.LoadFoodList();

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

            DatabaseHandler dbH = new DatabaseHandler();
            dbH.RemoveAllFromFoodTable();

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

            int tempSize = FoodList.GetObject().GetList().Count();

            ReadingFile file = new ReadingFile();
            file.ReadFileCsv(path);

            while(tempSize < FoodList.GetObject().GetList().Count())
            {
                int index = tempSize;
                Food itm = FoodList.GetObject().GetList()[index];
                ListViewItem lvItm = new ListViewItem(itm.Name);
                lvItm.SubItems.Add(itm.Description);
                lvItm.SubItems.Add(itm.FullPrice.ToString());
                lv_offer.Items.Add(lvItm);
                tempSize++;
            }
            lv_offer.EndUpdate();
        }

    }
}
