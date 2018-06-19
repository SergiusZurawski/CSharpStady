using System;
using System.IO;

namespace ConversionRules
{
    class ConversionsWithAHelperClass
    {

        ///  For converting between noncompatible types, 
        ///  you can use System.BitConverter. 
        ///  For conversion between compatible types, you can use System.Convert 
        ///  and the Parse or TryParse methods on various types. 
       
        ///  Implementing the IFormattable interface is required so that your object can be used by the Convert class  


        static void Example1()
        {
            int value = Convert.ToInt32("42");
            value = int.Parse("42");
            bool success = int.TryParse("42", out value);


        }
    }
}
