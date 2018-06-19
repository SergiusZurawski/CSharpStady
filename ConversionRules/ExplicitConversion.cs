using System;
using System.IO;

namespace ConversionRules
{
    class ExplicitConversion
    {

        ///  

        static void Example1()
        {
            
            double x = 1234.7;
            int a;
            // Cast double to int 
            //data loss
            a = (int)x; // a = 1234

            // Cast of refference type
            Object stream = new MemoryStream();
            MemoryStream memoryStream = (MemoryStream)stream;

        }
    }
}
