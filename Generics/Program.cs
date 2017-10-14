using System;
using Generics;
using Equality;
using StaticFieldsAndConstructors;
using ReflectionsForGenerics;
using static IterationsOverCustomMadeType.IterationsOverCustomMadeTypeExample;
using static Generics.TestGenericList;
using static ExampleOfPair;
//using static StaticFieldsAndConstructors.StaticFieldsExample;


namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generics.GenericListAdvanced<int>.Example2();
            //Generics.EqullityVerification.Example();
            //Equality.ComparisonsOverridden.Example();
            //StaticFieldsAndConstructors.StaticFieldsExample.Example();
            //StaticFieldsAndConstructors.StaticConstructorAndNestedGenericsExample.Example();
            //IterationsOverCustomMadeType.IterationsOverCustomMadeTypeExample.Example();
            GenericReflectionExample.Example();

        }
    }
}
