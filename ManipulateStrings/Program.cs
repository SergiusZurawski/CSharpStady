using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ManipulateStrings
{
    class Program
    {
        // The string object contains an array of Char objects internally.
        // String is a reference type that looks like value type 
        //  (for example, the equality operators == and != are overloaded to compare on value, not on reference). 
        // "string" keyword is just an alias for the .NET Framework’s String. 
        //  One of the special characteristics of a string is that it is immutable, so it cannot be changed after it has been created.
        //       Every change to a string will create a new string. 
        //       This is why all of the String manipulation methods return a string. 
        //  Immutability:
        //     proc     
        //       It cannot be modified so it is inherently thread-safe.
        //       It is more secure because no one can mess with it.
        //       Suddenly something like creating undo-redo is much easier, your data structure is immutable and you maintain only snapshots of your state. 
        //     cons
        //       it will create a new string every tyme(for each iteration in your loop etc).
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        //  string interning -  When creating two identical string literals in one compilation unit, 
        //                       the compiler ensures that only one string object is created by the CLR
        //                          Doing it at runtime would incur too much of a performance penalty 
        //                          (searching through all strings every time you create a new one is too costly). 
        //
        public static void alotOfStrings()
        {
            string s = string.Empty;
            for (int i = 0; i < 10000; i++) { s += "x"; }
        }


        // StringBuilder 
        public static void alotOfStringsButWithoutConsumingAllMemory()
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            for (int i = 0; i < 10000; i++) { sb.Append("x"); }
            /*
                StringBuilder does not always give better performance. 
                When concatenating a fixed series of strings, 
                the compiler can optimize this and combine individual 
                concatenation operations into a single operation
            */
        }

        //StringWriter and StringReader 
        //   These classes adapt the interface of the StringBuilder 

        public static void StringWriterExample()
        {
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }
            string xml = stringWriter.ToString();

            //StringReaderExample
            var stringReader = new StringReader(xml);
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(),
                                new CultureInfo("en - US")); // Make sure that you read the decimal part correctly }
            }
        }


        public static void StringMethods()
        {
            string value = "My Sample Value";
            int indexOfp = value.IndexOf('p'); // returns 6 
            int lastIndexOfm = value.LastIndexOf('m'); // returns 5
            value = "<mycustominput>";
            if (value.StartsWith("<")) { }
            if (value.EndsWith(">")) { }
            value = "My Sample Value";
            string subString = value.Substring(3, 6); // Returns 'Sample'
        }

        public static void StringRegex()
        {
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach (string name in names)
                Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
        }

        //Enumerating strings 
        //  string implements IEnumerable and IEnumerable<Char>, it exposes the GetEnumerator

        public static void EnumeratingStrings()
        {
            string value = "My Custom Value";
            foreach (char c in value)
                Console.WriteLine(c);
        }

        //Formatting is the process of converting an instance of a type to a string representation. 
        // overide virtual System.Object.ToString() 
        class Person
        {
            public Person(string firstName, string lastName)
            { this.FirstName = firstName; this.LastName = lastName; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public override string ToString() { return FirstName + LastName; }
        }
        public static void FormattingStrings()
        {
            Person p = new Person("John", "Doe");
            Console.WriteLine(p); // Displays 'John Doe'
        }

        // When an object has multiple string representations, 
        //      overriding ToString is not enough - use format strings. 
        public static void FormatingSimpleCultureDependentExample()
        {
            double cost = 1234.56;
            Console.WriteLine(cost.ToString("C", new System.Globalization.CultureInfo("en-US"))); 
            // Displays $1,234.56

        }

        //You can also implement this custom formatting on your own types.  ToString(string)  
        public static void FormatingDatesExample()
        {
            DateTime d = new DateTime(2013, 4, 22);
            CultureInfo provider = new CultureInfo("en-US");
            Console.WriteLine(d.ToString("d", provider)); // Displays 4/22/2013 
            Console.WriteLine(d.ToString("D", provider)); // Displays Monday, April 22, 2013 
            Console.WriteLine(d.ToString("M", provider)); // Displays April 22
        }

        class Person1 : Person
        {
            public Person1(string firstName, string lastName) : base(firstName, lastName) { }
            public string ToString(string format)
            {
                if (string.IsNullOrWhiteSpace(format) || format == "G")
                    format = "FL";

                    format = format.Trim().ToUpperInvariant();

                    switch (format)
                    {
                        case "FL":
                            return FirstName + " " + LastName;
                        case "LF":
                            return LastName + " " + FirstName;
                        case "FSL": return FirstName + ", " + LastName;
                        case "LSF": return LastName + ", " + FirstName;
                        default:
                            throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
                }
            }
        }

    }
}
