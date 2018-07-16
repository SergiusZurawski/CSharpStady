using System;

namespace ManipulateStrings
{
    class Program
    {
        // The string object contains an array of Char objects internally.
        // String is a reference type that looks like value type 
        //  (for example, the equality operators == and != are overloaded to compare on value, not on reference). 
        // "string" keyword is just an alias for the .NET Framework’s String. 
        //  One of the special characteristics of a string is that it is immutable, so it cannot be changed after it has been created.
        //       Every change to a string will create a new string. 
        //       This is why all of the String manipulation methods return a string. 
        //  Immutability:
        //     proc     
        //       It cannot be modified so it is inherently thread-safe.
        //       It is more secure because no one can mess with it.
        //       Suddenly something like creating undo-redo is much easier, your data structure is immutable and you maintain only snapshots of your state. 
        //     cons
        //       it will create a new string every tyme(for each iteration in your loop etc).
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
