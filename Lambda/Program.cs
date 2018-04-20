using System;
/// lambda expressions almost entirely replace anonymous methods.
/// Anonymous methods are supported for the sake of backward compatibility,
/// compact syntax for delegate creation.
/// can be converted into expression trees,
/// The expression trees can then be processed by other code, possibly performing equivalent actions in different execution environments. Without this ability, LINQ would be restricted to in-process queries.
namespace Lambda
{
    class Lambda
    {
        //Lambda expressions(LE) can do almost everything that anonymous methods
        // In the most explicit form, not much difference exists between the two,
        // but LE have a lot of shortcuts available that make them compact in common situations.
        // - behavior of captured variables is exactly the same
        // 
        // LE have special conversion rules — the type of the expression isn’t a delegate type in itself,
        // but it can be converted into a delegate instance (implicitly and explicitly)
        // The one feature available to anonymous methods but not lambda expressions is the ability to concisely ignore parameters.
        // (section 5.4.3 )

        /*
          Function Delegates - Return Result:
           TResult Func<TResult>() 
           TResult Func<T,TResult>(T arg) 
           TResult Func<T1,T2,TResult>(T1 arg1, T2 arg2) 
           TResult Func<T1,T2,T3,TResult>(T1 arg1, T2 arg2, T3 arg3) 
           TResult Func<T1,T2,T3,T4,TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)

          Action Delegates - Return "Void":
          .Net 4 extends both delegate types to accept up to 16 arguments.

        */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void ImplementingFunctionDelegateWithAnonymousMethod()
        {
            Func<string, int> returnLength;
            returnLength = delegate (string text) 
            {
                return text.Length;
            };
            Console.WriteLine(returnLength("Hello"));
        }
        // long-winded form of a lambda expression
        // ( explicitly-typed-parameter-list ) => { statements }
        static void ImplementingFunctionDelegateWithLambdaV1()
        {
            Func<string, int> returnLength;
            // Explicit type of parameters, but can be implicit. The cannot be mixed either everithing explicit ot implicit
            //  if any of the parameters are "out" or "ref" parameters, you’re forced to use explicit typing.
            returnLength = (string text) => { return text.Length; };    // - Explicit
            returnLength = (text) => text.Length;                       // - implicit
            returnLength = text => text.Length;                         // - Shortcut for a single parameter
            returnLength = (text => text.Length);                       // - Wrapping into parentheses(Improves readability when assigning)
            Console.WriteLine(returnLength("Hello"));

            /* 9.1.5. Shortcut for a single parameter
                When LE only needs a single parameter, C#3 allows ommitin parentheses
                parameter-name => expression
                text => text.Length
             */
        }
        // higher-order functions:
        //  1. lambda expression can contain a lambda expression,
        //  2. the parameter to a lambda expression can be another delegate,
    }
}
