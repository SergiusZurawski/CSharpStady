using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//Parallel class only when your code doesn’t have to be executed sequentially
//
namespace Threads
{
    public static class ParallelExecution
    {
        public static void Example()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });
        }

        /*
        cancel the loop by using the ParallelLoopState object. 
            Break or Stop. 
            Break ensures that all iterations that are currently running will be finished.
            Stop just terminates everything.
         */
        public static void ExampleStopingParallelExecution()
        {
            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }
                return;
            });
            //Break
            Console.WriteLine(result.IsCompleted);          //isCompleted is  false 
            Console.WriteLine(result.LowestBreakIteration); //500.
            //Stop
            //LowestBreakIteration is null.

        }
    }
}
