using System;

namespace Events
{
    /*
        delegates form the basic building blocks for events. A delegate is a type that defines a method signature.
         In C++, for example, you would do this with a function pointer. 
     */
    class EventsExamples
    {
        //. Delegates can be nested in other types and they can then be used as a nested type.
        //  An instantiated delegate is an object; you can pass it around and give it as an argument to other methods. 
        public delegate int Calculate(int x, int y); 
        public int Add(int x, int y) { return x + y; } 
        public int Multiply(int x, int y) { return x * y; } 
        public static void Example1()
        {
            //I need instance becasue calling non static method from static method Example
            var a = new EventsExamples();
            Calculate calc = a.Add;     
            Console.WriteLine(calc(3, 4)); // Displays 7 
            calc = a.Multiply;     
            Console.WriteLine(calc(3, 4)); // Displays 12 
        }
    }
}
