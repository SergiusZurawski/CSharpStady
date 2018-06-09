using System;

namespace DataSharingInWithMultythreading
{
    class Program
    {
        /*
            When accessing shared data in a multithreaded environment, you need to synchronize
                access to avoid errors or corrupted data.
            ■ Use the lock statement on a private object to synchronize access to a piece of code.
            ■ You can use the Interlocked class to execute simple atomic operations.
            ■ You can cancel tasks by using the CancellationTokenSource class with a
            CancellationToken
         */
        static void Main(string[] args)
        {
            //Examples.Example1();
            //Examples.Example2();
            //Console.WriteLine("----------");
            //Volatile.Example1();
            //Intelocked.Example1();
            Intelocked.Example2();
        }
    }
}
