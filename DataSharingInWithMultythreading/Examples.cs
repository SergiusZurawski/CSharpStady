using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataSharingInWithMultythreading
{
    public class Examples
    {

        ///  lock statement has to be a reference object that is private to the class
        ///     1. A public object could be used by other threads to acquire a lock without your code knowing
        ///     2. It should also be a reference type because a value type would get boxed each time you acquired a lock. 
        ///        In practice, this generates a completely new lock each time, losing the locking mechanism. 
        ///        Fortunately, the compiler helps by raising an error when you accidentally use a value type for the lock statement.
        ///     3. avoid locking on the this variable because that variable could be used by other code to create a lock, causing deadlocks. 
        ///     4. not lock on a string. Because of string-interning (the process in which the compiler creates one object for several strings that have the same content) 
        ///         you could suddenly be asking for a lock on an object that is used in multiple places.

        public static void Example1()
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    n++;
            });

            for (int i = 0; i < 1000000; i++)
                n--;
            up.Wait();
            Console.WriteLine(n);
        }

        public static void Example2()
        {
            int n = 0;
            object _lock = new object();

            var up = Task.Run(() => {
                for (int i = 0; i < 1000000; i++)
                    lock (_lock)
                        n++;
            });

            for (int i = 0; i < 1000000; i++)
                lock (_lock)
                    n--;
            up.Wait();
            Console.WriteLine(n);
        }

        public static void Example3DeadLock()
        {
            object lockA = new object();
            object lockB = new object();
            var up = Task.Run(() => 
            {
                lock (lockA) {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("LockedAandB");
                    }
                }
            });

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("LockedAandB");
                }
            }
            up.Wait();
        }
    }
}
