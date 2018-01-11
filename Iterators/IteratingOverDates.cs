using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Iterators
{



    public class IterateOverADates
    {
        static DataTable dt = new DataTable();

        public static void CallExample()
        {
            TimeTable dt = new TimeTable();
            dt.StartDate = DateTime.Now;
            dt.StartDate = new DateTime(2020, 3, 1, 7, 0, 0);
            for (DateTime day = dt.StartDate; day <= dt.EndDate; day = day.AddDays(1))
            {
            }

        }
    }

    public class TimeTable
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<DateTime> DateRange
        {
            get
            {
                for (DateTime day = StartDate; day <= EndDate; day = day.AddDays(1))
                {
                    yield return day;
                }
            }
        }
    }
}