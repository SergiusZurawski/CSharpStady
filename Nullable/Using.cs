using System;
using System.Reflection;

namespace Nullable
{
    /*
    The type parameter T has a value type constraint, so you can’t use Nullable<Stream> ,
    this also means you can’t use another nullable type as the argument, so Nullable<Nullable<int>> is forbidden, 
    even though Nullable<T> is a value type in every other way.
     */
    class Using
    {
        public static void CallExample()
        {
            Nullable<int> x = 5;
            x = new Nullable<int>(5);
            Console.WriteLine("Instance with value:");
            Display(x);
            x = new Nullable<int>();
            Console.WriteLine("Instance without value:");
            Display(x);
        }

        /* Output
        Instance with value:
        HasValue: True
        Value: 5
        Explicit conversion: 5
        GetValueOrDefault(): 5
        GetValueOrDefault(10): 5
        ToString(): "5"
        GetHashCode(): 5
        Instance without value:
        HasValue: False
        GetValueOrDefault(): 0
        GetValueOrDefault(10): 10
        ToString(): ""
        GetHashCode(): 0
         */

        static void Display(Nullable<int> x)
        {
            //Properties of Nullable
            Console.WriteLine("HasValue: {0}", x.HasValue);
            if (x.HasValue)
            {
                Console.WriteLine("Value: {0}", x.Value);
                Console.WriteLine("Explicit conversion: {0}", (int)x);
            }
            Console.WriteLine("GetValueOrDefault(): {0}",
            x.GetValueOrDefault());
            Console.WriteLine("GetValueOrDefault(10): {0}",
            x.GetValueOrDefault(10));
            Console.WriteLine("ToString(): \"{0}\"", x.ToString());
            Console.WriteLine("GetHashCode(): {0}", x.GetHashCode());
            Console.WriteLine();
        }

        /*Equality
        
             If first has no value and second is null , they’re equal.
             If first has no value and second isn’t null , they aren’t equal.
             If first has a value and second is null , they aren’t equal.
             Otherwise, they’re equal if first ’s value is equal to second .

            Second is another Nullable<T> - boxing prohibit that situation (comparing Nullable<string> Nullable<int>).
            You can use nullable instances as keys for dictionaries and any other situations where you need equality.
         */

        static void Equality()
        {

            Nullable<int> i = 5;
            Nullable<int> y = 5;
            Nullable<int> c = 6;
            Nullable<int> iNull = new Nullable<int>();
            Int32 _int32 = 5;
            Int32 _int32NotEqual = 6;
            object iwrapped = (object)_int32;
            Nullable<char> _char = '5';
            
            Console.WriteLine(i.Equals(y));
            Console.WriteLine(i.Equals(c));
            Console.WriteLine(i.Equals(c));
            Console.WriteLine(i.Equals(iNull));
            Console.WriteLine(i.Equals(_int32));
            Console.WriteLine(i.Equals(_int32NotEqual));
            Console.WriteLine(i.Equals(_int32));
            Console.WriteLine(i.Equals(_char));
             /*
                True
                False
                False
                False
                True
                False
                True
                False
             */
        }
           

        //Static class Nullable
        public static void NullableUssage()
        {
            Nullable<int> i = 5;
            Nullable<int> y = 5;
            Nullable<int> c = 6;
            Nullable<int> iNull = new Nullable<int>();
            Int32 _int32 = 5;
            Int32 _int32NotEqual = 6;
            object iwrapped = (object)_int32;
            Nullable<char> _char = '5';
            int? a = 1;
            int? b = 2;
            int? z = 5;
            
            /* Doesn't present in DotNetCore 2.0.3
            Console.WriteLine(Nullable.Compare<int>(i, y));
            Console.WriteLine(Nullable.Compare<int>(a, b));
            Console.WriteLine(Nullable.Compare<int>(i, z));
            Console.WriteLine(Nullable.Compare<int>(a, _int32));
            Console.WriteLine(Nullable.Compare<int>(_int32, _int32NotEqual));
            Console.WriteLine(Nullable.Compare<int>(a, _char));
            
            
            Console.WriteLine(Nullable.Equals<int>(i, y));
            Console.WriteLine(Nullable.Equals<int>(a, b));
            Console.WriteLine(Nullable.Equals<int>(i, z));
            Console.WriteLine(Nullable.Equals<int>(a, _int32));
            Console.WriteLine(Nullable.Equals<int>(_int32, _int32NotEqual));
            Console.WriteLine(Nullable.Equals<int>(a, _char));
             */
        }

        //Syntatic Sugar
        //The ? modifier is a shorthand of a nullable type, instead of  Nullable<byte> use "byte?"
        public static void Modifier?()
        {
            int? nullable = 5;
            object boxed = nullable;
            Console.WriteLine(boxed.GetType());
            int normal = (int)boxed;
            Console.WriteLine(normal);
            nullable = (int?)boxed;
            Console.WriteLine(nullable);
            nullable = new int?();
            boxed = nullable;
            Console.WriteLine(boxed == null);
            nullable = (int?)boxed;
            Console.WriteLine(nullable.HasValue);
        }

    }

    //Get Underlying type 
    
    public class SampleGetUnderlyingType  
    {
    // Declare a type named Example. 
    // The MyMethod member of Example returns a Nullable of Int32.

        public class Example
        {
            public int? MyMethod() 
            {
            return 0;
            }
        }

    /* 
    Use reflection to obtain a Type object for the Example type.
    Use the Type object to obtain a MethodInfo object for the MyMethod method.
    Use the MethodInfo object to obtain the type of the return value of 
        MyMethod, which is Nullable of Int32.
    Use the GetUnderlyingType method to obtain the type argument of the 
        return value type, which is Int32.
    */   
        public static void CallExample() 
        {
            
            Type t = typeof(Example);
            MethodInfo mi = t.GetMethod("MyMethod");
            Type retval = mi.ReturnType;
            Console.WriteLine("Return value type ... {0}", retval);
            //Does not work in DotNetCore
            //Type answer = Nullable.GetUnderlyingType(retval);
            //Console.WriteLine("Underlying type ..... {0}", answer);
            
            int? i = 1;
            //Does not work in DotNetCore
            //Does print when type is retrived dirrectly
            //Console.WriteLine("Underlying type 2 ..... {0}", Nullable.GetUnderlyingType(i.GetType()));
        }
    }
    
    /*
    This code example produces the following results:

    Return value type ... System.Nullable`1[System.Int32]
    Underlying type ..... System.Int32
    */
}
