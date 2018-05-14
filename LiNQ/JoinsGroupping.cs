using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using SqlExamples;

namespace WhereImplementation
{
    public class JoinsGroupping
    {
        public static void Example()
        {
           
            var query = from defect in SampleData.AllDefects
                        join subscription in SampleData.AllSubscriptions
                             on defect.Project equals subscription.Project
                             into groupedSubscriptions
                        select new { Defect = defect, Subscriptions = groupedSubscriptions };

            foreach (var entry in query)
            {
                Console.WriteLine(entry.Defect.Summary);
                foreach (var subscription in entry.Subscriptions)
                {
                    Console.WriteLine("  {0}", subscription.EmailAddress);
                }
            }

            /*
                One important difference between an inner join and a group join—and between a 
                    group join and a normal grouping—is that a group join has a one-to-one correspondence 
                    between the left sequence and the result sequence, even if some of the elements in the left 
                    sequence don’t match any elements of the right sequence. This can be important 
                    and is sometimes used to simulate a left outer join from SQL.
                    The embedded sequence is empty when the left element doesn’t match any right elements.

                As with an inner join, a group join buffers the right sequence but streams the left one.
             */
        }

        public static void Example2()
        {
            var dates = new DateTimeRange(SampleData.Start, SampleData.End);

            var query = from date in dates
                        join defect in SampleData.AllDefects
                             on date equals defect.Created.Date
                             into joined
                        select new { Date = date, Count = joined.Count() };

            foreach (var grouped in query)
            {
                Console.WriteLine("{0:d}: {1}", grouped.Date, grouped.Count);
            }

            /* YOu can check syntax of 
                IEnumerable<String> a;
                a.GroupJoin
                it is exactly the same as for inner joins, except that the resultSelector parameter has to work with a sequence of right-hand elements, not just a single one.
             */

            //Translated query
            dates.GroupJoin(SampleData.AllDefects, 
                                date => date, 
                                defect => defect.Created.Date, 
                                (date, joined) => new { Date = date, Count = joined.Count() });
        }
    }

   
}
