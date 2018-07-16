using System;
using System.Diagnostics;
using System.Reflection;

namespace Reflections
{
    /*
      Reflection is slower than normally executing static code
    */

    /// application doesn’t just contain code and data; it also contains metadata
    /// Reflection is the process of retrieving this metadata at runtime.
    /// Use reflection to create type instances at run time, and to invoke and access them.
    ///     Assemblies contain modules
    ///     Modules contain types
    ///     Types contain members
    ///     
    ///      An attribute is one type of metadata that can be stored in a .NET application
    ///      Other types of metadata contain information about the types, 
    ///      code, assembly, and all other elements stored in your application
    ///      
    ///  Attributes can be added to all kinds of types: assemblies, types, methods, parameters, and properties. 

    class Program
    {
        static void Main(string[] args)
        {
            ExampleGetAttribute();
        }

        public static void ExampleHowToGetType()
        {
            //Reflection provides objects (of type Type) that describe 
            //                                                assemblies, 
            //                                                modules,
            //                                                types.
            //GetType 
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);
            //typeof
            Type type2 = typeof(int);
            //Type type2 = typeof(i); //Compile error. You cannot call it on variable
        }

        public static void ExampleTypeMethods()
        {
           // Some methods of Type 
           int i = 42;
           Type type = i.GetType();
           Console.WriteLine(type);
           Console.WriteLine(type.Assembly);
           Console.WriteLine(type.Attributes);
           Console.WriteLine(type.FullName);
        }
        /*
            The C# keywords in IL and reflection
            protected - Family 
            internal - Assembly
            protected internal - IsFamilyOrAssembly.
        */

        public static void ExampleCallMethod()
        {
            int i = 42;
            MethodInfo compareToMethod = 
                    i.GetType().GetMethod("CompareTo", new Type[] { typeof(int) });
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
        }

        public static void ExampleGetAttribute()
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

    /*
     Use Assembly to define and load assemblies, 
            load modules that are listed in the assembly manifest, 
            and locate a type from this assembly and create an instance of it.

     Use Module to discover information such as the assembly that contains 
            the module and the classes in the module. 
            You can also get all global methods or other specific, 
            nonglobal methods defined on the module.

    Use ConstructorInfo to discover information such as the name, 
            parameters, access modifiers (such as public or private), 
            and implementation details (such as abstract or virtual) of a constructor. 
            Use the GetConstructors or GetConstructor method of a 
            Type to invoke a specific constructor.

    Use MethodInfo to discover information such as the name, 
            return type, parameters, access modifiers (such as public or private), 
            and implementation details (such as abstract or virtual) of a method. 
            Use the GetMethods or GetMethod method of a Type to invoke a specific method.

    Use FieldInfo to discover information such as the name, 
            access modifiers (such as public or private) and implementation 
            details (such as static) of a field, and to get or set field values.

    Use EventInfo to discover information such as the name, event-handler data type, 
            custom attributes, declaring type, and reflected type of an event, 
            and to add or remove event handlers.

    Use PropertyInfo to discover information such as the name, data type,
            declaring type, reflected type, 
            and read-only or writable status of a property, 
            and to get or set property values.

    Use ParameterInfo to discover information such as a parameter's name, 
            data type, whether a parameter is an input or output parameter, 
            and the position of the parameter in a method signature.

    Use CustomAttributeData to discover information about custom attributes 
            when you are working in the reflection-only context 
            of an application domain. CustomAttributeData allows
            you to examine attributes without creating instances of them.
     
     */


}
