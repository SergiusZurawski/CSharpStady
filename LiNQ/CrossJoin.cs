using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using SqlExamples;

namespace WhereImplementation
{
    /*
     Cross joins don’t perform any matching between the sequences; the result contains every possible pair of elements. This is achieved by simply using two (or more) from clauses.
         */
    public class CrossJoin
    {
       public static void  Example()
       {

            var query = from user in SampleData.AllUsers
                        from project in SampleData.AllProjects
                        select new { User = user, Project = project };

            foreach (var pair in query)
            {
                Console.WriteLine("{0}/{1}",
                                    pair.User.Name,
                                    pair.Project.Name);
            }

       }
    }

   
}
