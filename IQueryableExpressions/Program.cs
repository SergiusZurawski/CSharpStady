using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IQueryableExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example1();
            Example2();
        }


        static void Example1()
        {
            var query = from x in new FakeQuery<string>()
                        where x.StartsWith("abc") select x.Length;
            foreach (int i in query) { }

        }

        static void Example2()
        {
            var query = from x in new FakeQuery<string>()
                        where x.StartsWith("abc")
                        select x.Length;
            foreach (int i in query) { }
            double mean = query.Average();

        }
    }
}
