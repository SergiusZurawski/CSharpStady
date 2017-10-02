using System;

using System.Collections.Generic;  

namespace DefaultValues
{
    /*
    When a type parameter is unconstrained (no constraints are applied to it), 
    you can use the == and != operators, but only to compare a value of that type with null ; 
    you can’t compare two values of type T with each other.

        When the type argument is a reference type, the normal reference comparison will be used. 
        In the case where the type argument provided for T is a non-nullable value type, a comparison with null will
    always decide that they’re unequal (so the comparison can be removed by the JIT compiler)

    When a type parameter is constrained to be a value type, == and != can’t be used
    with it at all. When it’s constrained to be a reference type, the kind of comparison
    performed depends on how the type parameter is constrained.
    (If the only constraint is that it’s a reference type, simple reference comparisons are performed.)
    */
   public class Program
    {
        public static void Example()
        {
            Console.WriteLine(CompareToDefault("x"));
            Console.WriteLine(CompareToDefault(10));
            Console.WriteLine(CompareToDefault(0));
            Console.WriteLine(CompareToDefault(-10));
            Console.WriteLine(CompareToDefault(DateTime.MinValue));

            /**
                1
                1
                0
                -1
                0            
             */
        
        }
        
        public static int CompareToDefault<T> (T a) where T: IComparable<T>
        {	
            return a.CompareTo(default(T));
        }
    }
}
