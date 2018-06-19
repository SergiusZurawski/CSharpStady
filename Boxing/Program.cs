using System;

namespace Boxing
{
    class Program
    {
        /// boxing and unboxing operations can hurt performance; however, generic solve this issue
        
        static void Main(string[] args)
        {

            // All interfaces that INT32 implements
            IFormattable a = 3;
            Console.WriteLine(a);
            Console.WriteLine(a.GetType());
            IComparable b = 4;
            Console.WriteLine(b);
            Console.WriteLine(b.GetType());

            IConvertible c = 5;
            Console.WriteLine(c);
            Console.WriteLine(c.GetType());

            IComparable<int> d = 6;
            IEquatable<int> f = 7;

            //


        }
    }
}
