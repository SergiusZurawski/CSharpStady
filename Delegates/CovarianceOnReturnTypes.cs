using ExampleVarianceDelegate;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates
{
   

    public class CovarianceOnReturnTypes
    {

        // Covaricance of Return Type. Despite the fact that delegate StreamFactory is 
        //     expecting 'Stream' as return type , we provide method with 'MemoryStream' as return method
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

namespace ExampleVarianceDelegate
{
    delegate Stream StreamFactory();

    class CovaricanceExempleClass
    {
        public static MemoryStream GenerateSampleData() {

            byte[] buffer = new byte[16];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte) i;
            }
            return new MemoryStream(buffer);
        }

    }
    
}
