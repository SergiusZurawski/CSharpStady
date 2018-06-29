using System;
using System.IO;
using System.Runtime.ExceptionServices;

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

        public static void SomeOperation(){throw new ArgumentException();}

        public static void Log(Exception log){}

        public static string OpenAndParse(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException("fileName", "Filename is required");

            return File.ReadAllText(fileName);
        }

        /*
            In some situations you want to wrap original exception to more user freandly or context freandly
            and  set the InnerException to the original exception
         */

        public static void  Example2()
        {
            try
            {
                ProcessOrder();
            } catch (MessageQueueException ex)
            {
                throw new OrderProcessingException("Errorwhileprocessingorder", ex);
            }
        }

        public static void ProcessOrder() { throw new ArgumentException(); }
        public class MessageQueueException: Exception {}
        public class OrderProcessingException : Exception
        {
            public OrderProcessingException(string m, Exception e):base(m, e)
            {}
        }

        /*
         ExceptionDispatchInfo.Throw method, which can be found in the System.Runtime.ExceptionServices namespace. 
         This method can be used to throw an exception and preserve the original stack trace. 
         This method can be used even outside of a catch block, 
        */

        public static void Example3()
        {
            ExceptionDispatchInfo possibleException = null;

            try
            {
                string s = Console.ReadLine();
                int.Parse(s);
            } catch (FormatException ex)
            {
                possibleException = ExceptionDispatchInfo.Capture(ex);
            }

            if (possibleException != null)
            {
                possibleException.Throw();
            }

        }

    }
}
