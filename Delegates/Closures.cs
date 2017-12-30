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
        

        Main points:
        1. The variable is captured—not its value at the point of delegate instance creation. 
        2. Captured variables have lifetimes extended to at least that of the capturing delegate. 
        3. Multiple delegates can capture the same variable... 
        4. ...but within loops, the same variable declaration can effectively refer to different variable “instances.” 
        5. for loop declarations create variables that live for the duration of the loop—they’re not instantiated on each iteration. The same is true for foreach statements before C# 5. 
        6. Extra types are created, where necessary, to hold captured variables. 
        7. Be careful! Simple is almost always better than clever.
    
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
        public static void ExampleOfLocalVariableInitializedInLoop()
        {
            List<Action> list = new List<Action>();
            for (int index = 0; index < 5; index++)
            {
                int counter = index * 10;
                list.Add(delegate() 
                {
                    Console.WriteLine(counter);
                    counter++;
                });
            }
            foreach (Action t in list)
            {
                t();
            }
            list[0]();
            list[0]();
            list[0]();
            list[1]();
        }

        public static void ExampleOfClosureVariableOfMixedUsed()
        {
            Action[] delegates = new Action[2];
            int outside = 0;
            for (int i = 0; i< 2; i++)
            {
                int inside = 0;
                delegates[i] = delegate
                {
                    Console.WriteLine("");
                    outside++;
                    inside++;
                };
            }

            Action first = delegates[0];
            Action second = delegates[1];

            first();
            first();
            first();

            second();
            second();
        }
    }
}   

