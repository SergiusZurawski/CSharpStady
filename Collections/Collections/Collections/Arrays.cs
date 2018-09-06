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
        
        public static void ExampleOfArrayInitialization()
        {
            
            int[] array1 = new int[10];
            array1 = new int[11];
            array1 = new int[] {1, 2, 3 };
            array1 = new int[2] {1, 2};
            //Arrays can be initialized after the declaration.
            // It is not necessary to declare and initialize at the same time using the new keyword.
            // However, Initializing an Array after the declaration, it must be initialized with the new keyword.
            int [] array2 = {1, 2, 3 };
            
            
            //Multidementional arrays
            
            // four rows and two columns.
            int[, ] intarray = new int[4, 2];
            intarray = new int[, ] { { 1, 2 },
                                     { 3, 4 }, 
                                     { 5, 6 }, 
                                     { 7, 8 } };
            // The same array with dimensions 
            // specified 4 row and 2 column.
            intarray  = new int[4, 2] { { 1, 2 }, { 3, 4 }, 
                { 5, 6 }, { 7, 8 } };

            
            //creates an array of three dimensions, 4, 2, and 3
            int[,, ] array3 = new int[4, 2, 3];
            array3 = new int[,, ] { 
                                    { 
                                        { 1, 2, 3 }, 
                                        { 4, 5, 6 } 
                                    },
                                    { 
                                        { 7, 8, 9 }, 
                                        { 10, 11, 12 } 
                                    } 
                                  };
            
            
            int[][] array4 = new int[2][];
            array4 = new int[2][]
            {
                new int[]{1,2,3},
                new int[]{2, 3,4 }
                
            };
            
            // jaggedArray  arrays
            
            int[][] array5 = {
                new int[]{1,2,3},
                new int[]{1, 2, 3, 4}
                
            };
            
            int [][] arrm = new int [][]{ new int[]{1} , new int[]{1} }  ;
            int[,] superarm = {{1}, {2}};
        }

        public static void ExampleOfArrayInitializationShort()
        {
            int [] arr = {1};
            arr = new int [1] {1};
            arr = new int[] {1};
            //int [][] arrm = {{1},{1,2}}; //not compile
            int [][] arrm = new int [][]{new int[]{1, 1}, new int[]{1,2}};
            arrm = new int [2][]{new int[1]{1}, new int[1]{1}};
            int [,,] arr3 = new int[2,2,2];
            arr3 = new int [,,] {{{1},{2}},{{1},{2}}}; 
        }
    }
}
