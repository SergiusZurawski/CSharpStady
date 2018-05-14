using DataModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LiNQExample
{
    class DegenerateQueryExpression
    {
       

        public static void Example1()
        {
            var a = from defect in SampleData.AllDefects select defect;
            //Translated to ; The compiler deliberately generates a call to Select even though it seems to do nothing:
            SampleData.AllDefects.Select(defect => defect);
            //The items returned by the two sequences are the same, but the result of the Select method is just the sequence of items, not the source itself.
        }

        public static void Example2()
        {
            User tim = SampleData.Users.TesterTim;

            var a = from defect in SampleData.AllDefects
                    where defect.Status != Status.Closed
                    where defect.AssignedTo == SampleData.Users.TesterTim
                    select defect;

            //Translated to ; NO SELECT
            SampleData.AllDefects.Where(defect => defect.Status != Status.Closed).Where(defect => defect.AssignedTo == tim);
        }
    }
}
