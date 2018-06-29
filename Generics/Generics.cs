using System;


/// Investigate default(T)

using System.Collections.Generic;  //name space with generics 
    //System.Collections           //old collections

namespace Generics
{
    // Implement existing Type:
    public class IComparer2 : IComparer<int> 
    { 
        public int Compare(int x, int y) {return 0;}
    }

    // Declare the generic class.
    public class GenericList0<T>
    {
       void Add(T input){}
    }

    //Generic classes encapsulate operations that are not specific to a particular data type. 
    //Generic classes can inherit from concrete, closed constructed, or open constructed base classes:
    class BaseNode { }
    class BaseNodeGeneric<T> { }
    // concrete type
    class NodeConcrete<T> : BaseNode { }
    //closed constructed type
    class NodeClosed<T> : BaseNodeGeneric<int> { }
    //open constructed type 
    class NodeOpen<T> : BaseNodeGeneric<T> { }

    //Non-generic, in other words, concrete, classes can inherit from closed constructed base classes, but not from open constructed classes
    //No error
    class Node1 : BaseNodeGeneric<int> { }
    //Generates an error
    //class Node2 : BaseNodeGeneric<T> {}
    //Generates an error
    //class Node3 : T {}

    //Generic classes that inherit from open constructed types must supply type arguments for any base class type 
    //  parameters that are not shared by the inheriting class

    class BaseNodeMultiple<T, U> { }
    //No error
    class Node4<T> : BaseNodeMultiple<T, int> { }
    //No error
    class Node5<T, U> : BaseNodeMultiple<T, U> { }
    //Generates an error
    //class Node6<T> : BaseNodeMultiple<T, U> {}

    //Generic classes that inherit from open constructed types must specify constraints that are a superset of,or imply, the constraints on the base type
    class NodeItem<T> where T : System.IComparable<T>, new() { }
    class SpecialNodeItem<T> : NodeItem<T> where T : System.IComparable<T>, new() { }

    //Open constructed and closed constructed types can be used as method parameters:
    class CodeExample{
        void Swap<T>(List<T> list1, List<T> list2){}
        void Swap(List<int> list1, List<int> list2){}
    }

    //If a generic class implements an interface, all instances of that class can be cast to that interface
    //Generic classes are invariant. In other words, if an input parameter specifies a 
    //List<BaseClass>, you will get a compile-time error if you try to provide a 
    //List<DerivedClass>

    class TestGenericList
    {
        //Declere A list of a Type 
        GenericList0<int> genericList = new GenericList0<int>();

        // Declare a list of type string.
        GenericList0<string> list2 = new GenericList0<string>();

        // Declare a list of type ExampleClass.
        GenericList0<TestGenericList> list3 = new GenericList0<TestGenericList>();


        public static void Example(){
            TestGenericList klass = new TestGenericList();
        }

    }

    // Advence example
    // type parameter T in angle brackets
    public class GenericListAdvanced<T> 
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node next;
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            
            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data  
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;
        
        // constructor
        public GenericListAdvanced() 
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t) 
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public static void Example2()
        {
            // int is the type argument
            GenericListAdvanced<int> list = new GenericListAdvanced<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            foreach (int i in list)
            {
                System.Console.Write(i + " ");
            }
            System.Console.WriteLine("\nDone");
        }
    }
    

}
