using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Iterators
{
    public class OldFileReader
    {
        /*
         We have four separate concepts here: 
            1. How to obtain a TextReader 
            2. Managing the lifetime of the TextReader 
            3. Iterating over the lines returned by TextReader.ReadLine 
            4. Doing something with each of those lines
        */
        public static void CallExample()
        {
            //
            string filename = "DemoFile.txt";
            using (TextReader reader = File.OpenText(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }

    public class NewFileReader
    {
        public static void CallExample()
        {
            //
            string filename = "DemoFile.txt";
            foreach (string line in ReadLines(filename))
            {
                Console.WriteLine(line);
            }
        }

        static IEnumerable<string> ReadLines(string filename)
        {
            using (TextReader reader = File.OpenText(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}