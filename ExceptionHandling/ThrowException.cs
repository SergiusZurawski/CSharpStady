using System;
using System.IO;

namespace ExceptionHandling
{
    public class ThrowException
    {
        /*
            You should not try to reuse exception objects. 
            Each time you throw an exception, you should create a new one, 
            especially when working in a multithreaded environment, 
            the stack trace of your exception can be changed by another thread. When catching an exception, 
            you can choose to rethrow the exception. You have three ways of doing this: 
            ■■ Use the throw keyword without an identifier. 
            ■■ Use the throw keyword with the original exception. 
            ■■ Use the throw keyword with a new exception. 
                 
        */
        public static void Example()
        {
            //The first option rethrows the exception without modifying the call stack. 
            try
            {
                SomeOperation();
            }
            catch (Exception logEx)
            {
                Log(logEx);
                throw; // rethrow the original exception }
            }
        }

        public static void SomeOperation()
        {
            throw new ArgumentException();
        }

        public static void Log(Exception log)
        {}

        public static string OpenAndParse(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException("fileName", "Filename is required");

            return File.ReadAllText(fileName);
        }

        /*
          
         */

        public static void  Example2()
        {
            try
            {
                ProcessOrder();
            } catch (MessageQueueException ex)
            {
                throw new OrderProcessingException("Errorwhileprocessingorder", ex); }

        }
    }
}
