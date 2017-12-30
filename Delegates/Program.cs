using System;
using static Delegates.Delegates;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Delegates.Example();
            SimpleDelegateUse.Example();
            ContrVarianceInArumentTypes.Example();
            CovarianceOnReturnTypes.Example();
            Closures.ExampleOfBehavoiurOfCapturedVariable();
            Closures.ExampleOfExtendedLifeTime();
            Console.WriteLine("---------------");
            Closures.ExampleOfLocalVariableInitializedInLoop();
        }
    }
}
