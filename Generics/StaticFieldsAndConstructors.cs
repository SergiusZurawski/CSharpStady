using System;

using System.Collections.Generic;  


//static field x in class SomeClass , there’s exactly one Some-Class.x field, 
//no matter how many instances of SomeClass you create, 
//no matter how many types derive from SomeClass

//each closed type has its own set of static fields
// The same applies for static initializers 
// and static constructors.

namespace StaticFieldsAndConstructors
{

    class TypeWithField<T>
    {
        public static string field;
        public static void PrintField()
        {
            Console.WriteLine(field + ": " + typeof(T).Name);
        }
    }

    public static class StaticFieldsExample{
        public static void Example(){
            TypeWithField<int>.field = "First";
            TypeWithField<string>.field = "Second";
            TypeWithField<DateTime>.field = "Third";

            TypeWithField<int>.PrintField();
            TypeWithField<string>.PrintField();
            TypeWithField<DateTime>.PrintField();
        }
        //First: Int32
        //Second: String
        //Third: DateTime
    }

    public class Outer<T>
    {
        public class Inner<U,V>
        {
            static Inner()
            {
                Console.WriteLine("Outer<{0}>.Inner<{1},{2}>",
                                        typeof(T).Name,
                                        typeof(U).Name,
                                        typeof(V).Name);
            }
            public static void DummyMethod() {}
        }
    }

    public static class StaticConstructorAndNestedGenericsExample{
        public static void Example(){
            Outer<int>.Inner<string,DateTime>.DummyMethod();
            Outer<string>.Inner<int,int>.DummyMethod();
            Outer<object>.Inner<string,object>.DummyMethod();
            Outer<string>.Inner<string,object>.DummyMethod();
            Outer<object>.Inner<object,string>.DummyMethod();
            //as nongeneric types, the static constructor for any closed type is only executed once
            Outer<string>.Inner<int,int>.DummyMethod();  //Doesn't get's printed becose this type was already initialized 5 lines above
        }
        //Each different list of type arguments counts as a different closed type
        // Outer<Int32>.Inner<String,DateTime>
        // Outer<String>.Inner<Int32,Int32>
        // Outer<Object>.Inner<String,Object>
        // Outer<String>.Inner<String,Object>
        // Outer<Object>.Inner<Object,String
        
        // The same applicable for nongeneric nested Classes. It creates own copy per type.
    }
        /*
        JIT creates different code for each closed
        type with a type argument that’s a value type— int , long , Guid , and the like. But it
        shares the native code generated for all the closed types that use a reference type as the
        type argument, such as string , Stream , and StringBuilder . It can do this because all
        references are the same size (the size varies between a 32-bit CLR and a 64-bit CLR , but
        within any one CLR all references are the same size). An array of references will always
        be the same size, whatever the references happen to be.
        */
   
}
