using System;

using System.Collections.Generic;  

//A generic method is a method that is declared with type parameters, as follows
namespace Generics
{
    public class ArrayExamples
    {
        static void Example()
        {
            int[] arr = { 0, 1, 2, 3, 4 };
            System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();

            for (int x = 5; x < 10; x++)
            {
                list.Add(x);
            }

            ProcessItems<int>(arr);
            ProcessItems<int>(list);
        }

        static void ProcessItems<T>(IList<T> coll)
        {
            // IsReadOnly returns True for the array and False for the List.
            System.Console.WriteLine
                ("IsReadOnly returns {0} for this collection.",
                coll.IsReadOnly);

            // The following statement causes a run-time exception for the 
            // array, but not for the List.
            //coll.RemoveAt(4);

            foreach (T item in coll)
            {
                System.Console.Write(item.ToString() + " ");
            }
            System.Console.WriteLine();
        }
    }
}
