using DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LiNQExample
{
    class RangeVariables
    {
       

        public static void Example1()
        {
            IEnumerable<string> query = from user in SampleData.AllUsers select user.Name;

            foreach (string name in query) { Console.WriteLine(name); }

            // LINQ translated to methods call 
            Console.WriteLine("------LINQ translated to methods call ------");
            query = SampleData.AllUsers.Select(user => user.Name);

            foreach (string name in query) { Console.WriteLine(name); }
        }
        /// I enumerable has extention method for the LINQ call above
        // static IEnumerable<TResult> Select<TSource,TResult> (this IEnumerable<TSource> source, Func<TSource,TResult> selector)

        ///ArrayList and array
        // 11.2.4. Cast, OfType,
        //Cast and OfType.Only Cast is supported directly by the query expression syntax, but we’ll look at both in this section.The to the target type (and failing on any element that isn’t of the right type), and OfType does a test first, skipping any elements of the wrong type.
        public static void Example2()
        {
            ArrayList list = new ArrayList { "First", "Second", "Third" };
            var strings = list.Cast<string>();
            foreach (string item in strings)
            {
                Console.WriteLine(item);
            }


            list = new ArrayList { 1, "not an int", 2, 3 };
            var ints = list.OfType<int>();   //TypeOf sckips , no exception
            foreach (int item in ints)
            {
                Console.WriteLine(item);
            }
        }

        /// ATENTION: Elements are streamed. So I you had tried cast for second arrya . I would have populated 1 and only then throw exception
        /// 
        /*
         If you want any conversion other than a reference conversion 
         or an unboxing conversion (or the no-op identity conversion), use a Select projection instead.
         */


        /*
         When you introduce a range variable with an explicit type, 
         the compiler uses a call to Cast to make sure the sequence used by the 
         rest of the query expression is of the appropriate type.
         */
        public static void Example3()
        {
            ArrayList list = new ArrayList { "First", "Second", "Third" };
            var strings = from string entry in list
                          select entry.Substring(0, 3);


            foreach (string start in strings)
            {
                Console.WriteLine(start);
            }

            ///Translated query is  list. Cast<string>() .Select(entry => entry.Substring(0,3));
        }
    }
}
