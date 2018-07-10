using System;
using System.Diagnostics;
using System.Reflection;

namespace Reflections
{
    /*
      Reflection is slower than normally executing static code
    */

    /// application doesn’t just contain code and data; it also contains metadata
    ///      An attribute is one type of metadata that can be stored in a .NET application
    ///      Other types of metadata contain information about the types, 
    ///      code, assembly, and all other elements stored in your application
    ///      Reflection is the process of retrieving this metadata at runtime.
    ///  Attributes can be added to all kinds of types: assemblies, types, methods, parameters, and properties. 

    class Program
    {
        static void Main(string[] args)
        {
            Example();
        }

        public static void Example()
        {
            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute))) 
            { 

            }

            //ConditionalAttribute conditionalAttribute =  
            //   (ConditionalAttribute)Attribute.GetCustomAttribute(typeof(Person), typeof(ConditionalAttribute));
            Person p = new Person();
            MethodInfo methodInfo2 = p.GetType().GetMethod("MyMethod");
            //MethodBase method = MethodBase.GetMethodFromHandle();
            ConditionalAttribute attr = (ConditionalAttribute)methodInfo2.GetCustomAttributes(typeof(ConditionalAttribute), true)[0];
            Console.WriteLine("==============================");
            Console.WriteLine(attr);
            Console.WriteLine("==============================");
            //IVESTIGATE
            //string condition = conditionalAttribute.ConditionString; // returns CONDITION1
            //Console.WriteLine(condition);

        }
    }

    /*
        Actual class in the .NET Framework is called SerializableAttribute. 
        By convention, the name is suffixed with Attribute
        When using the attribute - you can skip the Attribute suffix. 
    */

    [Serializable] 
    class Person {     
        public string FirstName { get; set; }     
        public string LastName { get; set; } 
        /*
        A type can have as many attributes applied to it as necessary. 
        Some attributes can even be applied multiple times
        */
        [Conditional("true"), Conditional("false")] 
        public static void MyMethod(){ }
        /*
            1. Attribute can have parameters(those parameters can be named an optional)
            2. An attribute also has a specific target to which it applies. 
            can be an attribute applied to a whole assembly, a class, a specific method, or even a parameter of a method
            [assembly: AssemblyTitle(“ClassLibrary1”)] 
            3. System.Attribute class is parent for all attributes
         */
    }

    
}
