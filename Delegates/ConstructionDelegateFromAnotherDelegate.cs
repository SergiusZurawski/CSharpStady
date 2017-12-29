using ExampleVarianceDelegate;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
   

    public class ConstructionDelegateFromAnotherDelegate
    {

        // Covaricance of Return Type. Despite the fact that delegate StreamFactory is 
        //     expecting 'Stream' as return type , we provide method with 'MemoryStream'
        static StreamFactory factory = CovaricanceExempleClass.GenerateSampleData;

        public static void Example()
        {
            using (Stream stream = factory())
            {
                int data;
                while ((data = stream.ReadByte()) != -1)
                {
                    Console.WriteLine(data);
                }
            }
        }
    }
}

