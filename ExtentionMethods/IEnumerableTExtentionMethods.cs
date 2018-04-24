using System.IO;
using System.Linq;
using System;

namespace ExtentionMethods
{
    public static class IEnumerableTExtentionMethods
    {
        public static void Example1()
        {
            // Range - Deferred execution -  Range method doesn’t build a list with the appropriate numbers—it just yields them at the appropriate time.
            var collection = Enumerable.Range(0, 10); 
            foreach (var element in collection) 
            { 
                Console.WriteLine(element);
            }
        }

         public static void Example2()
        {
            var collection = Enumerable.Range(0, 10).Reverse();
            foreach (var element in collection) 
            { 
                Console.WriteLine(element);
            }
        }
        /*
                "return the same reference” pattern works well for mutable types,
                "return a new instance that’s a copy of the original with some changes" - immutable types
                but extension methods allow static method calls to be chained together. This is one of the primary reasons why extension methods exist.
        */

        public static void Example3_FilteringWithWhere()
        {
            Console.WriteLine("Example3_FilteringWithWhere");
            
            var collection = Enumerable.Range(0, 10).Where(x => x % 2 != 0).Reverse(); 
            foreach (var element in collection) 
            { 
                Console.WriteLine(element); 
            }
        }

        public static void Example4_FilteringWithWhere()
        {
            //The same code as above but written in alternative way(More wordy)
            Console.WriteLine("Example4_FilteringWithWhere");
            
            var collection = Enumerable.Range(0, 10); 
            collection = Enumerable.Where(collection, x => x % 2 != 0);
            collection = Enumerable.Reverse(collection);

            foreach (var element in collection) 
            { 
                Console.WriteLine(element); 
            }
        }

         public static void Example5_FilteringWithWhere()
        {
            //The same code as above but written in alternative way(show immutability of the original type)
            Console.WriteLine("Example5_FilteringWithWhere");
            
            var collection = Enumerable.Range(0, 10); 
            var collection1 = Enumerable.Where(collection, x => x % 2 != 0);
            var collection2 = Enumerable.Reverse(collection1);

            Console.WriteLine("Collection 0 didn't changed");
            collection.ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("Collection 1 didn't changed");
            collection1.ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("Collection 2 ");
            collection2.ToList().ForEach(i => Console.WriteLine(i));
        }
        public static void Example6_FilteringWithWhere()
        {
            // One query example, The same code
            var collection = Enumerable.Reverse(Enumerable.Where(Enumerable.Range(0, 10), x => x % 2 != 0));
        }

        // Implementing where method manually
        
    }
   
}