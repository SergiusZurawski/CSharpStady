using System;

namespace ExceptionHandling
{
    class ExceptionExamples
    {
        /*
            Throwing an exception halts the execution of your application. 
            Instead of continuing to the following line, 
            the runtime starts searching for a location in which you handle the exception. 
            If such a location cannot be found, the exception is unhandled and will terminate the application. 
            
             all exceptions in the .NET Framework inherit from System.Exception, 
             you can catch every possible exception by catching this base type.


            The catch blocks should be specified as most-specific to least-specific 
            because this is the order in which the runtime will examine them. 
            When an exception is thrown, the first matching catch block will be executed.
            If no matching catch block can be found, the exception will fall through

            In C# 1, you could also use a catch block without an exception type. 
            This could be used to catch exceptions that were thrown from other languages like C++ that don’t inherit from System.Exception 
            (in C++ you can throw exceptions of any type). Nowadays, each exception that doesn’t inherit from System.Exception 
            is automatically wrapped in a System.Runtime. CompilerServices.RuntimeWrappedException. Since this exception inherits from System. 
            Exception, there is no need for the empty catch block anymore. 

             finally block together with a try or try/catch statement -makes certain code to run all the time


        */
        static void Example()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s))
                    break;
                try
                {
                    int i = int.Parse(s);
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Youneedtoenteravalue");
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}is not avalid number. Pleasetryagain", s);
                }
                finally
                {
                    Console.WriteLine("Programcomplete.");
                }
                // Displays 
                // a 
                // a is not a valid number. Please try again 
                // Program complete.
            }
        }
    }
}
