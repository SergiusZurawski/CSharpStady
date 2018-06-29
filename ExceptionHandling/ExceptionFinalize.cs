using System;

namespace ExceptionHandling
{
    public class ExceptionFinalize
    {
        /*
            finily block wont run:
                1.  when the try block goes into an infinite loop, it will never exit the try block and never enter the finally block. 
                2.  situations such as a power outage, no other code will run. The whole operating system will just terminate. 
                !In a situation in which just shutting down the application is safer than running finally blocks.
                3.Preventing the finally block from running can be achieved by using Environment.FailFast. 
                         This method has two  overloads, one that only takes a string and another one that also takes an exception. 
                          When this method is called, the message (and optionally the exception) are written to the Windows application event log, and the application is terminated. 

        */
        public static void Example()
        {
            string s = Console.ReadLine();
            try {
                int i = int.Parse(s);
                if (i == 42)
                    Environment.FailFast("Specialnumberentered");
            } finally
            {
                Console.WriteLine("Programcomplete.");
            }

        }

        /*
          System.Exception properties
          Name             Description
          StackTrace       A string that describes all the methods that are currently in execution. This gives you a way of tracking which method threw the exception and how that method was reached.
          InnerException   When a new exception is thrown because another exception happened, the two are linked together with the InnerException property.
          Message          A (hopefully) human friendly message that describes the exception.
          HelpLink         A Uniform Resource Name (URN) or uniform resource locater (URL) that points to a help file.
          HResult          A 32-bit value that describes the severity of an error, the area in which the exception happened and a unique number for the exception This value is used only when crossing managed and native boundaries.
          Source           The name of the application that caused the error. If the Source is not explicitly set, the name of the assembly is used.
          TargetSite       Contains the name of the method that caused the exception. If this data is not available, the property will be null.
          Data             A dictionary of key/value pairs that you can use to store extra data for your exception. This data can be read by other catch blocks and can be used to control the processing of the exception.
         */

        public static void  Example2()
        {
            try {
                int i = ReadAndParse();
                Console.WriteLine("Parsed:{0}", i);
            } catch (FormatException e)
            {
                Console.WriteLine("Message:{0}",e.Message);
                Console.WriteLine("StackTrace:{0}", e.StackTrace);
                Console.WriteLine("HelpLink:{0}", e.HelpLink);
                Console.WriteLine("InnerException:{0}", e.InnerException);
                Console.WriteLine("TargetSite:{0}", e.TargetSite);
                Console.WriteLine("Source:{0}", e.Source);
            }


            //Displays  
            //Message: Input string was not in a correct format. 
            //StackTrace:    at System.Number.StringToNumber(String str, NumberStyles options, 
            // NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal) 
            //   at System.Number.ParseInt32(String s, NumberStyles style, 

            //NumberFormatInfo info) 
            //   at System.Int32.Parse(String s) 
            //   at ExceptionHandling.Program.ReadAndParse() in  
            //      c:\Users\Wouter\Documents\Visual Studio 2012\Projects\ 

            //ExamRefProgrammingInCSharp\Chapter1\Program.cs:line 27 
            //   at ExceptionHandling.Program.Main() in c:\Users\Wouter\Documents\ 

            //Visual Studio 2012\Projects\ExamRefProgrammingInCSharp\ 

            //Chapter1\Program.cs:line 10 
            // HelpLink: 
            // InnerException: 
        }

        private static int ReadAndParse()
        {
            string s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }

        /*
         It’s important to make sure that your finally block does not cause any exceptions. 
         When this happens, control immediately leaves the finally block and moves to the next outer try block, 
         if any. The original exception is lost and you can’t access it anymore.

        You should only catch an exception when you can resolve the issue or when you want to log the error. 
        Because of this, it’s important to avoid general catch blocks at the lower layers of your application. 
        This way, you could accidentally swallow an important exception without even knowing that it happened. 
         
         
         */
    }
}
