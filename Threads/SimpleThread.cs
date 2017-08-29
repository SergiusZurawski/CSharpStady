using System;
using System.Threading;

namespace Threads
{
    public static class SimpleThread
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000); 
            }
        }

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        public static void CallExample()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(1000);
            }
            t.Join(); // is called on the main Thread; Waits for other threads to finish
        }

        public static void CallExampleBackGroundProcess()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;  // True, application exists immediately
            //t.IsBackground = false; // false, application exists only if process finishes
            t.Start();
        }

        public static void CallExampleParametrized()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
        }
    }
}
