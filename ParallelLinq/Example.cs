using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ParallelLinq
{

    //https://blogs.msdn.microsoft.com/pfxteam/2008/06/11/plinq-ordering/
    class ParralleExample
    {
        static DateTime localDate;
        static int haight = 5000;
        static IEnumerable<int> aEnum = Enumerable.Range(0, haight).AsParallel();  // Looks like executed siquentially

        public static void Example1NotOrderred()
        {
            Console.WriteLine("comma notation 1");
            IEnumerable<int> a = Enumerable.Range(0, haight).AsParallel();
            Console.WriteLine("comma notation 2");
            foreach (var i in a) { Console.Write(i); Console.Write(" "); }
            
        }

        public static void Example2NotOrderred()
        {
            Console.WriteLine("Linq 1");
            IEnumerable<int> a = from o in Enumerable.Range(0, haight).AsParallel() select o;
            //IEnumerable<int> a = from o in aEnum select o;
            Console.WriteLine("Linq 2");
            foreach (var i in a) { Console.Write(i); Console.Write(" "); }

        }

        public static void Example3Orderred()
        {
            Console.WriteLine("Linq 3.1");
            IEnumerable<int> a = from o in Enumerable.Range(0, haight).AsParallel().AsOrdered<int>() select o;
            Console.WriteLine("Linq 3.2");
            foreach (var i in a) { Console.Write(i); Console.Write(" "); }

        }

        public static void Example4ParallelQuery()
        {
            Console.WriteLine("Linq 4.1");
            ParallelQuery<int> a = from o in ParallelEnumerable.Range(0, haight).AsParallel() select o;
            Console.WriteLine("Linq 4.2");
            foreach (var i in a) { Console.Write(i); Console.Write(" "); }

        }

        public static void Example5ParallelQuery()
        {
            Console.WriteLine("Linq 5.1");
            ParallelQuery<int> a = from o in ParallelEnumerable.Range(0, haight).AsParallel().AsOrdered<int>() select o;
            Console.WriteLine("Linq 5.2");
            foreach (var i in a) { Console.Write(i); Console.Write(" "); }

        }

        public static void Example6ParallelQueryWithDotNotation()
        {
            Console.WriteLine("Linq 5.1");
            ParallelQuery<int> a = ParallelEnumerable.Range(0, haight).AsParallel();
            Console.WriteLine("Linq 5.2");
            foreach (var i in a) { Console.Write(i); Console.Write(" "); }

        }

        private static string giveMeCurrTime()
        {
            return DateTime.Now.ToString(new CultureInfo("en-GB"));
        }


    }
}
