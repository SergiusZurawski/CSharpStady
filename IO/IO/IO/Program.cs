using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace IOExamples
{
    class Program
    {
        private static string strFilePath = "somename.xml";  
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestRegexp();
            //SerializationExample();
        }

       
        public static void FileAccess()
        {
            var fs = File.Open("demo.txt.txt",FileMode.OpenOrCreate, System.IO.FileAccess.Read, FileShare.ReadWrite);
        }
        
        public static void SerializationExample()
        {
            Record r = new Record(1.1, "Aha");
            Console.WriteLine("Original record: {0}", r.ToString());  
            MemoryStream stream1 = new MemoryStream(); 
            FileStream fs = new FileStream(strFilePath, FileMode.Create, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite);
            
  
//Serialize the Record object to a memory stream using DataContractSerializer.  
            DataContractSerializer serializer = new DataContractSerializer(typeof(Record));  
            serializer.WriteObject(fs, r); 
            fs.Close();
            FileStream fs2 = new FileStream(strFilePath, FileMode.Open, System.IO.FileAccess.Read,  FileShare.ReadWrite);
            Record record2 = (Record)serializer.ReadObject(fs2);  
  
            Console.WriteLine("Deserialized record: {0}", record2.ToString());  
        }
        
        private static void TestRegexp()
        {
            string reg = "[0-9]+";
            Regex regex = new Regex(reg, RegexOptions.Compiled);
            Match match = regex.Match("Dot 55 perls 66");
            var a = match.Groups;
            var b = match.Captures;
            var c = match.Value;
            Console.WriteLine(a[0].Captures[0].Value);
            Console.WriteLine(b[0].Value);
            Console.WriteLine(c);
            var matheces = regex.Matches("Dot 55 perls 66");
        }

    }

    [DataContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    internal class Record
    {
        private double n1;
        private string operation;

        internal Record(double n1,  string operation)
        {
            this.n1 = n1;
            this.operation = operation;
        }

        [DataMember]
        internal double OperandNumberOne
        {
            get => n1;
            set => n1 = value;
        }
        
        [DataMember(Order = 10)]
        internal string Operanion
        {
            get => operation;
            set => operation = value;
        }
        public override string ToString()  
        {  
            return string.Format("Record: {0} {1}", n1, operation);  
        }  
    }
    
    
}