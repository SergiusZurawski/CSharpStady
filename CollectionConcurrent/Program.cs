using System;

namespace CollectionConcurrent
{
    class Program
    {

        /// When working in a multithreaded environment,
        /// you need to make sure that you are not manipulating shared data at the same time without synchronizing access.
        /// 
        /// These collections are thread-safe
        ///  ■■ BlockingCollection<T> 
        ///  ■■ ConcurrentBag<T> 
        ///  ■■ ConcurrentDictionary<TKey,T> 
        ///  ■■ ConcurrentQueue<T>
        ///  ■■ ConcurrentStack<T>

        static void Main(string[] args)
        {
            Examples.Example5();
        }
    }
}
