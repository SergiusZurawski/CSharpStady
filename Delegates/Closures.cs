using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
    /*
     1. Outer variable is a local variable or parameter (excluding ref and out parameters) whose scope includes an anonymous method. 
        The this reference also counts as an outer variable of any anonymous method within an instance member of a class.
    
    2. A captured outer variable (usually shortened to captured variable ) is an outer variable that’s used within an anonymous method.
        To go back to closures, the function part is the anonymous method, and the environment it can interact with is the set of variables captured by it.

        captured variables eliminate the need to write extra classes just to store the information
            a delegate needs to act on, beyond what it’s passed via parameters.
        
    
    */
    public class Closures
    {
        public static void Example()
        {
            int outerVariable = 5;
            // When a variable is captured, refference is captured not a value of a variable
            string capturedVariable = "captured";
            if (DateTime.Now.Hour == 23)
            {
                int normalLocalCariable = DateTime.Now.Minute;
                Console.WriteLine(normalLocalCariable);
            }
            Action x = delegate ()
            {
                string anonLocal = "local to anonymous method";
                Console.WriteLine(capturedVariable + anonLocal);
            };
        }

        public static void ExampleOfBehavoiurOfCapturedVariable()
        {
            string captured = "before x is created";
            Action x = delegate
            {
                Console.WriteLine(captured);
                captured = "changed by x";
            };
            captured = "directly before x is invoked";
            x();
            Console.WriteLine(captured);
            captured = "before second invocation";
            x();

            /*
             directly before x is invoked 
             changed by x 
             before second invocation
             */
        }

        public class Person { public int Age; }
        public static void ExampleOfUse()
        {

        }
        static List<Person> FindAllYoungerThan(List<Person> people, int limit)
        {
            //without closures we would have to pass limit in a delegate args
            return people.FindAll(delegate (Person person) { return person.Age < limit; });
        }

        //A captured variable lives for at least as long as any delegate instance referring to it.

        static Action CreateDelegateInstance()
        {
            int counter = 5;
            Action a = delegate
            {
                Console.WriteLine(counter);
                counter++;
            };
            a();
            return a;
        }

        public static void ExampleOfExtendedLifeTime()
        {
            /*That instance isn’t eligible for garbage collection until the delegate is ready to be collected.
             
                The compiler has actually created an extra class to hold the variable. The CreateDelegateInstance method has a reference to an
                instance of that class so it can use counter , and the delegate has a reference to the same instance, which lives on the heap in the normal way.
             
             */

            Action x = CreateDelegateInstance();
            x();
            x();
        }

        // Local variable instantiations
        public static void ExampleOfDifferenceForLocalVariableInstallation()
        {
            // Example 1
            int single;
            for (int i = 0; i < 10; i++)
            {
                single = 5;
                Console.WriteLine(single + i);
            }

            // Example 2
            for (int i = 0; i < 10; i++)
            {
                int multiple = 5;
                Console.WriteLine(multiple + i);
            }

            /* Code will be optiomazied by a compiler and only one variable will be created but not for Delegates. 
                   Delegates will actually create this variables.
                   When a variable is captured, it’s the relevant “instance” of the variable that’s captured. 
                   If you captured multiple inside the loop, 
                   the variable captured in the first iteration would be different from the variable captured the second time round, 
                   and so on.
            */
        }
        public static void ExampleOfDifferenceForLocalVariableInstallation()
        {
        }
    }
}   

