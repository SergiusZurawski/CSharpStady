using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Iterators
{
    // Iterator pattern , with Yeald statment
    public class VisualizingAnIteratorWorkflow
    {
        static readonly string Padding = new string(' ', 30);

        public static IEnumerable<int> CreateEnumerable()
        {
            Console.WriteLine("{0}Start of CreateEnumerable()", Padding);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}About to yield {1}", Padding, i);
                yield return i;
                Console.WriteLine("{0}After yield", Padding);
            }
            Console.WriteLine("{0}Yielding final value", Padding);
            yield return -1;
            Console.WriteLine("{0}End of CreateEnumerable()", Padding);

        }
    }
    /*
        - None of the code in CreateEnumerable is called until the first call to MoveNext .
        - It’s only when you call MoveNext that any real work gets done. Fetching Current doesn’t run any of your code.
        - The code stops executing at yield return and picks up again just afterward at the next call to MoveNext .
        - You can have multiple yield return statements in different places in the method.
        - The code doesn’t end at the last yield return . Instead, the call to MoveNext that causes you to reach the end of the method is the one that returns false .
        - Note that methods taking ref or out parameters can’t be implemented with iterator blocks.
     */

    public class CallOrder
    {

        public static void CallExample()
        {
            Console.WriteLine(CallOrderReturn());
            /* Output
                before return
                finally
                1
             */
        }

        public static int CallOrderReturn()
        {
            try
            {
                Console.WriteLine("before return");
                return 1;
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }

        //Braking Iterator Early
        public static void CallExampleWithBreak()
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach (int i in CountWithTimeLimit(stop))
            {
                Console.WriteLine("recieved {0}", i);
                Thread.Sleep(300);
            }
        }

        static IEnumerable<int> CountWithTimeLimit(DateTime limit)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (DateTime.Now >= limit)
                {
                    yield break;
                }
                yield return i;
            }
        }

        //Braking Iterator Early with Finially
        public static void CallExampleWithBreakWithFinially()
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach (int i in CountWithTimeLimitWithFinally(stop))
            {
                Console.WriteLine("recieved {0}", i);
                Thread.Sleep(300);
            }
        }

        //Braking Iterator Early with Finially And Retrun In Calling Mehod (Code That using the iterator)
        // It exetures Finally from iterator becasue foreach loop is calling Dispose , dispose is call finally in itterator.
        public static void CallExampleWithBreakWithFiniallyAndRetrunInCallingMehod()
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            foreach (int i in CountWithTimeLimitWithFinally(stop))
            {
                Console.WriteLine("recieved {0}", i);
                if (i > 3)
                {
                    Console.WriteLine("Returning");
                    return;
                }
                Thread.Sleep(300);
            }
        }

        public static void CallExampleWithBreakWithFiniallyAndRetrunInCallingMehodWithoutForEach()
        {
            DateTime stop = DateTime.Now.AddSeconds(2);
            IEnumerable<int> iterable = CountWithTimeLimitWithFinally(stop);
            IEnumerator<int> iterator = iterable.GetEnumerator();

            iterator.MoveNext();
            Console.WriteLine("recieved {0}", iterator.Current);
            //Thread.Sleep(3000);  // IF you add this then finialy will be called
            iterator.MoveNext();
            Console.WriteLine("recieved {0}", iterator.Current);

        }

        static IEnumerable<int> CountWithTimeLimitWithFinally(DateTime limit)
        {
            try
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (DateTime.Now >= limit)
                    {
                        yield break;
                    }
                    yield return i;
                }
            }
            finally
            {
                //Executes However the loop ends
                Console.WriteLine("Stopping!");
            }
        }


    }

}