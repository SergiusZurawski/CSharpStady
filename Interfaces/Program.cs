using System;
<<<<<<< HEAD
using System.Collections.Generic;

namespace Interfaces
{

    //interface contains the public 
    //                       signature of methods, 
    //                       properties, 
    //                       events, 
    //                       and indexers
=======

namespace Interfaces
{
>>>>>>> 4455e980860c69552527a26aad5832d705cbe63b
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
           
        }
    }

    interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get; set; }
        //  all interface members are public by defaul
    }
    class ExampleImplementation : IExample
    {
        public string GetResult()
        {
            return "result";
        }
        public int Value { get; set; }

        public event EventHandler CalculationPerformed;
        public event EventHandler ResultRetrieved;

        public int this[string index]
        {
            get { return 42; }
            set { }
        }

    }

    //Generic interfaces
    interface IRepository<T>
    {
        T FindById(int id);
        IEnumerable<T> All();
    }




=======
            Console.WriteLine("Hello World!");
        }
    }

    interface IReadOnlyInterface
    {
        int Value { get; }
    }
    struct ReadAndWriteImplementation : IReadOnlyInterface
    {
        public int Value { get; set; }
    }
>>>>>>> 4455e980860c69552527a26aad5832d705cbe63b
}
