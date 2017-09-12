using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

//Parallel class only when your code doesn’t have to be executed sequentially
//
namespace Threads
{
    public static class AsyncAwait
    {

        /*A method marked with async just starts running synchronously on the current thread.
            Async enables the method to be split into multiple pieces. 
            The boundaries of these pieces are marked with the await keyword. */

        /*
            For await keyword, the compiler generates code that will see whether your asynchronous operation is already finished. 
            If it is, your method just continues running synchronously. 
            If it’s not yet completed, the state machine will hook up a continuation method
            that should run when the Task completes. Your method yields control to the calling thread,
            and this thread can be used to do other work.
         */
        public static void Example()
        {
            string result = DownloadContent().Result;
            Console.WriteLine("-------1---------");
            Console.WriteLine(result);
        }

         public static async Task<string> DownloadContent()
        {
            using(HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;       
                        
            }
        }
        //responsiveness
        public Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }
        //Scalability
        public Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }

    }
}
