using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Sets
    {

        /*
           In some languages, such as Java, there is a special set type. 
           In C#, a set is a reserved keyword, but you can use the HashSet<T> if you need one. 
           A set is a collection that contains no duplicate elements and has no particular order. 
       */


        public static void Example()
        {
            HashSet<int> oddSet = new HashSet<int>();
            HashSet<int> evenSet = new HashSet<int>();
            for (int x = 1; x <= 10; x++)
            {
                if (x % 2 == 0)
                    evenSet.Add(x);
                else
                    oddSet.Add(x);
            }
            DisplaySet(oddSet);
            DisplaySet(evenSet);
            oddSet.UnionWith(evenSet);
            DisplaySet(oddSet);
        }

        private static  void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine("}");
        }

    }
}
