using System;
using System.Data.Common;
using System.IO;

namespace ConversionRules
{
    class ConfirmingThatAConversionIsValid
    {

        ///  a try/catch statement and catch the InvalidCastException, 
        ///  but that would decrease both the performance and the readability of your code. 
        ///  "is" "as" operators that can be used to check whether a type can be converted to another type 
        ///  and to do so in a safe way
        ///  
        ///  The "is" operator returns true or false, 
        ///  depending on whether the conversion is allowed. 
        ///  
        /// The "as" operator returns the converted value or null 
        /// if the conversion is not possible. 

        static void Example1()
        {
            


        }

        void OpenConnection(DbConnection connection)
        {
            if (connection is SqlConnection)
            {         // run some special code     
            }
        } 

        void LogStream(Stream stream)
        {
            MemoryStream memoryStream = stream as MemoryStream;
            if (memoryStream != null)
            {        
                // ....    

            }
        }
    }
}