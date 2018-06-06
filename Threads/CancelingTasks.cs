using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    /*
     pass a CancellationToken to a Task, which then periodically monitors the token to see whether cancellation is requested.
    */
    public static class CancelingTasks
    {
        public static void Example()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token);

            Console.WriteLine("Pressentertostopthetask");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine("Pressentertoendtheapplication");
            Console.ReadLine();
        }
        /*  
         The CancellationToken is used in the asynchronous Task. 
         The CancellationTokenSource is used to signal that the Task should cancel itself.
          Outside users of the Task won’t see anything different because the Task will just have a RanToCompletion state.
        */


        //If you want to signal to outside users that your task has been canceled, you can do this by
        // throwing an OperationCanceledException

        public static void Example2()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token);
            try
            {
                Console.WriteLine("Pressentertostopthetask");
                Console.ReadLine();
                cancellationTokenSource.Cancel();
                task.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
            }
            Console.WriteLine("Pressentertoendtheapplication");
            Console.ReadLine();
        }

        ///Continuation
        public static void Example3()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                //token.ThrowIfCancellationRequested();
            }, token).ContinueWith((t) =>
            {
                t.Exception.Handle((e) => true);
                Console.WriteLine("You have canceled the task");
            }, TaskContinuationOptions.OnlyOnFaulted);
            Console.WriteLine("Pressentertostopthetask");
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine("Pressentertoendtheapplication");
            task.Wait();  //????
            Console.ReadLine();
        }

        ///  to cancel a Task after a certain amount of time, you can use an overload of
        ///     Task.WaitAny that takes a timeout.
        /// if the returned index is -1, the task timed out. It’s important to check for any possible errors
        ///     on the other tasks.If you don’t catch them, they will go unhandled.

        public static void Example4()
        {
            Task longRunning = Task.Run(() =>
            {
                Thread.Sleep(10000);
            });
            int index = Task.WaitAny(new[] { longRunning }, 1000);
            if (index == -1)
                Console.WriteLine("Task timed out");
        }
    }
}
