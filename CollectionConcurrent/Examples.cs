using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CollectionConcurrent
{
    public class Examples
    {


        public static void Example1()
        {
            ///This collection is thread-safe for adding and removing data
            ///  Removing an item from the collection can be blocked until data becomes available. 
            ///   Adding data is fast, but you can set a maximum upper limit. If that limit is reached, 
            ///   adding an item blocks the calling thread until there is room. 
            ///   BlockingCollection is in reality a wrapper for other collection types (ConcurrentQueue)
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() => 
                        { while (true)
                            {
                                Console.WriteLine(col.Take());
                            }
                        });
            Task write = Task.Run(() => 
                        { while (true)
                            {
                                string s = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(s))
                                    break;
                                col.Add(s);
                            }
                        });
            write.Wait(); //the System.Threading.Tasks.Task to complete execution.
        }


        //To avoide while you can use Enumberable.
        // CompleteAdding method to signal to the BlockingCollection that no more items will be added. 
        //    If other threads are waiting for new items, they won’t be blocked anymore. 

        public static void Example2()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() => {
                foreach (string v in col.GetConsumingEnumerable()) Console.WriteLine(v);
            });
        }
		// ConcurrentBag - Represents a thread-safe, unordered collection of objects.  bags support duplicates, accepts null as a valid value for reference types.
        public static void Example3()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            if (bag.TryTake(out result))
                Console.WriteLine(result);

            //TryPeek method is not very useful in a multithreaded environment.
            // It could be that another thread removes the item before you can access it. 
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a nextitem:{0}", result);
        }

        //ConcurrentBag also implements IEnumerable<T>,
        ///  This operation is made thread-safe by making a snapshot of the collection 
        ///  when you start iterating it, so items added to the collection 
        ///  after you started iterating it won’t be visible. Listing 
        public static void Example4()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() => 
                    {
                        bag.Add(42);
                        Thread.Sleep(1000);
                        bag.Add(21);
                    });
            Task.Run(() => 
                    {
                        Thread.Sleep(200);
                        foreach (int i in bag)
                            Console.WriteLine(i);
                    }).Wait();

        }

        //ConcurrentStack and ConcurrentQueue 
        public static void Example5()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped:{0}", result);

            stack.PushRange(new int[] { 1, 2, 3 });

            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (int i in values)
                Console.WriteLine(i);

            // Popped: 42 
            // 3 
            // 2


        }

        /// 
        /// ConcurrentQueue offers the methods Enqueue and TryDequeue to add and remove items from the collection.
        /// It also has a TryPeek method and it implements IEnumerable by making a snapshot of the data.
        /// 

        public static void Example6()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine("Dequeued:{0}", result);

            // Dequeued: 42

        }
        ///  ConcurrentDictionary stores key and value pairs in a thread-safe manner. 
        ///  You can use methods to add and remove items, and to update items in place if they exist. 
        ///  ConcurrentDictionary  has methods that can atomically add, get, and update items. 
        ///   An atomic operation means that it will be started and finished as a single step without other threads interfering. 
        ///   TryUpdate checks to see whether the current value is equal to the existing value before updating it. 
        ///   AddOrUpdate makes sure an item is added if it’s not there, and updated to a new value if it is
        ///   GetOrAdd gets the current value of an item if it’s available; if not, it adds the new value by using a factory method.



        public static void Example7()
        {
            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }
            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42updatedto21");
            }
            dict["k1"] = 42; // Overwrite unconditionally 

            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3);
        }
    }
}
