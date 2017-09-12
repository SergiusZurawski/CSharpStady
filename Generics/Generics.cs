using System;

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
    public class GenericList<T>
    {
       void Add(T input){}
    }

    class TestGenericList
    {
        //Declere A list of a Type 
        GenericList<int> genericList = new GenericList<int>();

        // Declare a list of type string.
        GenericList<string> list2 = new GenericList<string>();

        // Declare a list of type ExampleClass.
        GenericList<TestGenericList> list3 = new GenericList<TestGenericList>();


        public static void Example(){
            TestGenericList klass = new TestGenericList();
        }

    }

    //Second example
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
