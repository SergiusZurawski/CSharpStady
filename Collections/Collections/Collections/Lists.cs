using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Lists
    {

        /*
             adding 
             removing items, 
             accessing items by index, 
             searching
             sorting the list.

             public class List<T> :                             IList<T>,                             ICollection<T>,                             IList,                             ICollection,                              IReadOnlyList<T>,                             IReadOnlyCollection<T>,                             IEnumerable<T>,                             IEnumerable
       */
        static void Example()
        {
            List<string> listOfStrings = new List<string> { "A", "B", "C", "D", "E" };
            for (int x = 0; x < listOfStrings.Count; x++)
                Console.Write(listOfStrings[x]); // Displays: ABCDE

            listOfStrings.Remove("A");
            Console.WriteLine(listOfStrings[0]);    // Displays: B
            listOfStrings.Add("F");
            Console.WriteLine(listOfStrings.Count); // Displays: 5
            bool hasC = listOfStrings.Contains("C");
            Console.WriteLine(hasC);                // Displays: true 
        }
    }
}
