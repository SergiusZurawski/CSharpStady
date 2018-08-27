using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDeserialization
{
    public class XMLSerializeExample
    {
        /*

           ■ XmlSerializer  - Simple Object Access Protocol (SOAP) , Mark SerializableAttribute, Don't serialize private fileldsd. have bad perofrmance
               Attributes:
                ■ XmlIgnore
                ■ XmlAttribute
                ■ XmlElement
                ■ XmlArray
                ■ XmlArrayItem
        */

        [Serializable]
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        public static void Example()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Person p = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 42
                };
                serializer.Serialize(stringWriter, p);
                xml = stringWriter.ToString();
            }
            Console.WriteLine(xml);
            using (StringReader stringReader = new StringReader(xml))
            {
                Person p = (Person)serializer.Deserialize(stringReader);
                Console.WriteLine("{0} {1} is {2} years old", p.FirstName, p.LastName, p.Age);
            }
        }

        [Serializable]
        public class Order
        {
            [XmlAttribute]
            public int ID { get; set; }
            [XmlIgnore]
            public bool IsDirty { get; set; }
            [XmlArray("Lines")]
            [XmlArrayItem("OrderLine")]
            public List<OrderLine> OrderLines { get; set; }
        }

        [Serializable]
        public class VIPOrder : Order
        {
            public string Description { get; set; }
        }
        [Serializable]
        public class OrderLine
        {
            [XmlAttribute]
            public int ID { get; set; }
            [XmlAttribute]
            public int Amount { get; set; }
            [XmlElement("OrderedProduct")]
            public Product Product { get; set; }
        }
        [Serializable]
        public class Product
        {
            [XmlAttribute]
            public int ID { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
        }

        private static Order CreateOrder()
        {
            Product p1 = new Product { ID = 1, Description = "p2", Price = 9 };
            Product p2 = new Product { ID = 2, Description = "p3", Price = 6 };
            Order order = new VIPOrder
            {
                ID = 4,
                Description = "Order for John Doe. Use the nice giftwrap",
                OrderLines = new List<OrderLine>
                {
                    new OrderLine { ID = 5, Amount = 1, Product = p1},
                    new OrderLine { ID = 6 ,Amount = 10, Product = p2},
                }
            };
            return order;
        }

        public static void ExampleXMLAttributesToConfigureSerialization()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VIPOrder) });
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Order order = CreateOrder();
                serializer.Serialize(stringWriter, order);
                xml = stringWriter.ToString();
                Console.WriteLine(xml);
            }
            using (StringReader stringReader = new StringReader(xml))
            {
                Order o = (Order)serializer.Deserialize(stringReader);
                // Use the order
            }
        }
    }
}
