using System;
using System.Collections.Generic;

namespace Iterators

/*
 * Quirks
    1. Before MoveNext is called the first time, the Current property will always return the default value for the yield type of the iterator.
    2. After MoveNext has returned false , the Current property will always return the final value yielded.
    3. Reset always throws an exception instead of resetting like your manual implementation did. This is required behavior, laid down in the specification.
    4. The nested class always implements both the generic and nongeneric forms of IEnumerator (and the generic and nongeneric IEnumerable , where appropriate).

*/
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            object[] values = { "a", "b", "c", "d", "e" };
            IteratingOverDates collection = new IteratingOverDates(values, 3);
            foreach (object x in collection)
            {
                Console.WriteLine(x);
            }

            // Visualizing an iterator’s workflow
            IEnumerable<int> iterable = VisualizingAnIteratorWorkflow.CreateEnumerable();
            IEnumerator<int> iterator = iterable.GetEnumerator();
            Console.WriteLine("Starting to iterate");
            while (true) {
                Console.WriteLine("Calling MoveNext()...");
                bool result = iterator.MoveNext();
                Console.WriteLine("... MoveNext result={0}", result);
                if (!result)
                {
                    break;
                }
                Console.WriteLine("Fetching Current...");
                Console.WriteLine("... Current result={0}", iterator.Current);
            }

            // Iterator with Break 
            CallOrder.CallExampleWithBreak();
            // Iterator with Break And Finially
            CallOrder.CallExampleWithBreakWithFinially();
            // Iterator with Break And Finially and Return from Calling method
            CallOrder.CallExampleWithBreakWithFiniallyAndRetrunInCallingMehod();
            // Iterator with Break And Finially and manual iteration
            CallOrder.CallExampleWithBreakWithFiniallyAndRetrunInCallingMehodWithoutForEach();
            
            */
            OldFileReader.CallExample();
            NewFileReader.CallExample();
        }
    }
}
