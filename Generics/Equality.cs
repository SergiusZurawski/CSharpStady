using System;

using System.Collections.Generic;  

// You can compare if you apply constrains:  IComparable<T> or IEquatable<T>
// That gives you  Equals(object) method (Equals(T)).

// When a type parameter is unconstrained (no constraints are applied to it), 
//      you can use the == and != operators, but only to compare a value of that type with null.
//      you can’t compare two values of type T with each other.
// When the type argument is a reference type, the normal reference comparison will be used.
// In the case where the type argument provided for T is a non-nullable value type, 
//      a comparison with null will always decide that they’re unequal
//
// When the type argument is a nullable value type, the comparison will
//      behave in the natural way, making the comparison against the null value of the type.4

// When a type parameter is constrained to be a value type, 
//      == and != can’t be used with it at all.

// When it’s constrained to be a reference type, the kind of comparison
//      performed depends on how the type parameter is constrained

// If the only constraint is that it’s a reference type, simple reference comparisons are performed.
// If it’s further constrained to derive from a particular type that overloads the == and != operators, those overloads are used.

//  Beware, though—extra overloads that happen to be made available by the type argument specified by the caller are not used.

namespace Equality
{
    public class ComparisonsOverridden {
        public static bool AreReferencesEqual<T>(T first, T second) where T : class
        {
            return first == second;
        }

        public static void Example(){
            string name = "Jon";
            string intro1 = "My name is " + name;
            string intro2 = "My name is " + name;
            Console.WriteLine(intro1 == intro2);                    // True  //Comparisons using == and != performing reference comparisons
            Console.WriteLine(AreReferencesEqual(intro1, intro2));  // False // this overload isn’t used by the comparison. 
            //the compiler doesn’t know what overloads will be available—it’s as if the parameters passed in were of type object.
            
            //This isn’t specific to operators
            //compiler resolves all the method overloads when compiling the unbound generic type, rather
            // than reconsidering each possible method call for more specific overloads at execution time.
            //For instance, a statement of Console.WriteLine(default(T));
        }
    }
}

//THE GENERIC COMPARISON INTERFACES 
// 4 main interfaces
// the following 2 are implemented by types that are capable of comparing two different values,
// IComparer<T>
// IEqualityComparer<T>
//  
// the following 2  are capable of comparing itself with another value
// 
// IComparable<T> or IEquatable<T>

