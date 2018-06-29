using System;

namespace ExceptionHandling
{
    class Program
    {

        /*
            You shouldn’t throw exceptions when dealing with expected situations.
            
            Exception handling changes the normal expected flow of your program. 
            This makes it harder to read and maintain code that uses exceptions, 
            especially when they are used in normal situations. 

            Using exceptions also incurs a slight performance hit. 
            Because the runtime has to search all outer catch blocks until it finds a matching block,
            and when it doesn’t, has to look if a debugger is attached, it takes slightly more time to handle. 
            When a real unexpected situation occurs that will terminate the application, this won’t be a problem. 
            But for regular program flow, it should be avoided. 
            Instead you should have proper validation and not rely solely on exceptions. 

            ■ In the .NET Framework, you should use exceptions to report errors instead of error codes. 
            ■■ Exceptions are objects that contain data about the reason for the exception. 
            ■■ You can use a try block with one or more catch blocks to handle different types of exceptions. 
            ■■ You can use a finally block to specify code that should always run after, whether or not an exception occurred. 
            ■■ You can use the throw keyword to raise an exception. 
            ■■ You can define your own custom exceptions when you are sure that users of your code will handle it in a different way. 
            Otherwise, you should use the standard .NET Framework exceptions. 
             
        */
        static void Main(string[] args)
        {

            //ExceptionFinalize a = new ExceptionFinalize();
            ExceptionFinalize.Example();        
                
        }


        /*
         When you need to throw an exception of your own, 
         it’s important to know which exceptions are already defined in the .NET Framework. 
         Because developers will be familiar with these exceptions, they should be used whenever possible. 
        */

        ///Some exceptions are thrown only by the runtime. You shouldn’t use those exceptions from your own code
        ///ArithmeticException             A base class for other exceptions that occur during arithmetic operations.
        ///ArrayTypeMismatchException      Thrown when you want to store an incompatible element inside an array.
        ///DivideByZeroException           Thrown when you try to divide a value by zero.
        ///IndexOutOfRangeException        Thrown when you try to access an array with an index that’s less than zero or greater than the size of the array.
        ///InvalidCastException            Thrown when you try to cast an element to an incompatible type.
        ///NullReferenceException          Thrown when you try to reference an element that’s null.
        ///OutOfMemoryException            Thrown when creating a new object fails because the CLR doesn’t have enough memory available.
        ///OverflowException               Thrown when an arithmetic operation overflows in a checked context.
        ///StackOverflowException          Thrown when the execution stack is full. This can happen in a recursive operation that doesn’t exit.
        ///TypeInitializationException     Thrown when a static constructor throws an exception that’s goes unhandled.
        ///


        ///Popular exceptions in the .NET Framework
        ///  Exception                   The base class for all exceptions. Try avoiding throwing and catching this exception because it’s too generic.
        ///  ArgumentException           Throw this exception when an argument to your method is invalid.
        ///  ArgumentNullException       A specialized form of ArgumentException that you can throw when one of your arguments is null and this isn’t allowed.
        ///  ArgumentOutOfRangeException A specialized form of ArgumentException that you can throw when an argument is outside the allowable range of values.
        ///  FormatException             Throw this exception when an argument does not have a valid format.
        ///  InvalidOperationException   Throw this exception when a method is called that’s invalid for the object’s current state.
        ///  NotImplementedException     This exception is often used in generated code where a method has not been implemented yet.
        ///  NotSupportedException       Throw this exception when a method is invoked that you don’t support.
ObjectDisposedException Throw when a user of your class tries to access methods when Dispose has already been called


    }
}
