using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    // be warned 
    // 1. that contravariance doesn’t apply to anonymous methods; 
    //   you have to specify the parameter types that match the delegate type exactly.

    // 2. if you’re writing an anonymous method in a value type, 
    //   you can’t reference this from within it. 
    //   There’s no such restriction within a reference type.

    // 

    public class DelegatesAnonimusMethod
    {
        static Action<string> printReverse = delegate (string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            Console.WriteLine(new string(chars));
        };

        static Action<int> printRoot = delegate (int number)
        {
            Console.WriteLine(Math.Sqrt(number));
        };

        static Action<IList<double>> printMean = delegate (IList<double> numbers)
        {
            double total = 0;
            foreach (double value in numbers)
            {
                total += value;
            }
            Console.WriteLine(total / numbers.Count);
        };

        //Returning values from anonymous methods
        static Predicate<int> isEven = delegate (int x) { return x % 2 == 0; };

        public static void Example()
        {
            printReverse("Hello world");
            printRoot(2);
            printMean(new double[] { 1.5, 2.5, 4.5 });

            // in inline Delegate call
            List<int> x = new List<int>();
            x.Add(5);
            x.Add(10);
            x.ForEach(delegate (int n) { Console.WriteLine(Math.Sqrt(n)); });

            //Using delegate that return a value 
            Console.WriteLine(isEven(1));
            Console.WriteLine(isEven(4));
        }

        //Usefulness of delegate , we can use different type of sort by specifing it in place
        static void SortAndShowFiles(string title, Comparison<FileInfo> sortOrder)
        {
            FileInfo[] files = new DirectoryInfo(@"C:\").GetFiles();
            Array.Sort(files, sortOrder);
            Console.WriteLine(title);
            foreach (FileInfo file in files)
            {
                Console.WriteLine(" {0} ({1} bytes)", file.Name, file.Length);
            }
        }

        public static void ExampleSortingByPassingInlineDeleagete()
        {
            SortAndShowFiles("Sorted by name:", delegate (FileInfo f1, FileInfo f2) { return f1.Name.CompareTo(f2.Name); });
            SortAndShowFiles("Sorted by length:", delegate (FileInfo f1, FileInfo f2) { return f1.Length.CompareTo(f2.Length); });
        }

        // Ignoring delegate parameters
        delegate void DelegateWithoutArguments();

        public static void ExampleIgnoringParameters()
        {
            //omit argument part
            DelegateWithoutArguments delegateNoArgs = delegate {Console.WriteLine("LogKey");};
            DelegateWithoutArguments delegateNoArgs2 = delegate { Console.WriteLine("SomeDeleateWithout Argument"); };

            //Warning
            //if the anonymous method could be converted to multiple delegate types
            // (for example, to call different method overloads), the compiler needs more help.

            /*
                Thread Start has following constructors which acepts delegates: 

                    public Thread(ParameterizedThreadStart start) 
                    public Thread(ThreadStart start) 
                    public Thread(ParameterizedThreadStart start, int maxStackSize) 
                    public Thread(ThreadStart start, int maxStackSize)

                    these constructors accept the following delegates: 
                    public delegate void ThreadStart() 
                    public delegate void ParameterizedThreadStart(object obj)

             */

            new Thread(delegate () { Console.WriteLine("t1"); });
            new Thread(delegate (object o) { Console.WriteLine("t2"); });
            //new Thread(delegate { Console.WriteLine("t3"); });  //Exception compiler cannot undertand which deleagete it is.


        }
    }
}

