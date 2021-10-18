using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Wasted
{
 /*  public class ItemComparer : IComparer
    {
        public int Column { get; set; }
        
        public SortOrder Order { get; set; }
        public ItemComparer(int colIndex)
        {
            Column = colIndex;
            Order = SortOrder.None;
        }
        public int Compare(object x, object y)
        {
            int result;
            ListViewItem itemX = x as ListViewItem;
            ListViewItem itemY = y as ListViewItem;

             if (itemX == null && itemY == null)
                result = 0;
             else if (itemX == null)
                result = -1;
             else if (itemY == null)
                result = 1;
             if (itemX == itemY)
                result = 0;
            
             result = String.Compare(itemX.SubItems[Column].Text, itemY.SubItems[Column].Text);
           
             if (Order == SortOrder.Descending)
                result *= -1;

             return result;
        }
    }*/
    //--------------------
     class OfferComparer : IComparer<Food>
    {
        int sortOrder;
        //string fieldToText;

        public void getSortOrder(int index) // gets chosen option(as an index)
        {

            sortOrder = index;
       
        }

        public int Compare(Food itemX, Food itemY)
        {
            int result;


            //  Food itemX = x as Food;
            //  Food itemY = y as Food;

            if (sortOrder % 2 == 0) // even numbers - asc order, uneven - desc 
                                    // 0 1 - name, 2 3 - price, 4 5 - exp date, converted to string
            {
                if (sortOrder == 0)
                {
                    itemX.fieldToText = itemX.Name;
                    itemY.fieldToText = itemY.Name;
                }
                else if (sortOrder == 2)
                {
                    itemX.fieldToText = itemX.FullPrice.ToString();
                    itemY.fieldToText = itemY.FullPrice.ToString();
                }
                else
                {
                    itemX.fieldToText = itemX.ExpDate.ToString("dd.MM.yy");
                    itemY.fieldToText = itemY.ExpDate.ToString("dd.MM.yy");
                }
            }
            else
            {

                if (sortOrder == 1)
                {
                    itemX.fieldToText = itemX.Name;
                    itemY.fieldToText = itemY.Name;
                }
                else if (sortOrder == 3)
                {
                    itemX.fieldToText = itemX.FullPrice.ToString();
                    itemY.fieldToText = itemY.FullPrice.ToString();
                }
                else
                {
                    itemX.fieldToText = itemX.ExpDate.ToString("dd.MM.yy");
                    itemY.fieldToText = itemY.ExpDate.ToString("dd.MM.yy");
                }
            }


            if (itemX == null && itemY == null)
                result = 0;
            else if (itemX == null)
                result = -1;
            else if (itemY == null)
                result = 1;
            if (itemX == itemY)
                result = 0;

            result = String.Compare(itemX.fieldToText, itemY.fieldToText);

            if (sortOrder % 2 != 0) // non even indexes - sort desc
                result *= -1;

            return result;
        }
    }




}