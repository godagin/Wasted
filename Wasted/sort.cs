using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Wasted
{
    public class ItemComparer : IComparer
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
    }
    
}