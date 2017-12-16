

using System;

using System.Collections.Generic;  

//A generic method is a method that is declared with type parameters, as follows
namespace Generics
{
    public class GenericMethodsCollection
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void TestSwap()
        {
            int a = 1;
            int b = 2;

            Swap<int>(ref a, ref b);
            System.Console.WriteLine(a + " " + b);

            //You can also omit the type argument and the compiler will infer it. The following call to Swap is equivalent to the previous call
            Swap(ref a, ref b);
            
            //The same rules for type inference apply to static methods and instance methods.
            // The compiler can infer the type parameters based on the method arguments you pass in
            // it cannot infer the type parameters only from a constraint or return value. 
            // Therefore type inference does not work with methods that have no parameter

            

            //Use constraints to enable more specialized operations 
            void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
            {
                T temp;
                if (lhs.CompareTo(rhs) > 0)
                {
                    temp = lhs;
                    lhs = rhs;
                    rhs = temp;
                }
            }
            //Generic methods can be overloaded on several type parameters. For example, the following methods can all be located in the same class
            void DoWork() { }
            void DoWork<T>() { }
            void DoWork<T, U>() { }
        }

        //Within a generic class, non-generic methods can access the class-level type parameters
        class SampleClass<T>
        {
            void Swap(ref T lhs, ref T rhs) { }
        }

        /*
            If you define a generic method that takes the same type parameters as the containing class, 
            the compiler generates warning CS0693 because within the method scope, 
            the argument supplied for the inner T hides the argument supplied for the outer T
            */

        class GenericList<T>
        {
            // CS0693
            void SampleMethod<T>() { }
        }

        class GenericList2<T>
        {
            //No warning
            void SampleMethod<U>() { }
        }
    }
}
