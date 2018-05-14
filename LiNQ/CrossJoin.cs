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
        public static void Example()
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
        public static void ExampleRangeCartesianJoin()
        {
            var query = from left in Enumerable.Range(1, 4)
                        from right in Enumerable.Range(11, left)
                        select new { Left = left, Right = right };

            foreach (var pair in query)
            {
                Console.WriteLine("Left={0}; Right={1}", pair.Left, pair.Right);
            }

            // Translated
            query = Enumerable.Range(1, 4).SelectMany(left => Enumerable.Range(11, left), 
                                                     (left, right) => new { Left = left, Right = right });

            /*
                SelectMany is that the execution is completely streamed—
                it only needs to process one element of each sequence at a time, 
                because it uses a freshly generated right sequence for each different element of the left sequence. 
                Compare this with inner joins and group joins: 
                they both load the right sequence completely before starting to return any results.
             */

        }
    }

    //Demo of SelectMany1
    public static class SelectMenyDemoClass
    {
        static IEnumerable<TResult> SelectMany1<TSource, TCollection, TResult>( this IEnumerable<TSource> source, 
                                                                                Func<TSource, IEnumerable<TCollection>> collectionSelector, 
                                                                                Func<TSource, TCollection, TResult> resultSelector)
        {
            return null;
        }
    }

    }
