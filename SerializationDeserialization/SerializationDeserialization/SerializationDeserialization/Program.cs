using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDeserialization
{
    class Program
    {
        /*
          System.Runtime.Serialization 
          System.Xml.Serialization

          The .NET Framework offers three serialization mechanisms that you can use by default:
            ■ XmlSerializer  - Simple Object Access Protocol (SOAP) , Mark [Serializable] attribute what you want to ser-ze, Don't serialize private fileldsd. have bad perofrmance
            ■ DataContractSerializer
            ■ BinaryFormatter
        */
        static void Main(string[] args)
        {
            XMLSerializeExample.ExampleXMLAttributesToConfigureSerialization();
        }
    }
}
