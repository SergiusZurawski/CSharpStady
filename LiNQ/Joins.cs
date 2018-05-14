using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereImplementation
{
    public static class Joins
    {
        public static void Example()
        {
            var query = from defect in SampleData.AllDefects
                        join subscription in SampleData.AllSubscriptions
                             on defect.Project equals subscription.Project
                        select new { defect.Summary, subscription.EmailAddress };

            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.EmailAddress, entry.Summary);
            }



        }

        public static void Example2Filtering()
        {
            ///Filtering before joins is more productive then after!
            // Filtering on the left
            var query = from defect in SampleData.AllDefects
                        where defect.Status == Status.Closed
                        join subscription in SampleData.AllSubscriptions
                        on defect.Project equals subscription.Project
                        select new { defect.Summary, subscription.EmailAddress };
            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.EmailAddress, entry.Summary);
            }

            // Filtering on the right
            //Nested Query Expression Example
            query = from subscription in SampleData.AllSubscriptions
                    join defect in (from defect in SampleData.AllDefects
                                    where defect.Status == Status.Closed
                                    select defect)
                    on subscription.Project equals defect.Project
                    select new { defect.Summary, subscription.EmailAddress };

            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.EmailAddress, entry.Summary);
            }

        
            
        }

        /*
         Inner joins are translated by the compiler into calls to the Join method, like this:

            leftSequence.Join(rightSequence,
                                leftKeySelector, 
                                rightKeySelector, 
                                resultSelector)
         */
        public static IEnumerable<TResult> Join1<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, 
                                                                                    IEnumerable<TInner> inner, 
                                                                                    Func<TOuter, TKey> outerKeySelector, 
                                                                                    Func<TInner, TKey> innerKeySelector, 
                                                                                    Func<TOuter, TInner, TResult> resultSelector)
        {
            throw new NotImplementedException();
        }
    }
}
