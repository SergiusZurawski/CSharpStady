using System;
using System.Collections.Generic;

    //When a generic type/method is compiled into(IL), it contains metadata that identifies it as having type parameters. 
    //When a generic type is first constructed with a value type as a parameter, 
    // the runtime creates a specialized generic type with the supplied parameter/parameters 
    // substituted in the appropriate locations in the IL. 
    // Specialized generic types are created one time for each unique value type that is used as a parameter

namespace Generics
{
   public class GenericAtRuntime
   {
       Stack<int> stack;
       // Value types
       //At this point, the runtime generates a specialized version of the Stack<T> class 
       // that has the integer substituted appropriately for its parameter. 


       //two instances of a stack of integers are created, and they share a single instance of the Stack<int> code:
        Stack<int> stackOne = new Stack<int>();
        Stack<int> stackTwo = new Stack<int>();
        //However, suppose that another Stack<T> class with a different value type such as a long 
        // or a user-defined structure as its parameter is created at another point in your code.

        //runtime generates another version of the generic type and substitutes a long in the appropriate locations in IL
        //Conversions are no longer necessary because each specialized generic class natively contains the value type.

        //Then, every time that a constructed type is instantiated with a reference type as its parameter, 
        // regardless of what type it is, the runtime reuses the previously created specialized version of the generic type. 
        // This is possible because all references are the same size.
        //
    }
    //Generics work differently for reference types.
        //  The first time a generic type is constructed with any reference type, 
        //  the runtime creates a specialized generic type with object references substituted for the parameters in the IL. 
        //  Then, every time that a constructed type is instantiated with a reference type as its parameter, 
        //  regardless of what type it is, the runtime reuses the previously created specialized version of the generic type. 
        //  This is possible because all references are the same size.
    class Customer { }
    class Order { }

    public class GenericAtRuntimeReffType
    {
        Stack<Customer> customers;
        //At this point, the runtime generates a specialized version of the Stack<T> class that stores object references that will be filled in later instead of storing data. 
        Stack<Order> orders = new Stack<Order>();
        //Unlike with value types, another specialized version of the Stack<T> class is not created for the Order type.
        // Instead, an instance of the specialized version of the Stack<T> class is created and the orders variable is set to reference it


    }


    

}
