using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    /*
        Most of the collection types have both a generic(System.Collections.Generic) and a nongeneric version (System.Collections).
        When you work with objects of one specific type (or base type), use the generic collection. 
        It will improve type safety and performance because there is no casting required. 

        If you use a value type as the type parameter for a generic collection, make sure that you eliminate all scenarios in which boxing could occur. 
        ( IEquatable<T> and  IComparable<T> interfaces has to be implemented - otherwise boxing) When using reference types, you won’t have these issues.


        The biggest differences between the collections are the ways that you access elements.

        List and Dictionary types offer random access to all elements. 
        A Dictionary offers faster read features, but it can’t store duplicate elements.
        A Queue and a Stack are used when you want to retrieve items in a specific order. The item is removed when you have retrieved it.
        Set-based collections have special features for comparing collections. They don’t offer random access to individual elements.
        
        Although List can be used in most situations, it pays to see whether there is a more specialized collection that can make your life easier.

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
