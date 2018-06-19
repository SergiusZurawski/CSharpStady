using System;

namespace ConversionRules
{
    class ImplicitConversion
    {

        ///  An implicit conversion doesn’t need any special syntax.
        ///  It can be executed because the compiler knows that the conversion is allowed 
        ///  and that it’s safe to convert. 

        static void Example1()
        {
            //No loss od data
            int i = 42;
            double d = i;
        }
    }
}
