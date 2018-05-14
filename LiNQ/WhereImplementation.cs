using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereImplementation
{
    static class Extensions
    {
        public static Dummy<T> Where<T>(this Dummy<T> dummy,
                                        Func<T, bool> predicate)
        {
            Console.WriteLine("Where called");
            return dummy;
        }
    }

    class Dummy<T>
    {
        public Dummy<U> Select<U>(Func<T, U> selector)
        {
            Console.WriteLine("Select called");
            return new Dummy<U>();
        }
    }

    class TranslationExample
    {
        public static void Example()
        {
            var source = new Dummy<string>();

            var query = from dummy in source
                        where dummy.ToString() == "Ignored"
                        select "Anything";
        }

        public static void ExampleConverted()
        {
            var source = new Dummy<string>();

            var query0 = source.Where<string>((string dummy) => dummy.ToString() == "Ignored");
            var query01 = source.Where((string dummy) => dummy.ToString() == "Ignored");
            var query = source.Where(dummy => dummy.ToString() == "Ignored").Select(dummy => "Anything");
            var query1 = source.Where(dummy => dummy.ToString() == "Ignored").Select<int>(delegate(String a) { return 1; });
        }
    }

}
