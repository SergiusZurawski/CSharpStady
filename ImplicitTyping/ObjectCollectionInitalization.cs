using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ImplicitTyping
{

    /*
        Object initializers are most commonly used to set properties, but everything shown here also applies to fields.
     */
    class ObjectCollectionInitalization
    {
        static void CallExample()
        {
            //Syntatic sugar, it is compiled to the same thing.
            Person thom = new Person() { Age = 29, Name = "Thomas" };
            //Order deffines which property is set first
            Person thom1 = new Person() { Name = "Thomas" , Age = 29 };
            // You cannot specify the same property multiple times

            //The expression used as the value for a property can be any expression that isn’t itself an assignment

            //Array initialization
            Person[] family = new Person[] {
                new Person { Name = "Holly", Age = 36 },
                new Person { Name = "Jon", Age = 36 },
                new Person { Name = "Tom", Age = 9 },
                new Person { Name = "William", Age = 6 },
                new Person { Name = "Robin", Age = 6 }
            };

            //8.3.3.Setting properties on embedded objects (read property)
            // Pay attention there is no 'new' keyword
            Person tom = new Person("Tom")
            {
                Age = 9,
                Home = { Country = "UK", Town = "Reading" }
            };

            //8.3.4. Collection initializers
            // Procs: 
            // 1. The create-and-initialize part counts as a single expression.
            // (usefful when use a collection as either an argument to a method or as one element in a larger collection.)
            // 2. There’s a lot less clutter in the code.

            // Collection initializers - You can use them with any type that implements IEnumerable
            // "Add" method ?

            // Dictionary Example
            Dictionary<string, int> nameAgeMap = new Dictionary<string, int>
            {
                { "Holly", 36 },
                { "Jon", 36 },
                { "Tom", 9 }
            };

            // Combining Collection initializers and Object Initializers
            Person thom5 = new Person
            {
                Name = "Thomas",
                Age = 9,
                Home = { Town = "Belfast", Country = "UK" },
                Friends =
                {
                    new Person{Name = "Jeff"},
                    new Person{Name = "Herman"},
                    new Person{Name="Diogo"},
                    new Person("Some Dude"),
                    new Person
                    {
                        Name = "Sergii",
                        Home = { Town = "Kiev", Country = "Ukraine"}
                    }

                }
            };
            // NOTE: you can’t express cyclic relationships.
            // NOTE2: Fridends and Home are read only properties. Compilder calls Property and only then Add 

            // 8.3.5. RECOMMENDED USAGE:
            // 1. Constant collections
            //    (Typically, this used to involve writing a static constructor or a helper method, just to populate the map.)
            //    With Initializers it is just 1 Expression
            // 2. Setting up unit tests
            // 3. The builder pattern 
            //    sometimes you want to specify a lot of values for a single method or constructor call.

        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        List<Person> friends = new List<Person>();
        public List<Person> Friends
        {
            get { return friends; }
        }

        Location home = new Location();

        public Location Home
        {
            get { return home; }
        }
        public Person() {}
        public Person(string name)
        {
            Name = name;
        }
    }
    public class Location {
        public string Country { get; set; }
        public string Town { get; set; }
    }
}
