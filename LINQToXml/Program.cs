using DataModel;
using System;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;

namespace LINQToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Example1();
            Example2();
            Example3();
        }

        static void Example1()
        {
            var users = new XElement("users",
               SampleData.AllUsers.Select(user => new XElement("user",
                       new XAttribute("name", user.Name),
                       new XAttribute("type", user.UserType)))
           );

            Console.WriteLine(users);

        }

        static void Example2()
        {
            var developers = new XElement("developers",
               from user in SampleData.AllUsers
               where user.UserType == UserType.Developer
               select new XElement("developer", user.Name)
           );
            Console.WriteLine(developers);

        }

        static void Example3()
        {
            XElement root = XmlSampleData.GetElement();

            var query = root.Element("users").Elements()
                            .Select(user => new {
                                Name = (string)user.Attribute("name"),
                                UserType = (string)user.Attribute("type")
                            });

            foreach (var user in query)
            {
                Console.WriteLine("{0}: {1}", user.Name, user.UserType);
            }
        }
    }
}
