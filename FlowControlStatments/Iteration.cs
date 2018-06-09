using System;

namespace FlowControlStatments
{
    class Iteration
    {
        /*
            ■ for - for(initial; condition; loop); Legal- for(;;) {} 
            ■ foreach
            ■ while
            ■ do while 
         */

        public static void Example()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index++)
            {
                Console.Write(values[index]);
            }
            // Displays
            // 123456
        }

        public static void Example2()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index += 2)
            {
                Console.Write(values[index]);
            }
            // Displays
            // 135

        }

        public static void Example3ManulBrakeOfForStatment()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] == 4) break;
                Console.Write(values[index]);
            }
            // Displays
            // 123
        }

        public static void Example4ManulContinue()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int index = 0; index < values.Length; index++)
            {
                if (values[index] == 4) continue;
                Console.Write(values[index]);
            }
            // Displays
            // 12356
        }

        public static void Example5While()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            {
                int index = 0;
                while (index < values.Length)
                {
                    Console.Write(values[index]);
                    index++;
                }
            }
        }

        public static void Example6DoWhile()
        {
            do
            {
                Console.WriteLine("Executedonce!");
            }
            while (false);
        }


        /*
            The foreach loop is used to iterate over a collection and automatically stores the current item
            in a loop variable. The foreach loop keeps track of where it is in the collection and protects
            you against iterating past the end of the collection
         */

        public static void Example7foreach()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            foreach (int i in values)
            {
                Console.Write(i);
            }
            // Displays 123456
        }

    }
}
