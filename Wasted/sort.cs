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
                                    // 0 1 - name, 2 3 - price, 4 5 - exp date, converted to string
            {
                if (sortOrder == 0)
                {
                    itemX.fieldToText = itemX.Name;
                    itemY.fieldToText = itemY.Name;

                    result = String.Compare(itemX.fieldToText, itemY.fieldToText);
                }
                else if (sortOrder == 4)
                {           
                    itemX.fieldToText = itemX.ExpDate.ToString("dd.MM.yy");
                    itemY.fieldToText = itemY.ExpDate.ToString("dd.MM.yy");
                    result = String.Compare(itemX.fieldToText, itemY.fieldToText);
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
                    itemX.fieldToText = itemX.Name;
                    itemY.fieldToText = itemY.Name;
                    result = String.Compare(itemX.fieldToText, itemY.fieldToText) * -1;
                }
                else if (sortOrder == 5)
                {
                    itemX.fieldToText = itemX.ExpDate.ToString("dd.MM.yy");
                    itemY.fieldToText = itemY.ExpDate.ToString("dd.MM.yy");
                    result = String.Compare(itemX.fieldToText, itemY.fieldToText) * -1;
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