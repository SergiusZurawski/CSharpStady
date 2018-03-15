using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImplicitTyping
{

    
    class AnonimusTypes
    {
        // Figure 8.5. Anonymous types allow you to keep just the data you need for a particular situation, 
        // in a form that’s tailored to that situation, 
        // without the tedium of writing a fresh type each time.
        // (If you find yourself creating a type that’s only used in a single method, and that only contains fields and trivial properties,
        // consider whether an anonymous type would be appropriate.)

        //Anonymous types contain the following members: 
        // A constructor taking all the initialization values.
        // The parameters are in the same order as they were specified in the anonymous object initializer, 
        //   and they have the same names and types.
        //   Public read-only properties.
        //   Private read-only fields backing the properties.
        //   Overrides for Equals , GetHashCode , and ToString .

        // Because the properties are read-only, all anonymous types are immutable
        // as long as the types used for their properties are immutable.

        static void CallExample()
        {
            //syntax for initializing an anonymous type is similar to the object initializers
            var tom = new { Name = "Tom", Age = 9 };
            var holly = new { Name = "Holly", Age = 36 };
            var jon = new { Name = "Jon", Age = 36 };
            Console.WriteLine("{0} is {1} years old", jon.Name, jon.Age);

            var family = new[]
            {

                new { Name = "Holly", Age = 36},
                new { Name = "Jon", Age = 36},
                new { Name = "Tom", Age = 9},
                new { Name = "Robin", Age = 6},
                new { Name = "Willam", Age = 6},
            };

            int totalAge = 0;
            foreach (var person in family)
            {
                totalAge += person.Age;
            }
            Console.WriteLine("Total age: {0}", totalAge);
            //Within any given assembly, 
            //the compiler treats two anonymous object initializers as the same type if there are the same number of properties,
            // with the same names and types in the same order.
            // NOTE:
            // different anonymus type in case of any below:
            // 1. Swaping order
            // 2. Chaning Type for example int to long of a property
            // 3. Extra property

        }



    }

   
}
