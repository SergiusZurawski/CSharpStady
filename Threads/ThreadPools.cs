using System;
using System.Threading;

namespace Threads
{
    /*When working directly with the Thread class, you create a new thread each time, and the
    thread dies when you’re finished with it. The creation of a thread, however, is something that
    costs some time and resources.
    A thread pool is created to reuse those threads, similar to the way a database connection
    pooling works. Instead of letting a thread die, you send it back to the pool where it can be
    reused whenever a request comes in.*/
    public static class ThreadPools
    {
        public static void Example()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }
        /*  because threads are being reused, they also reuse their
            local state. You may not rely on state that can potentially be shared between multiple
            operations. 
        */

    }
}
