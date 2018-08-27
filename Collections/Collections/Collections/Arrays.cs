using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Arrays
    {

        /*
          arrays - fixed number of objects that all have the same type. 
          type[] arrayName
          Arrays are zero-based
          Arrays are reference types that inherit from the Array class.
          array implements IEnumerable, so you can use it in a foreach loop.

            The biggest problem with arrays is that they are of fixed size. 
       */
        static void Example()
        {
            //When creating an array, you are required to specify the number of items it will contain.
            int[] arrayOfInt = new int[10];
            for (int x = 0; x < arrayOfInt.Length; x++)
            {
                arrayOfInt[x] = x;
            }
            foreach (int i in arrayOfInt)
            {
                Console.Write(i); // Displays 0123456789
            }

            //An array can also be initialized directly. 
            int[] arrayOfInt2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //multidimensional arrays

            string[,] array2D = new string[3, 2] { { "one", "two" }, { "three", "four" }, { "five", "six" } };

            // jaggedArray  arrays
            int[][] jaggedArray =
            {
                new int[] {1,3,5,7,9},
                new int[] {0,2,4,6},
                new int[] {42,21}
            };
        }
    }
}
