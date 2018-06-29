using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
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
}
