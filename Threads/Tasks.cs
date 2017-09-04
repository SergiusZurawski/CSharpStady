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
        public static void ExampleWithReturnValues()
        {
            
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            Console.WriteLine(t.Result); // Displays 42, PA; NO Wait
            /** Attempting to read the Result property on a Task will force the thread that’s trying to
                read the result to wait until the Task is finished before continuing. As long as the Task has not
                finished, it is impossible to give the result. If the Task is not finished, this call will block the
                current thread. 
            */
        }

        public static void ExampleContinuationTask()
        {
            
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            Console.WriteLine(t.Result); // Displays 84
        }

        public static void ExampleContinuationTask2()
        {
            
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask =  t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }

        public static void ExampleChildTask()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, 
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, 
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, 
                    TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(parentTask => {
                   foreach(int i in parentTask.Result)
                    Console.WriteLine(i);
               });
           
            finalTask.Wait();
            /** 
            The finalTask runs only after the parent Task is finished, and the parent Task finishes when all three children are finished.
             */
        }
        public static void ExampleChildTaskFactory()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];  
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, 
                   TaskContinuationOptions.ExecuteSynchronously);
                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);
                return results;
            });
            var finalTask = parent.ContinueWith(
               parentTask => {
                   foreach(int i in parentTask.Result)
                   Console.WriteLine(i);
               });
            finalTask.Wait();
            //use the method WaitAll to wait for multiple Tasks to finish before continuing executio
        }
    }
}
