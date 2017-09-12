using System;
//There are times when value types are more efficient than reference types, and vice versa.
//Reference type objects are always on the heap, but value type values can be on either the stack or the heap, depending on context.
//When a reference type is used as a method parameter, by default the argument is passed by value, but the value itself is a reference.
//Value type values are boxed when reference type behavior is needed; unboxing is the reverse process.



//The value of a reference type variable is always a reference.
//The value of a value type variable is always a value of that type.
namespace RefferenceValueTypes
{
    class Program
    {
        static void Example()
        {
            int i = 5;       // Value type
            object o = i;    // Value type > refference type , Autoboxing
            int j = (int) o; // refference type > Value type, Autoboxing

            /*Boxing
                ToString , 
                Equals , 
                GetHashCode
                if you use the value as an interface expression
             */
             IComparable x = 5;
        }
    }
}
/*
!!COST!!
potential perfor- mance penalty involved
single box or unbox operation is cheap, 
hundreds of thousands - cost of the operations, 
AND
a lot of objects, which gives the garbage collector more work to do

 */
