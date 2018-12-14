using System;
using System.Globalization;

namespace DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDate = "somedate";
            System.DateTime validatedDate = System.DateTime.Now;
            bool validDate = System.DateTime.TryParse(inputDate, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal, out validatedDate );
            Console.WriteLine(validatedDate);
        }
    }
}
