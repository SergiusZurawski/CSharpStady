using System;

using System.Collections.Generic;  

/*Constraints are specified by using the where
    where T: struct	            - The type argument must be a value type. Any value type except Nullable can be specified. 
    where T: class	            - The type argument must be a reference type; this applies also to any class, interface, delegate, or array type.
    where T: new()	            - The type argument must have a public parameterless constructor. When used together with other constraints, the new() constraint must be specified last.
    where T: <base class name>	- The type argument must be or derive from the specified base class.
    where T: <interface name>	- The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.
    where T: U	                - The type argument supplied for T must be or derive from the argument supplied for U.
*/

namespace Generics
{
    public class Employee
{
    private string name;
    private int id;

    public Employee(string s, int i)
    {
        name = s;
        id = i;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int ID
    {
        get { return id; }
        set { id = value; }
    }
}

    public class GenericListConst<T> where T : Employee
    {
        private class Node
        {
            private Node next;
            private T data;

            public Node(T t)
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        public GenericListConst() //constructor
        {
            head = null;
        }

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

        public T FindFirstOccurrence(string s)
        {
            Node current = head;
            T t = null;

            while (current != null)
            {
                //The constraint enables access to the Name property.
                //T are guaranteed to be either an Employee object or an object that inherits from Employee
                if (current.Data.Name == s)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }
    //Multiple constraints can be applied to the same type parameter, and the constraints themselves can be generic types, as follows:
    class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
    {
        // ...
    }
   
    

}
