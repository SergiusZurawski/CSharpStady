using System;
using System.Collections.Generic;
using System.Linq;

namespace Types
{
   

    public class SOLIDPrinciple
    {
        ///S Single responsibility principle A class should have only one responsibility. For example, a class shouldn’t be both responsible for saving itself to the database and for displaying to the user.
        ///O Open/closed principle An object should be open for extension but closed for modification.For example, by using a common interface, new objects can integrate with existing code without modifying the existing code.
        ///L Liskov substitution principle A base type should be replaceable with subtypes in each and every situation.For example, a Duck that can swim and an inherited ElectricDuck that can swim only if the batteries are full. Suddenly, code needs to check whether the Duck is an ElectricDuck to replace empty batteries.
        ///I Interface segregation principle Use client-specific interfaces instead of one general interface. A user of an interface should not have to implement all kinds of methods that he doesn’t use.
        ///D Dependency Inversion principle Depend upon abstractions, not concretions. For example, when you use SomeServiceType inside your class, you shouldn’t depend on the actual implementation of SomeServiceType.Instead you should depend on an interface or abstract class. This way, you are less coupled to the actual implementation
}

}
