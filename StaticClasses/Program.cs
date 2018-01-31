using System;

namespace StaticClasses
{
    class Program
    {

        /*
         
            The key features of a utility class are as follows: 
                All members are static (except a private constructor). 
                The class derives directly from object . 
                Typically there’s no state at all, unless some caching or a singleton is involved. 
                There are no visible constructors. 
                The class is sealed if the developer remembers to do so.

        */
        static void Main(string[] args)
        {
            //Invalid for static classes

        }
    }

    public sealed class NonStaticStringHelper
    {
        private NonStaticStringHelper()
        {
        }

        public static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
