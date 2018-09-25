using System;

namespace Boxing
{
    public class PrimitiveTypes
    {
        /// Default values
        /// 
        private static int     intValueStatic;
        private static long    LongValueStatic;
        private static sbyte   sbyteValueStatic;
        //Unsigned Integral, Posive values only
        private static byte    byteValueStatic;
        private static ushort  ushortValueStatic;
        private static uint    uintValueStatic;
        private static ulong   ulongValueStatic;
        //Floating point
        private static decimal decimalValueStatic;
        private static float   floatValueStatic;
        private static double  doubleValueStatic;
        
        private static char    charValueStatic;
        private static string  strValueStatic;
        
        /// Default values
        /// 
        private int     intValue;
        private long    longValue;
        private sbyte   sbyteValue;
        //Unsigned Integral, Posive values only
        private byte    byteValue;
        private ushort  ushortValue;
        private uint    uintValue;
        private ulong   ulongValue;
        //Floating point
        private decimal decimalValue;
        private float   floatValue;
        private double  doubleValue;
        
        private char    charValue;
        private string  strValue;
        
        //Integer literal:
        //  - ends with L or l -  type long.
        //  - starts 0x - hexadecimal value.
        //  - starts 0x - hexadecimal value.
        //  - Number with no prefixes are treated as decimal value
        //  - Octal and binary representation are not allowed in C#.
        
        //Floating Point Literals:
        //  - ends with L or l -  type long.
        //  - starts 0x - hexadecimal value.
        //  - starts 0x - hexadecimal value.
        //  - Number with no prefixes are treated as decimal value
        //  - Octal and binary representation are not allowed in C#.
        
        //Character Literal
        char ch1 = 'R';// character
        char ch2 = '\x0072';// hexadecimal
        char ch3 = '\u0059';// unicode
        char ch4 = (char)107;// casted from integer
        
        /*String Literal
            \'	Single quote
            \"	Double quote
            \\	Backslash
            \n	Newline
            \r	Carriage return
            \t	Horizontal Tab
            \a	Alert
            \b	Backspace
         */
        
        
        public static void Example()
        {
            PrimitiveTypes pt = new PrimitiveTypes();
            Console.WriteLine("Primitive types of static");
            Console.WriteLine(intValueStatic);
            Console.WriteLine(LongValueStatic);
            Console.WriteLine(sbyteValueStatic);
            Console.WriteLine(byteValueStatic);
            Console.WriteLine(ushortValueStatic);
            Console.WriteLine(uintValueStatic);
            Console.WriteLine(ulongValueStatic);
            Console.WriteLine(decimalValueStatic);
            Console.WriteLine(floatValueStatic);
            Console.WriteLine(doubleValueStatic);
            
            Console.WriteLine(pt.charValue);
            Console.WriteLine(pt.strValue);
            
            Console.WriteLine("Primitive types of Class");
            Console.WriteLine(pt.intValue);
            Console.WriteLine(pt.longValue);
            Console.WriteLine(pt.sbyteValue);
            Console.WriteLine(pt.byteValue);
            Console.WriteLine(pt.ushortValue);
            Console.WriteLine(pt.uintValue);
            Console.WriteLine(pt.ulongValue);
            Console.WriteLine(pt.decimalValue);
            Console.WriteLine(pt.floatValue);
            Console.WriteLine(pt.doubleValue);
            
            Console.WriteLine(pt.charValue);
            Console.WriteLine(pt.strValue);
            


        }

        public void ExampleLocal()
        {
            
        }
    }
}
