using System;

namespace Nullable
{
    class Boxing
    {
        public static void CallExample()
        {
            Nullable<int> nullable = 5;
            object boxed = nullable;
            Console.WriteLine(boxed.GetType());
            int normal = (int)boxed;
            Console.WriteLine(normal);
            nullable = (Nullable<int>)boxed;
            Console.WriteLine(nullable);
            nullable = new Nullable<int>();
            boxed = nullable;
            Console.WriteLine(boxed == null);
            nullable = (Nullable<int>)boxed;
            Console.WriteLine(nullable.HasValue);
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
    }
    


}
