using System;
using System.Linq;

namespace LiNQExample
{
    class BrakeDownQuery
    {
        public static void Example1()
        {
            /*
             /deffered execution
             When the query expression shown bellow is created, 
                no data is processed. 
                The original list of people isn’t accessed at all. Instead, 
                a representation of the query is built up in memory. 
                Delegate instances are used to represent the predicate testing for adulthood 
                and the conversion from a person to that person’s name. The wheels only start turning when 
                the resulting IEnumerable<string> is asked for its first element.

                Streaming manner (Regardless of how much source data there is, 
                you don’t need to know about more than one element at any point in time.)

                Alternative would be Enumerable.Reverse - it has to know the whole sequence before returning first one.
                This makes Reverse a buffering operation,

                / immediate execution - transformations take place as soon as you call them, rather than using deferred execution.

                Generally speaking, 
                    operations that return another sequence (usually an IEnumerable<T> or IQueryable<T> ) use deferred execution, 
                    whereas operations that return a single value use immediate execution.
                
                Standard query operators LINQ’s standard query operators are a collection of transformations whose meanings are well understood.
             */
            var people = new[]
            {
                new { Name="Holly", Age=36},
                new { Name="Tom", Age=9},
                new { Name="Jon", Age=36},
                new { Name="WillIam", Age=6},
                new { Name="Robin", Age=6}
            };
            var adultNames = from person in people
                                where person.Age >= 18
                                select person.Name;

            adultNames.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
