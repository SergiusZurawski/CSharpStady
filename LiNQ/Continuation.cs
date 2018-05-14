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
                    select new { Assignee = grouped.Key, Count = grouped.Count() }

        }

        public static void Example1()
        {
            
        }

    }
 }
