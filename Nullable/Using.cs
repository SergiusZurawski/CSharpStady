using System;

namespace Nullable
{
    class Using
    {
        public static void CallExample()
        {
            Nullable<int> x = 5;
            x = new Nullable<int>(5);
            Console.WriteLine("Instance with value:");
            Display(x);
            x = new Nullable<int>();
            Console.WriteLine("Instance without value:");
            Display(x);
        }

        /* Output
        Instance with value:
        HasValue: True
        Value: 5
        Explicit conversion: 5
        GetValueOrDefault(): 5
        GetValueOrDefault(10): 5
        ToString(): "5"
        GetHashCode(): 5
        Instance without value:
        HasValue: False
        GetValueOrDefault(): 0
        GetValueOrDefault(10): 10
        ToString(): ""
        GetHashCode(): 0
         */

        static void Display(Nullable<int> x)
        {
            Console.WriteLine("HasValue: {0}", x.HasValue);
            if (x.HasValue)
            {
                Console.WriteLine("Value: {0}", x.Value);
                Console.WriteLine("Explicit conversion: {0}", (int)x);
            }
            Console.WriteLine("GetValueOrDefault(): {0}",
            x.GetValueOrDefault());
            Console.WriteLine("GetValueOrDefault(10): {0}",
            x.GetValueOrDefault(10));
            Console.WriteLine("ToString(): \"{0}\"", x.ToString());
            Console.WriteLine("GetHashCode(): {0}", x.GetHashCode());
            Console.WriteLine();
        }
    }
}
