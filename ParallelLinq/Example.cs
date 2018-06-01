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

        public static void ExampleCLIDecidesWhetherToUseparalelismOrNot()
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
                            .Where(i => i % 2 == 0)
                            .ToArray();
            foreach (var i in parallelResult) { Console.Write(i); Console.Write(" "); }
        }

        public static void ExampleEnforsingParalelism()
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
                            .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                            .Where(i => i % 2 == 0)
                            .ToArray();
            foreach (var i in parallelResult) { Console.Write(i); Console.Write(" "); }
        }

        public static void ExampleLimitAmountOfParalelizm()
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
                            .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                            .WithDegreeOfParallelism(2)
                            .Where(i => i % 2 == 0)
                            .ToArray();
            foreach (var i in parallelResult) { Console.Write(i); Console.Write(" "); }
        }

        //Don't Undestand difference betten prevoius queries
        public static void ExampleUnordered1()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }

        public static void ExampleOrdered1()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
                                        .AsOrdered()
                                        .Where(i => i % 2 == 0).ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }

        public static void ExampleOrderedSequential()
        {
            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).AsSequential();

            foreach (int i in parallelResult.Take(5)) Console.WriteLine(i);

        }


        /// <summary>
        /// In contrast to foreach, ForAll does not need all results before it starts executing.
        /// In this example, ForAll does, however, remove any sort order that is specified. 
        /// </summary>
        public static void ExampleForAll()
        {
            var numbers = Enumerable.Range(0, 20);

            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));

        }

        /// <summary>
        /// if an operation parallel query throw an exception
        ///  Framework handles this by aggregating all exceptions into one AggregateException. 
        ///  This exception exposes a list of all exceptions that have happened during parallel execution. 
        /// </summary>
        public static void ExampleAggregateException()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i)); parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Therewhere {0} exceptions", e.InnerExceptions.Count);
            }
        }

        public static bool IsEven(int i)
        {
            if (i % 10 == 0)
                throw new ArgumentException("i");
            return i % 2 == 0;
        }
        private static string giveMeCurrTime()
        {
            return DateTime.Now.ToString(new CultureInfo("en-GB"));
        }


    }
}
