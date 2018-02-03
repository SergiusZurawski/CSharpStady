using System;
using System.IO;
using System.Threading;

namespace ImplicitTyping
{
    class Program
    {
        static void Main(string[] args)
        {
            //It is not dynamic, the type  is inferred
            var stringVarable = "Hello, world";
            //stringVarable = 0; //Type  error. 
            //var starer = delegate () { Console.WriteLine("1"); };   // 4 point
            //The following is valid
            var starter = (ThreadStart)delegate () { Console.WriteLine("")};
            var cArgs = Environment.GetCommandLineArgs();

            // Can be use in for and using statments
            for (var i = 0; i < 10; i++) { }
            using (var x = File.OpenText("test.dat")) { }
            foreach (var s in Environment.GetCommandLineArgs()) { }


            /**
                Restriction on implicit typing
                1. Local varibale only! Not Static or instance
                2. The variable is initialized as part of the declaration.
                3. The initialization expression isn’t a method group or anonymous function [ 3 ] (without casting).
                    anonymous function covers both anonymous methods and lambda expressions,
                4. The initialization expression isn’t null.
                5. Only one variable is declared in the statement. 
                6. The type you want the variable to have is the compile-time type of the initialization expression. 
                7. The initialization expression doesn’t involve the variable being declared. [ 4 ]
             */
        }
    }
}
