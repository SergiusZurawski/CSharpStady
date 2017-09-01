using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    /** ask, which is an object that
            represents some work that should be done. The Task can tell you if the work is completed and
            if the operation returns a result, the Task gives you the result.
        
        A task scheduler is responsible for starting the Task and managing it. By default, the Task
            scheduler uses threads from the thread pool to execute the Task.
         */
    public static class Tasks
    {
        public static void Example()
        {
            {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write("*");
                }
            });
            t.Wait();
            /* Calling Wait is equivalent tocalling Join on a thread. 
            It waits till the Task is finished before exiting the application. */
        }
        

    }
}
