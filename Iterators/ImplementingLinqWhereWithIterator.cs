using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Iterators
{
    public class ImplementingLinqWhereWithIterator
    {

        public static IEnumerable<T> Where<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null ||  predicate == null)
            {
                throw new ArgumentException();
            }
            return WhereImpl(source, predicate);
        }

        public static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static void CallExample()
        {
            IEnumerable<string> lines = FileReaderAsAFunction.ReadLines(() => File.OpenText("DemoFile.txt"));
            Predicate<string> predicate = delegate (string line) { return line.StartsWith("PredicateText"); };
            foreach (string line in Where(lines, predicate))
            {
                Console.WriteLine(line);
            }

        }


    }

    
}