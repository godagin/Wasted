using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Wasted
{
     class OfferComparer : IComparer<Food>
    {
        int sortOrder;
        public void getSortOrder(int index) // gets chosen option (as an index)
        {
            sortOrder = index;
        }

        public int Compare(Food itemX, Food itemY)
        {
            int result;

            if (sortOrder % 2 == 0) // even numbers - asc order, uneven - desc 
                                    // 0 1 - name, 2 3 - price, 4 5 - exp date
            {
                if (sortOrder == 0)
                {
                    result = String.Compare(itemX.Name, itemY.Name);
                }
                else if (sortOrder == 4)
                {           
                    result = String.Compare(itemX.ExpDate.ToString("dd.MM.yy"), itemY.ExpDate.ToString("dd.MM.yy"));
                }
                else
                {
                    if (itemX.FullPrice > itemY.FullPrice)
                        result = 1;
                    if (itemX.FullPrice < itemY.FullPrice)
                        result = -1;
                    else
                        result = 0;
                }
            }
            else
            {
                if (sortOrder == 1)
                {
                    result = String.Compare(itemX.Name, itemY.Name) * -1;
                }
                else if (sortOrder == 5)
                {
                    result = String.Compare(itemX.ExpDate.ToString("dd.MM.yy"), itemY.ExpDate.ToString("dd.MM.yy")) * -1;
                }
                else
                {
                    if (itemX.FullPrice < itemY.FullPrice)
                        result = 1;
                    if (itemX.FullPrice > itemY.FullPrice)
                        result = -1;
                    else
                        result = 0;
                }
            }
            return result;
        }
     }
}
