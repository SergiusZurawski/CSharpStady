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
        
    }
}
