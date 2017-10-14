using System;

using System.Collections.Generic;
using System.Reflection;  

//Attributes can be applied to generic types in the same way as non-generic types. 
//Custom attributes are only permitted to reference open generic types, 
//and closed constructed generic types, which supply arguments for all type parameters.
namespace ReflectionsForGenerics
{
    class GenericReflectionExample
    {

        static void DemonstrateTypeof<X>()
        {
            Console.WriteLine(typeof(X));                       //Displays method’s type parameter
            Console.WriteLine(typeof(List<>));                  //Displays generic types
            Console.WriteLine(typeof(Dictionary<,>));
            Console.WriteLine(typeof(List<X>));                 //Displays closed types (despite using type parameter)
            Console.WriteLine(typeof(Dictionary<string,X>));    //  
            Console.WriteLine(typeof(List<long>));              //Displays closed types
            Console.WriteLine(typeof(Dictionary<long,Guid>));
            // Output
            /*
            System.Int32
            System.Collections.Generic.List`1[T]
            System.Collections.Generic.Dictionary`2[TKey,TValue]
            System.Collections.Generic.List`1[System.Int32]
            System.Collections.Generic.Dictionary`2[System.String,System.Int32]
            System.Collections.Generic.List`1[System.Int64]
            System.Collections.Generic.Dictionary`2[System.Int64,System.Guid]
             */
        }

        public static void Example(){
            DemonstrateTypeof<int>();
        }


        /*
            Just like normal types, there’s only one Type object for any particular type—so call-
            ing MakeGenericType twice with the same types as arguments will return the same ref-
            erence twice.

            Calling GetGenericTypeDefinition on two types constructed
            from the same generic type definition will give the same result for both calls, even if
            the constructed types are different (such as List<int> and List<string> ).
         */

        public static void RetrivingTypeObject()
        {
            string listTypeName = "System.Collections.Generic.List`1";

            Type defByName = Type.GetType(listTypeName);

            Type closedByName = Type.GetType(listTypeName + "[System.String]");
            Type closedByMethod = defByName.MakeGenericType(typeof(string));
            Type closedByTypeof = typeof(List<string>);

            Console.WriteLine(closedByMethod == closedByName);  // True
            Console.WriteLine(closedByName == closedByTypeof);  // True

            Type defByTypeof = typeof(List<>);
            Type defByMethod = closedByName.GetGenericTypeDefinition();

            Console.WriteLine(defByMethod == defByName);        //True
            Console.WriteLine(defByName == defByTypeof);        //True
        }

        

        public static void RetrivingMethodFromAType()
        {
            Type type = typeof(Snippet);
            MethodInfo definition = type.GetMethod("PrintTypeParameter");
            MethodInfo constructed = definition.MakeGenericMethod(typeof(string));
            constructed.Invoke(null, null);
        }

        public static void Unsorted()
        {
            //Two Generic Types
            Type def2 = Type.GetType("A`2");
            Type t5 = def2.MakeGenericType(typeof(string), Type.GetType("System.Int32"));
            Console.WriteLine(t5);
            //Call non static methos with argumetns
            MethodInfo definition = t5.GetMethod("PrintType");
            A<string, int> b = new A<string, int>();
            definition.Invoke(b, new Object[]{"hello"});
		
        }
        
    }

    class Snippet
    {
        public static void PrintTypeParameter<T>()
        {
            Console.WriteLine(typeof(T));
        }
    }
    class A<T,B>
    {
        public void PrintType(T t)
        {
            Console.WriteLine(t);
        }
    }

}
