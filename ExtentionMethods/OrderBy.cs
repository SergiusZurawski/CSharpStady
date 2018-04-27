using System.IO;
using System.Linq;
using System;

namespace ExtentionMethods
{
    public static class OrderBy
    {
        //OrderBy - performs sorting
        // Methods: 
        //  OrderBy
        //  OrderByDescending
        // sort by more than one property
        //  ThenBy
        //  ThenByDescending
        /// One thing to note is that the ordering doesn’t change an existing collection—it returns a new sequence 
        // that yields the same data as the input sequence, except sorted. - "side-effect free" (FuncP)
        //  they don’t affect their input, 
        //  and they don’t make any other changes to the environment, 
        //  unless you’re iterating through a naturally stateful sequence (such as reading from a network stream) 
        //  or a delegate argument has side effects.
        public static void Example1()
        {
           var collection = Enumerable.Range(-5, 11)
                                .Select(x => new { Original = x, Square = x * x }) 
                                .OrderBy(x => x.Square) 
                                .ThenBy(x => x.Original); 

            foreach (var element in collection) 
            { 
                Console.WriteLine(element);
            }
        }
    }
}