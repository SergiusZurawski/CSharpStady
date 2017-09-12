using System;
using System.Linq;
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

        public static void ExampleWaitAll()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() => { 
                Thread.Sleep(1000); 
                Console.WriteLine("1");
                return 1; 
            });
            tasks[1] = Task.Run(() => { 
                Thread.Sleep(1000); 
                Console.WriteLine("2");
                return 2; 
            });
            tasks[2] = Task.Run(() => { 
                Thread.Sleep(1000); 
                Console.WriteLine("3");
                return 3; }
            );
           Task.WaitAll(tasks);
        }

        public static void ExampleWaitAny()
        {
            Task<int>[] atasks = new Task<int>[3];
            atasks[0] = Task.Run(() => {Thread.Sleep(2000); return 1;});
            atasks[1] = Task.Run(() => {Thread.Sleep(2000); return 2;});
            atasks[2] = Task.Run(() => {Thread.Sleep(2000); return 3;});

            // int [] ai = new int[] {1 ,2};
            // List<int> lst = ai.OfType<int>().ToList();
            // Console.WriteLine(lst);

            
            
            while(atasks.Length > 0)
            {
                int i = Task.WaitAny(atasks);
                Task<int> completedTask = atasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = atasks.ToList();
                temp.RemoveAt(i);
                atasks = temp.ToArray();
            }
        }
    }
}
