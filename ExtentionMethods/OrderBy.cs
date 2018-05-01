using System.IO;
using System.Linq;
using System;

namespace ExtentionMethods
{
    public static class OrderBy
    {
        //OrderBy - performs sorting
        // Methods: 
        //  OrderBy
        //  OrderByDescending
        // sort by more than one property
        //  ThenBy
        //  ThenByDescending
        /// One thing to note is that the ordering doesn’t change an existing collection—it returns a new sequence 
        // that yields the same data as the input sequence, except sorted. - "side-effect free" (FuncP)
        //  they don’t affect their input, 
        //  and they don’t make any other changes to the environment, 
        //  unless you’re iterating through a naturally stateful sequence (such as reading from a network stream) 
        //  or a delegate argument has side effects.
        public static void Example1()
        {
            var collection = Enumerable.Range(-5, 11)
                                 .Select(x => new { Original = x, Square = x * x })
                                 .OrderBy(x => x.Square)
                                 .ThenBy(x => x.Original);

            foreach (var element in collection)
            {
                Console.WriteLine(element);
            }
        }

        public static void Example2()
        {
            var company = new
            {
                Departments = new[]
                                {
                                    new {
                                            Name = "DataScience",
                                            Employees = new []
                                                            {
                                                                new { Name = "N1", Salary = 50000},
                                                                new { Name = "N2", Salary = 51000}
                                                            },
                                        },
                                    new {
                                            Name = "DevOps",
                                            Employees = new []
                                                            {
                                                                new { Name = "N1mcSon", Salary = 45000},
                                                                new { Name = "N2mcSon", Salary = 46000}
                                                            },
                                        },
                                    new {
                                            Name = "SoftwareArhitects",
                                            Employees = new []
                                                            {
                                                                new { Name = "SZhuravskyi", Salary = 500000},
                                                                new { Name = "O'Someone", Salary = 346000}
                                                            },
                                        },
                                    new {
                                            Name = "Software Engineers",
                                            Employees = new []
                                                            {
                                                                new { Name = "JrSZhuravskyi", Salary = 50000},
                                                                new { Name = "LongNose", Salary = 36000}
                                                            },
                                        },
                                }
            };
            //Main Part
            var companyResult = company.Departments.Select(
                    dept => new
                    {
                        dept.Name,
                        Cost = dept.Employees.Sum(person => person.Salary)
                    })
                               .OrderByDescending(deptWithCost => deptWithCost.Cost);



            foreach (var element in companyResult)
            {
                Console.WriteLine(element);
            }
        }

        public static void Example3GroupBy()
        {
            var bugs = new []
            {
               new { AssignedTo = "Mike" },
               new { AssignedTo = "Igor" },
               new { AssignedTo = "Mike" },
               new { AssignedTo = "Igor" },
               new { AssignedTo = "Igor" },
               new { AssignedTo = "Serg" },
               new { AssignedTo = "Thomas" },
               new { AssignedTo = "Thomas" },
               new { AssignedTo = "Thomas" },
               new { AssignedTo = "Thomas" },

            };

            var result = bugs.GroupBy(bug => bug.AssignedTo)
                                .Select(list => new { Developer = list.Key, Count = list.Count() })
                                    .OrderByDescending(x => x.Count);

            foreach (var element in result)
            {
                Console.WriteLine(element);
            }
        }
    }
}