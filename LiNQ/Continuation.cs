using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using SqlExamples;

namespace WhereImplementation
{
    /* 
        Query continuations provide a way of using the result of one query expression as the initial sequence of another. 
        They apply to both group ... 
        by and select clauses, and the syntax is the same for both—you simply use the contextual keyword into and 
        then provide the name of a new range variable.

        first-query into identifier second-query-body
        from identifier in ( first-query ) second-query-body


        !IMPRORTANT: 
        contextual keyword "into" doesn't always mean "continuation".
        When joins—the join ... into clause (which is used for group joins) doesn’t form a continuation. 
                The important difference is that with a group join, 
                all the earlier range variables 
                (apart from the one used to name the right side of the join) can still be used.

     */
    public class Continuation
    {
        public static void Example()
        {
            var query = from defect in SampleData.AllDefects
                        where defect.AssignedTo != null
                        group defect by defect.AssignedTo into grouped
                        select new { Assignee = grouped.Key, Count = grouped.Count() };

            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}",
                                  entry.Assignee.Name,
                                  entry.Count);
            }

            //Translate into this 
            query = from grouped in (from defect in SampleData.AllDefects
                                     where defect.AssignedTo != null
                                     group defect by defect.AssignedTo)
                    select new { Assignee = grouped.Key, Count = grouped.Count() };

            //Translation Second part
            query = SampleData.AllDefects.Where(defect => defect.AssignedTo != null)
                                    .GroupBy(defect => defect.AssignedTo)
                                    .Select(grouped => new { Assignee = grouped.Key, Count = grouped.Count() });

        }

        public static void Example1()
        {
            var query = from defect in SampleData.AllDefects where defect.AssignedTo != null
                        group defect by defect.AssignedTo into grouped
                        select new { Assignee = grouped.Key, Count = grouped.Count() } into result
                        orderby result.Count descending
                        select result;

            foreach (var entry in query)
            {
                Console.WriteLine("{0}: {1}", entry.Assignee.Name, entry.Count);
            }

            //Translated
            SampleData.AllDefects.Where(defect => defect.AssignedTo != null)
                       .GroupBy(defect => defect.AssignedTo)
                       .Select(grouped => new { Assignee = grouped.Key, Count = grouped.Count() })
                       .OrderByDescending(result => result.Count);  
                        //The final select clause effectively does nothing, so the C# compiler ignores it.
        }

    }
 }
