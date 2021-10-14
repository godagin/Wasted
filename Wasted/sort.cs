//using System;
//using System.Collections.Generic;

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
    
    /* class AlphabeticSortAToZ : IComparer<Food>
     {
         public int Compare(Food x, Food y)
         {
             if (x.Name == y.Name) // Same name -> sort price low to high
             {
                 if (x.FullPrice > y.FullPrice)
                     return 1;
                 else if (x.FullPrice < y.FullPrice)
                     return -1;
                 else
                     return 0;
             }
             else
                 return string.Compare(x.Name, y.Name);  
         }
     }
     class AlphabeticSortZToA : IComparer<Food>
     {
         public int Compare(Food x, Food y) // Same name -> sort price low to high
         {
             if (x.Name == y.Name)
             {
                 if (x.FullPrice > y.FullPrice)
                     return 1;
                 else if (x.FullPrice < y.FullPrice)
                     return -1;
                 else
                     return 0;
             }
             else
                 return string.Compare(x.Name, y.Name) * (-1);
         }
     }
     class PriceSortLowToHigh : IComparer<Food>
     {
         public int Compare(Food x, Food y)
         {
             if (x.FullPrice == y.FullPrice) // Same price -> sort name A to Z
                 return string.Compare(x.Name, y.Name);
             else if (x.FullPrice > y.FullPrice)
                 return 1;
             else if (x.FullPrice < y.FullPrice)
                 return -1;
             else
                 return 0;
         }
     }
     class PriceSortHighToLow : IComparer<Food>
     {
         public int Compare(Food x, Food y)
         {
             if (x.FullPrice == y.FullPrice) // Same price -> sort name A to Z 
                 return string.Compare(x.Name, y.Name);
             else if (x.FullPrice < y.FullPrice)
                 return 1;
             else if (x.FullPrice > y.FullPrice)
                 return -1;
             else
                 return 0;
         }
     }

     class ExpSortLowToHigh : IComparer<Food>
     {
         public int Compare(Food x, Food y)
         {
             if (x.ExpDate > y.ExpDate)
                 return 1;
             else if (x.ExpDate < y.ExpDate)
                 return -1;
             else
                 return 0;
         }
     }
     class ExpSortHighToLow : IComparer<Food>
     {
         public int Compare(Food x, Food y)
         {
             if (x.ExpDate < y.ExpDate)
                 return 1;
             else if (x.ExpDate > y.ExpDate)
                 return -1;
             else
                 return 0;
         }
     }*/
}