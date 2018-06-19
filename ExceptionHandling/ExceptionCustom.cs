using System;
using System.Runtime.Serialization;

namespace ExceptionHandling
{

    
    public class ExceptionCustom
    {

        
        public static void Example()
        {

            ExceptionFinalize.Example();        
                
        }
    }

    /*A custom exception should inherit from System.Exception. 
     *  You need to provide at least a parameterless constructor. 
     *  It’s also a best practice to add a few other constructors: 
     *  one that takes a string, 
     *  one that takes both a string and an exception, 
     *  and one for serialization. 
     *  By convention - use the Exception suffix in naming all your custom exceptions. 
     *  Important to add the Serializable attribute, which makes sure that your exception can be serialized and cross domains
     *  
     *  
     *  You should never inherit from System.ApplicationException. The original idea was that all C# runtime exceptions should inherit from System.Exception 
     *  and all custom exceptions from System.ApplicationException. 
     *  However, because the .NET Framework doesn’t follow this pattern, the class became useless and lost its meaning.
     
         */

    [Serializable]
    public class OrderProcessingException : Exception, ISerializable
    {
        public OrderProcessingException(int orderId)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }
        public OrderProcessingException(int orderId, string message)
        : base(message)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }

        public OrderProcessingException(int orderId, string message, Exception innerException)
        : base(message, innerException)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }

        protected OrderProcessingException(SerializationInfo info, StreamingContext context)
        {
            OrderId = (int)info.GetValue("OrderId", typeof(int));
        }

        public int OrderId { get; private set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId, typeof(int));
        }
    }

}
