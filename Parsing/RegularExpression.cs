using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Parsing
{
    public class RegularExpression
    {
        public static void Example()
        {
            string zipCode = "";
            Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
            Console.WriteLine(match.Success);
        }

        public static void ExampleReplace()
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{ 2,}", options);
            string input = "1 2 3 4   5";
            string result = regex.Replace(input, " ");

            Console.WriteLine(result); // Displays 1 2 3 4 5 
        }
    }
}
