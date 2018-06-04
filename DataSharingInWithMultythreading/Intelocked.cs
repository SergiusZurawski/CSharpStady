using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataSharingInWithMultythreading
{
    public class Intelocked
    {

        ///  When using the Interlocked.Increment and Interlocked.Decrement, you create an atomic operation, 
        ///  Interlocked guarantees that the increment and decrement operations are executed atomically. 
        ///     No other thread will see any intermediate results. 
        ///     Of course, adding and subtracting is a simple operation. If you have more complex operations, you would still have to use a lock. 
        /// Interlocked also supports switching values by using the Exchange method. 
        /// Interlocked.CompareExchange(ref value, newValue, compareTo);



        public static void Example1()
        {
            int n = 0;
            var up = Task.Run(() => 
                {
                    for (int i = 0; i < 1000000; i++)
                        Interlocked.Increment(ref n);
                });

            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);

            up.Wait();
            Console.WriteLine(n);

        }

        static int value = 1;
        public static void Example2()
        {
            Task t1 = Task.Run(() => {
                Console.WriteLine("------Over Here -------{0}", value);
                if (value == 1)
                {
                    Console.WriteLine("------Over Here -------");
                    // Removing the following line will change the output                 
                    Thread.Sleep(1000);
                    value = 2;
                }
            });

            Task t2 = Task.Run(() => 
                {
                    value = 3;
                });

            Task.WaitAll(t1, t2);
            Console.WriteLine(value); // Displays 2 

        }




    }
}
