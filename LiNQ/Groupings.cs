using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using SqlExamples;

namespace WhereImplementation
{
    /* group a sequence of elements by one of its properties. 
         = group projection by grouping =
        */
    public class Groupings
    {
        public static void Example()
        {

            var query = from defect in SampleData.AllDefects
                        where defect.AssignedTo != null
                        group defect by defect.AssignedTo;

            foreach (var entry in query)
            {
                Console.WriteLine(entry.Key.Name);
                foreach (var defect in entry)
                {
                    Console.WriteLine("  ({0}) {1}",
                                      defect.Severity,
                                      defect.Summary);
                }
                Console.WriteLine();
            }

            //Translated to this 
            query = SampleData.AllDefects.Where(defect => defect.AssignedTo != null)
                                         .GroupBy(defect => defect.AssignedTo);


        }

        public static void Example1()
        {
            var query = from defect in SampleData.AllDefects
                        where defect.AssignedTo != null
                        group defect.Summary by defect.AssignedTo;

            foreach (var entry in query)
            {
                Console.WriteLine(entry.Key.Name);
                foreach (var summary in entry)
                {
                    Console.WriteLine("  {0}", summary);
                }
                Console.WriteLine();
            }
            // Translated 
            query = SampleData.AllDefects.Where(defect => defect.AssignedTo != null)
                                         .GroupBy(defect => defect.AssignedTo, defect => defect.Summary);
        }

    }
 }
