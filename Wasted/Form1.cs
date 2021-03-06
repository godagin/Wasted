using System;
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
            // register to the events that will apply FoodList changes to ListView
            FoodList.GetObject().AddedToList += addItemListView;
            FoodList.GetObject().RemovedFromList += removeItemListView;
            FoodList.GetObject().EditedListItem += reloadListView;

            // load all food offers from dbo.Foods to FoodList
            DatabaseHandler.GetHandler().LoadFoodList();
            MessageBox.Show("Imkite šiuos pasiūlymus! Didžiausi kiekiai šių produktų:"
                + "\n" + FoodList.GetObject().GetList().GetMostWeightingFood().Weight.ToString()
                + " " + FoodList.GetObject().GetList().GetMostWeightingFood().Name
                + "\n" + FoodList.GetObject().GetList().GetMostQuantityDiscreteFood().Quantity.ToString()
                + " " + FoodList.GetObject().GetList().GetMostQuantityDiscreteFood().Name);
        }

        private void remove_offer_Click(object sender, EventArgs e) 
        {
            FoodList.GetObject().RemoveAll(); //remove from Food List

            DatabaseHandler.GetHandler().RemoveAllFromFoodTable();

            lv_offer.Items.Clear();
        }

        private void add_new_offer_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
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

        private void reloadListView(object sender, EventArgs e)
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
            item.SubItems.Add(food.ExpDate.ToString("dd.MM.yy"));
            lv_offer.Items.Add(item);
        }

        private void removeItemListView(int index)
        {
            lv_offer.Items.RemoveAt(index);
        }
        

        private void add_file_offer_Click_1(object sender, EventArgs e)
        {
            lv_offer.BeginUpdate();
            
            ReadingFile file = new ReadingFile();
            string fileName = "file";
            file.ReadFileCsv(fileName);

            lv_offer.EndUpdate();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            int index = comboBoxSort.SelectedIndex;
      
            OfferComparer srt = new OfferComparer();
            srt.getSortOrder(index);
            FoodList.GetObject().GetList().Sort(srt);

            ///-----------reloading listview begins and sorting ends
            reloadListView(this, EventArgs.Empty);
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        
        private void search_bar_TextChanged(object sender, EventArgs e)
        {
            DataContext dc = new DataContext();
            string input = search_bar.Text;
            var searchedFood = from food in dc.Foods where food.Name.Contains(input) select food;
            lv_offer.Items.Clear();
            foreach (var item in searchedFood)
            {
                addItemListView(item);
            }
        }

        private void writing_to_file_Click(object sender, EventArgs e)
        {
            WritingToFile write = new WritingToFile();
            
            var offers = FoodList.GetObject().GetList();
            write.WriteToCsv(offers);
            MessageBox.Show("Pasiūlymai sėkmingai surašyti į failą.");
        }
    }
}

