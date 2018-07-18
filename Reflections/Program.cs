using System;

namespace Reflections
{
    /// Application doesn’t just contain code and data; it also contains metadata, which is information about data
    ///   An attribute is one type of metadata that can be stored in a.NET application.
    /// Reflection is the process of retrieving this metadata at runtime

    ///     Attributes can be added to all kinds of types: assemblies, types, methods, parameters, and properties
    ///     attribute can have parameters ( Just as with regular types, those parameters can be named an optional. )
    ///     An attribute also has a specific target to which it applies. It can be an attribute applied to a
    ///         whole assembly, a class, a specific method, or even a parameter of a method.
    ///      System.Attribute - all other attributes inherit
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    // the actual class in the .NET Framework is called SerializableAttribute
    // By convention, the name is suffixed with Attribute so you can easily distinguish between attributes
    // You can skip the Attribute suffix When using the attribute 
    [Serializable]
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

