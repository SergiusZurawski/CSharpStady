using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostics
{
    public class WindowsEventLog
    {

        // ??
        // Ivestigat Promoting account from code
        //Ivestigate event sources
        public static void CallExample()
        {

            //Run as administrator
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "MySource";
            myLog.WriteEntry("Log event!");
        }

        public static void CallExample2()
        {
            EventLog log = new EventLog("MyNewLog");

            Console.WriteLine("Total entries: " + log.Entries.Count);
            EventLogEntry last = log.Entries[log.Entries.Count - 1];
            Console.WriteLine("Index:   " + last.Index);
            Console.WriteLine("Source:  " + last.Source);
            Console.WriteLine("Type:    " + last.EntryType); 
            Console.WriteLine("Time:    " + last.TimeWritten);
            Console.WriteLine("Message: " + last.Message);


        }
    }
}
