using System;

namespace GarbageCollector
{
    class Program
    {
        /// finalizer - synatax as for constructor just add (~)
        /// 
        /// What’s important to understand is that a finalizer increases the life of an object. 
        ///     the finalization code also has to run, the .NET Framework keeps 
        ///     a reference to the object in a special finalization queue.
        ///     An additional thread runs all the finalizers at a time deemed appropriate based on the execution context. 
        ///     This delays garbage collection for types that have a finalizer.
        /// 

        /// IDisposable -  explicitly freeing unmanaged resources
        /// 

        /// finalizer   - cleans up your object, called by GC. 
        /// IDisposable - cleans up your object, can called by Code.

        ~Program()
        {
            // This code is called when the finalize method executes     
            //Inside the finalizer, you can clean up other resources and make sure that all memory is freed
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello from GarbegeCollector Program!");
            //FinilizerExample.Example();
            //FinilizerExample.ExampleForcingGCToCollect();
            //DisposebleExample.Example();
            DisposebleExample.ExampleUsingExample();
        }

        /*
          ■■ Memory in C# consists of both the stack and the heap. 
          ■■ The heap is managed by the garbage collector. 
          ■■ The garbage collector frees any memory that is not referenced any more. 
          ■■ A finalizer is a special piece of code that’s run by the garbage collector when it removes an object. 
          ■■ IDisposable can be implemented to free any unmanaged resources in a deterministic way. 
          ■■ Objects implementing IDisposable can be used with a using statement to make sure they are always freed. 
          ■■ A WeakReference can be used to maintain a reference to items that can be garbage collected when necessary.
        */
    }
}
