using System;
using DataModel;
using System.Linq;
using WhereImplementation;

namespace LiNQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BrakeDownQuery.Example1();
            Example1();

            TranslationExample.Example();
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
