using System;
using System.Collections.Generic;
using System.Text;

namespace Wasted
{
    class Charity
    {
        public String Name { get; }

        public String Contacts { get; set; }

        public List<Food> Orders;// galbut sita pasiimsim padarius extension is userio?
        public Charity(string name)//šitas turėtų suveikti kai susikuria nauja charity paskyra????
        {
            this.Name = name;
            Orders = new List<Food>();
        }
    }
}
