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

        // Stop thread 
        public static void CallExampleStopThread()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Abort();  // Not Recomended
            t.Join();
        }

        // Recommended way to use a shared variable
        public static void CallExampleSafeStopThread()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() => 
            {                
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            
            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped  = true;
            t.Join();
        }

        //Thread Static 
        [ThreadStatic]
        public static int _field;  //A thread can also have its own data that’s not a local variable. By marking a field with the
                                    //ThreadStatic attribute, each thread gets its own copy of a field
        public static void CallExampleThreadStatic()
        {
            new Thread(() =>
               { 
                    for(int x = 0; x < 10; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread A: {0}", _field);
                    }
                }).Start();

            new Thread(() =>
                {  for(int x = 0; x < 10; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread B: {0}", _field);
                    }
                }).Start();
                Console.ReadKey();
        }

        //ThreadLocal<T>
        public static ThreadLocal<int> _fieldLocal = 
            new ThreadLocal<int>(() => 
            {
                return Thread.CurrentThread.ManagedThreadId;
            });
        
        public static void CallExampleThreadLocal()
        {
            new Thread(() =>
                { 
                    for(int x = 0; x < _fieldLocal.Value; x++)
                    {
                        Console.WriteLine("Thread local A: {0}", x);
                    }
                }).Start();
            
             new Thread(() =>
                {
                    for (int x = 0; x < _fieldLocal.Value; x++)
                    {
                        Console.WriteLine("Thread local B: {0}", x);
                    }
                }).Start();
            Console.ReadKey();
        }
        

    }
}
