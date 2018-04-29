using System.IO;
using System.Linq;
using System;

namespace ExtentionMethods
{
    public static class SelectProjectionUsingLambdaAndAnonymousType
    {
        // Select is just a projection method it doesn't do filtering
        public static void Example1()
        {
           var collection = Enumerable.Range(0, 10).Where(x => x % 2 != 0)
                                        .Reverse()
                                        .Select(x => new { Original = x, SquareRoot = Math.Sqrt(x) } ); 

            // You can’t give the collection variable an explicit type other than the nongeneric IEnumerable type or object . 
            // Implicit typing (with var ) is what allows you to use the Original and SquareRoot
            foreach (var element in collection)
            { 
                Console.WriteLine("sqrt({0})={1}", element.Original, element.SquareRoot); 
            }
        }

        
    }
   
}