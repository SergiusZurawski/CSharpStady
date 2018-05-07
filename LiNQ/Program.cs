using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiNQExample
{
    /*
     1.  LINQ to refer to data consistently within the query expression.   - which are streamed wherever possible.
     2. Creating a query doesn’t usually execute it; most operations use deferred execution.
     3. Query expressions in C# 3 involve a preprocessing phase that converts the expression into normal C#, which is then compiled properly with all the normal rules of type inference, overloading, lambda expressions, and so forth.
     4. The variables declared in query expressions don’t act like anything else; they’re range variables that allow you to refer to data consistently within the query expression.
     
    */
    class Program
    {
        static void Main(string[] args)
        {
            BrakeDownQuery.Example1();
            Console.WriteLine("------------");
            RangeVariables.Example2();

            Console.WriteLine("------------");
            RangeVariables.Example3();
        }

       
    }
}
