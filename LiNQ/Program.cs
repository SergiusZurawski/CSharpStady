
﻿using System;
using DataModel;
using System.Linq;
using WhereImplementation;
﻿using DataModel;
using System.Collections.Generic;


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
            //BrakeDownQuery.Example1();
            //Example1();

            //TranslationExample.Example();
            //Console.WriteLine("------------");
            //RangeVariables.Example2();

            //Console.WriteLine("------------");
            //RangeVariables.Example3();

            //Console.WriteLine("------------");
            //FilteringAndOrdering.Example3();

            //Console.WriteLine("------------");
            //FilteringAndOrdering.Example4();

            //Console.WriteLine("------------");
            //Joins.Example();

            Console.WriteLine("------------");
            JoinsGroupping.Example2();
        }

        static void Example1()
        {
            // Every query expression starts off with the source of a sequence of data:
            // from element in source
            // Projection - select clause - 
            // select expression
            var query = from user in SampleData.AllUsers select user;

            foreach (var user in query) { Console.WriteLine(user); }
        }

       
    }
}
