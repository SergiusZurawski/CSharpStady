using System;

namespace Types
{

    /// There are two main types
    /// 1. Value type - store on stack
    /// 2. Refference type - stored in heap
    ///  
    /// Although a value type is normally stored on the stack, 
    /// there are exceptions (for example, a class that contains a value type as one of its fields, 
    /// a lambda expression that closes over a value type, or a value type that is boxed),
    /// 
    /// The benefit of storing data on the stack is that 
    ///           it’s faster, 
    ///           smaller, 
    ///           and doesn’t need the attention of the garbage collector.
    ///           
    /// following three criteria to determine whether you want to create a value type: 
    /// ■■ The object is small. 
    /// ■■ The object is logically immutable. 
    /// ■■ There are a lot of objects. 
    /// 

    /// All objects in C# inherit from System.Object. 
    ///  Value types, however, inherit from System. ValueType (which inherits from System.Object). 
    ///  System.ValueType overrides some of the default functions (such as GetHashCode, Equals, and ToString)
    ///  to give them a more meaningful implementation for a value type.
    ///  

    /// In C#, you cannot directly inherit from System.ValueType. 
    /// Instead, you can use the struct keyword to create a new value type. 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
