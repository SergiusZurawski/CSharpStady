using System;
using System.Globalization;

namespace Parsing
{
    public class DefenciveUseOfParsing
    {
        public static void Example()
        {
            string value = "true";
            bool b = bool.Parse(value);
            Console.WriteLine(b); // displays True
            //invalid value -  throws a FormatException. 
            //null value for the string, - ArgumentNullException. 
        }

        public static void ExampleTryParse()
        {
            string val = "1";
            int result;
            bool success = int.TryParse(val, out result);

            if (success)
            {
                // value is a valid integer, result contains the value 
            }
            else
            {
                // value is not a valid integer 
            }
            // TryParse returns a Boolean value that indicates whether the value could be parsed.
            // The out parameter contains the resulting value when the operation is successful. 
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");

            string value = "€19,95";
            decimal d = decimal.Parse(value, NumberStyles.Currency, dutch);
            Console.WriteLine(d.ToString(english)); // Displays 19.95

            /*
                ■■ Parse(string) uses the current thread culture and the DateTimeStyles.AllowWhiteSpaces.
                ■■ Parse(string, IFormatProvider) uses the specified culture and the DateTimeStyles.AllowWhiteSpaces. 
                ■■ Parse(string, IFormatProvider, DateTimeStyles).
             */

        }

        public static void ExampleConvert()
        {
            /*
              The difference between Parse/TryParse and Convert is that 
              Convert enables null values. 
              It doesn’t throw an ArgumentNullException; 
              instead, it returns the default value for the supplied type
             */
            int i = Convert.ToInt32(null);
            Console.WriteLine(i); // Displays 0

            double d = 23.15;
            int i1 = Convert.ToInt32(d);
            Console.WriteLine(i1); // Displays 23


        }
    }
}
