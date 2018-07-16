using System;

namespace GarbageCollector
{
    /*
      WeakReference doesn’t hold a real reference to an item on the heap, 
        so that it can’t be garbage collected. 
        But when garbage collection hasn’t occurred yet, 
        you can still access the item through the WeakReference.

      Using WeakReference is not a complete solution for a caching scenario.
   */
    public class WeakReferenceExample
    {
        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            // GC.Collect(); Uncommenting this line will make data.Target null     
            result = GetData();
        }

        //The GetData function checks that the WeakReference still contains data
        private static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargeList());
            }

            if (data.Target == null)
            {
                data.Target = LoadLargeList();
            }
            return data.Target;
        }

        private static object LoadLargeList()
        {
            throw new NotImplementedException();
        }
    }
}
