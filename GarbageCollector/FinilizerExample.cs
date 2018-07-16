using System;
using System.IO;

namespace GarbageCollector
{
    public class FinilizerExample
    {
        ~FinilizerExample()
        {
            
        }

        public static void Example()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            File.Delete("temp.dat"); 
            // Throws an IOException because the file is already open.
        }

        public static void ExampleForcingGCToCollect()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete("temp.dat");
            // Doesn't Throw an IOException
        }
    }
}
