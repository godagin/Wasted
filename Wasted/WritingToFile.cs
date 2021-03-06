using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Wasted
{
    class WritingToFile
    {

        public WritingToFile()
        {

        }

        public void WriteToCsv<T>(IEnumerable<T> items)
        {
            Type itemType = typeof(T);
            //controls binding and specifies that only public and instance members will be included in this search
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string fileName = itemType.Name + ".csv";
            string path = Path.GetFullPath(Directory.GetParent(Directory.GetCurrentDirectory())
                 .Parent + fileName);
            using (var writer = new StreamWriter(path))
            {
                //this line writes column names(headers)
                //(p => p.Name) ------> it's lambda expression (inputParameter => expression)
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name).Skip(1)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null)).Skip(1)));
                }
            }
        }

    }
}
