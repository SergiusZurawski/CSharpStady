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

    public class GenericListConstrained<T> where T : Employee
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

        public GenericListConstrained() //constructor
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
                /*The constraint enables the generic class to use the Employee.
                    Name property because all items of type T are guaranteed to be either an Employee object
                    or an object that inherits from Employee. */
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
   
    //Multiple Constrains
    interface IEmployee {};
    class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
    {
        // ...
    }

    // When applying the where T : class constraint, avoid the == and != operators on the type parameter 
    // because these operators will test for reference identity only, not for value equality
    // This is the case even if these operators are overloaded in a type that is used as an argument
    // Compiler only knows that T is a reference type at compile time 
    //   therefore must use the default operators that are valid for all reference types
    // If you must test for value equality
    //    apply the where T : IComparable<T> constraint and implement that interface

    class EqullityVerification {
        public static void OpTest<T>(T s, T t) where T : class
        {
            System.Console.WriteLine(s == t);
        }
        public static void Example()
        {
            string s1 = "target";
            System.Text.StringBuilder sb = new System.Text.StringBuilder("target");
            string s2 = sb.ToString();
            OpTest<string>(s1, s2);
        }
    }

    //Constraining Multiple Parameters
    class Base { }
    class Test<T, U>
        where U : struct
        where T : Base, new() { }

    // Unbounded Type Parameters
    // Type parameters that have no constraints, such as T in public class SampleClass<T>{}, are called unbounded type parameters
    // Unbounded type parameters have the following rules:
    // - The != and == operators cannot be used because there is no guarantee that the concrete type argument will support these operators
    // - They can be converted to and from System.Object or explicitly converted to any interface type.
    // - You can compare to null. If an unbounded parameter is compared to null, the comparison will always return false if the type argument is a value type
    // Type Parameters as Constraints

    //Type Parameters as Constraints
    class List<T>
    {
        void Add<U>(List<U> items) where U : T {/*...*/}
    }
    //Type parameters can also be used as constraints in generic class definitions. 
    //Type parameter V is used as a type constraint.
    public class SampleClass<T, U, V> where T : V { }
    // usefulness of type parameters as constraints with generic classes is very limited because  compiler knows that it is System.Object
    // USE in scenarios in which you want to enforce an inheritance relationship between two type parameters.
}
