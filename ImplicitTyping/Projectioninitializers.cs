using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImplicitTyping
{
    class ProjectionInitializers
    {



        static void CallExample()
        {
            var person = new { Name = "Jon", Age = 36 };
            //if you don’t specify the property name, but just the expression to evaluate for the value, 
            // it’ll use the last part of the expression as the name,
            var personWithAge = new { Name = person.Name, IsAdult = (person.Age >= 18) };
            var personWithAge2 = new { person.Name, IsAdult = (person.Age >= 18) };


            List<Person> family = new List<Person>
            {
                new Person { Name = "Holly", Age = 36 },
                new Person { Name = "Jon", Age = 36 },
                new Person { Name = "Tom", Age = 9 },
                new Person { Name = "Robin", Age = 6 },
                new Person { Name = "William", Age = 6 }
            };

            var converted = family.ConvertAll(delegate (Person pers)
            {
                return new { pers.Name, IsAdult = (pers.Age >= 18) };
            }
            );
            foreach (var pers in converted)
            {
                Console.WriteLine("{0} is an adult? {1}", pers.Name, pers.IsAdult);
            }
        }
    }

}
