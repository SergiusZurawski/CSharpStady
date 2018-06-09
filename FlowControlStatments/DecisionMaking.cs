using System;

namespace FlowControlStatments
{
    class DecisionMaking
    {

        /*
            ■ if
            ■ while
            ■ do while
            ■ for
            ■ foreach
            ■ switch
            ■ break
            ■ continue
            ■ goto
            ■ (??) Null-coalescing operator 
            ■ (?:) Conditional operator   
        */


        static void ExampleIF()
        {
            bool b = true;
            if (b)
                Console.WriteLine("True");

            if (b)
            {
                Console.WriteLine("True");
            }

            if (b)
            {
                //Scope of local variables
                int r = 42;
                b = false;
            }
            // r is not accessible
            // b is now false

            // ELSE
            b = false;
            if (b)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

            //ELSE IF 
            bool c = true;
            if (b)
            {
                Console.WriteLine("b is true");
            }
            else if (c)
            {
                Console.WriteLine("c is true");
            }
            else
            {
                Console.WriteLine("bandcarefalse");
            }
        }

        static void ExampleNullCoalescing()
        {
            int? x = null;
            int y = x ?? -1;  // y =  -1

            int? z = null;
            y = x ??
                z ??
                 -1;
        }

        static void ExampleConditional()
        {
            GetValue(true);
        }

        private static int GetValue(bool p)
        {
            if (p)
                return 1;
            else
                return 0;
            return p ? 1 : 0;
        }

        static void ExampleSwitch()
        {
            // CLASSIC IF 
            Check('a');
            // SWITCH - sysntatic sugar -loks better
            CheckWithSwitch('a');
        }

        static void Check(char input)
        {
            if (input == 'a'
            || input == 'e'
            || input == 'i'
            || input == 'o'
            || input == 'u')
            {
                Console.WriteLine("Input is a vowel");
            }
            else
            {
                Console.WriteLine("Input is a consonant");
            }
        }
        static void CheckWithSwitch(char input)
        {
            switch (input)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                {
                    Console.WriteLine("Input is a vowel");
                    break;
                }
                case 'y':
                {
                    Console.WriteLine("Input is sometimes a vowel.");
                    break;
                }
                default:
                {
                    Console.WriteLine("Input is a consonant");
                    break;
                }
            }
        }

        static void CheckWithSwitchAndGoTo(char input)
        {
            int i = 1; switch (i) 
            {     
                case 1:         
                {             
                    Console.WriteLine("Case 1");             
                    goto case 2;         
                }     
                case 2:         
                {             
                    Console.WriteLine("Case 2");             
                    break;         
                } 
                
            } 
        }

    }
}
