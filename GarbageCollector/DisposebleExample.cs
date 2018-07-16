using System;
using System.IO;

namespace GarbageCollector
{
    public class DisposebleExample
    {
        /*
            public interface IDisposable  {void Dispose();}
        */

        public static void Example()
        {
            StreamWriter stream = File.CreateText("temp.dat");
            stream.Write("some data");
            stream.Dispose();
            File.Delete("temp.dat"); 
            // Throws an IOException because the file is already open.
        }

        /*
          To make sure that your resources are always cleaned up, 
            you need to wrap all types that implement IDisposable in a try/finally statement.
          C# has a special statement for this: the using statement.
          using -  ensures that Dispose is always called
       */
        public static void ExampleUsingExample()
        {
            using (StreamWriter sw = File.CreateText("temp.dat"))
            {
                sw.Write("some data");
            }
            File.Delete("temp.dat");

        }

        /*
         After disposing an item, you can’t use it any more. Using a disposed item will result in an ObjectDisposedException. 
         */
    }
}
