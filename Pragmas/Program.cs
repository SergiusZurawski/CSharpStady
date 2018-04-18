using System;

namespace Pragmas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class FieldUsedOnlyByReflection
    {
#pragma warning disable 0169
        int x;
#pragma warning restore 0169

#pragma warning disable 0169, 1111  // Multiple
#pragma warning restore 0169, 1111

#pragma warning disable         // All
#pragma warning restore 

// Generating checksum helps debuger to find a proper class
#pragma checksum "filename" "{guid}" "checksum bytes"
    }
}
