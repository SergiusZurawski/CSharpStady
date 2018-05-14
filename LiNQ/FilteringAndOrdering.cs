using DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LiNQExample
{
    class FilteringAndOrdering
    {
       

        public static void Example1()
        {
            User tim = SampleData.Users.TesterTim;

            var query = from bug in SampleData.AllDefects
                        where bug.Status != Status.Closed
                        where bug.AssignedTo == tim
                        select bug.Summary;

            foreach (var summary in query)
            {
                Console.WriteLine(summary);
            }

            /// The query above is translated to the following 

            SampleData.AllDefects.Where<Defect>(bug => bug.Status != Status.Closed)
                                 .Where<Defect>(bug => bug.AssignedTo == tim)
                                 .Select<Defect, String>(bug => bug.Summary);

        }

        public static void Example3()
        {
            User tim = SampleData.Users.TesterTim;

            var query = from bug in SampleData.AllDefects
                        where bug.Status != Status.Closed
                        where bug.AssignedTo == tim
                        orderby bug.Severity descending
                        select bug;

            foreach (var bug in query)
            {
                Console.WriteLine("{0}: {1}", bug.Severity, bug.Summary);
            }
        }

        public static void Example4()
        {
            User tim = SampleData.Users.TesterTim;

            var query = from bug in SampleData.AllDefects
                        where bug.Status != Status.Closed
                        where bug.AssignedTo == tim
                        orderby bug.Severity descending, bug.LastModified
                        select bug;

            foreach (var bug in query)
            {
                Console.WriteLine("{0}: {1} ({2:d})",
                                  bug.Severity, bug.Summary, bug.LastModified);
            }

            // Translated to :
            SampleData.AllDefects.Where(defect => defect.Status != Status.Closed)
                                 .Where(defect => defect.AssignedTo == tim)
                                 .OrderByDescending(defect => defect.Severity)
                                 .ThenBy(defect => defect.LastModified);

            /*
                It’s important to note that although you can use multiple orderby clauses, 
                each one will start with its own OrderBy or OrderByDescending clause, 
                which means the last one will effectively win.
             */
        }

    }
}
