using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
//using Newtonsoft.Json;

namespace Parsing
{
    public class XMLSerizlization
    {
        static string path = @"demoxml.xml";
        static XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(XmlUser));
        public static void ExampleDesirializaton()
        { 

            

            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
           
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlUser user = (XmlUser)serializer.Deserialize(fs);
            Console.WriteLine(user.lastName);
        }

        public static void ExampleSerizalization()
        {
            TextWriter writer = new StreamWriter(path);
            XmlUser user = new XmlUser() { name = "Sergii", lastName = "ZhuravSkyi" };
            serializer.Serialize(writer, user);
            writer.Close();
        }
    }

    public class XmlUser
    {
        public string name;
        public string lastName;

        public override string ToString()
        {
            return String.Format("name:{0}, lastname{1}", name, lastName);
        }
    }
}
