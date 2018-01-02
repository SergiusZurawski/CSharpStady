using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterators
{
    // Iterator pattern , with Yeald statment
    public class VisualizingAnIteratorWorkflow
    {
        static readonly string Padding = new string(' ', 30);

        public static IEnumerable<int> CreateEnumerable()
        {
            Console.WriteLine("{0}Start of CreateEnumerable()", Padding);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}About to yield {1}", Padding, i);
                yield return i;
                Console.WriteLine("{0}After yield", Padding);
            }
            Console.WriteLine("{0}Yielding final value", Padding);
            yield return -1;
            Console.WriteLine("{0}End of CreateEnumerable()", Padding);


        }

    }
}