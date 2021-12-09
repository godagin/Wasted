using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebWasted
{
    public class Logger
    {
        private static readonly Lazy<Logger> lazy =
            new Lazy<Logger>(() => new Logger());

        public static Logger Instance { get { return lazy.Value; } }

        public DataContext dc = new DataContext();

        private StreamWriter streamWriter;

        private Logger()
        {
            Directory.CreateDirectory(@".\Logs\");
            streamWriter = File.AppendText(@".\Logs\Log.txt");
        }
        public void Log<T>(T logObject)
        {
            lock (streamWriter)
            {
                if (logObject is Exception)
                {
                    streamWriter.WriteLine("Log | Exception: " + logObject.ToString());
                }
                else
                {
                    streamWriter.WriteLine(logObject.ToString());
                }

                streamWriter.Flush();
            }

        }
    }
}