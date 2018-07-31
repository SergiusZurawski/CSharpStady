#define MySymbol
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BuildingConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DebugDirective();
            Console.ReadKey();
        }

        public static void DebugDirective()
        {
#if DEBUG
            Console.WriteLine("Debug mode");
#else
            Console.WriteLine("Not debug");
#endif
        }



        // … 

        public void UseCustomSymbol()
        {
#if MySymbol
            Console.WriteLine("Custom symbol is defined");
#endif
        }

        //Solve problem of multiple platoforms
        public Assembly LoadAssembly<T>()
        {
#if !WINRT
            Assembly assembly = typeof(T).Assembly;     
#else         
            Assembly assembly = typeof(T).GetTypeInfo().Assembly;     
            #endif 

            return assembly;
        }

        public static void DisablingWaring()
        {
#pragma warning disable
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
#pragma warning restore
            //Disabling a specific warning
#pragma warning disable 0162, 0168
            int i;
#pragma warning restore 0162
            while (false)
            {
                Console.WriteLine("Unreachable code");
            }
#pragma warning restore
        }

        [Conditional("DEBUG")]
        private static void Log(string message)
        {
            Console.WriteLine("message");
        }

        [DebuggerDisplay("Name = {FirstName} {LastName")]
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }

#warning This code is obsolete  
#line 200 "OtherFileName"
}
