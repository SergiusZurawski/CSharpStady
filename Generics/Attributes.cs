using System;

using System.Collections.Generic;  

//Attributes can be applied to generic types in the same way as non-generic types. 
//Custom attributes are only permitted to reference open generic types, 
//and closed constructed generic types, which supply arguments for all type parameters.
namespace GenericsAttributes
{
   class CustomAttribute : System.Attribute
    {
        public System.Object info;
    }

    public class GenericClass1<T> { }

    [CustomAttribute(info = typeof(GenericClass1<>))]
    class ClassA { }

    //Specify multiple type parameters using the appropriate number of commas. 

    public class GenericClass2<T, U> { }

    [CustomAttribute(info = typeof(GenericClass2<,>))]
    class ClassB { }

    //An attribute can reference a closed constructed generic type:
    public class GenericClass3<T, U, V> { }

    [CustomAttribute(info = typeof(GenericClass3<int, double, string>))]
    class ClassC { }

    //An attribute that references a generic type parameter will cause a compile-time error:
    //[CustomAttribute(info = typeof(GenericClass3<int, T, string>))]  //Error
    class ClassD<T> { }
}
