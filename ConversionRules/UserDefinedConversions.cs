using System;
using System.IO;

namespace ConversionRules
{
    class UserDefinedConversions
    {

        /// When creating your own types, you can add support for both implicit and explicit conversions. 


        class Money
        {
            public Money(decimal amount)
            {
                Amount = amount;
            }

            public decimal Amount { get; set; }

            /*
             implicit and explicit operator should be declared as a public static method on your class. 
             You need to specify the return type (the type you are casting to) 
             and the type you are casting from (an instance of your class).

            */
            public static implicit operator decimal(Money money)
            {
                return money.Amount;
            }

            public static implicit operator double(Money money)
            {
                return System.Convert.ToDouble(money.Amount);
            }

            public static explicit operator int(Money money)
            {
                return (int)money.Amount;
            }
        }

        static void Example1()
        {
            // Now, when working with the Money class, 
            // you can use an implicit conversion to decimal and an explicit conversion to int
            Money m = new Money(42.42M);
            decimal amount = m;
            int truncatedAmount = (int)m;
            double d = m;
        }
    }
}
