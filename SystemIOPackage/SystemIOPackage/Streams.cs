using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOPackage
{
    public class Streams
    {
        public static void Example()
        {
            string path = @"c:\temp\test.dat";

            using (FileStream fileStream = File.Create(path))
            {
                string myValue = "MyValue";
                //The process of converting characters into bytes 
                // (and the other way around) is called encoding and decoding. 
                // System.Text.Encoding class that convert betweens bytes and strings. 
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                fileStream.Write(data, 0, data.Length);
            }
        }

        // Using File.CreateText with a StreamWriter 
        public static void ExampleFileCreate()
        {
            string path = @"c:\temp\test.dat";

            using (StreamWriter streamWriter = File.CreateText(path))
            {
                string myValue = "MyValue";
                streamWriter.Write(myValue);
            }
        }

        public static void ExampleReadFromStream()
        {
            string path = @"c:\temp\test.dat";
            using (FileStream fileStream = File.OpenRead(path))
            {
                byte[] data = new byte[fileStream.Length];
                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data)); // Displays: MyValue

            }
        }


        // The StreamReader uses a default encoding and returns the bytes to you as a string 
        public static void ExampleStreamReader()
        {
            string path = @"c:\temp\test.dat";
            using (StreamReader streamWriter = File.OpenText(path))
            {
                Console.WriteLine(streamWriter.ReadLine()); // Displays: MyValue 
            }

        }
        //Streams support decorrator  
        //  (you can pass one stream object as constructor param to another)
        public static void ExampleStreamGZipStreamAndPypingStreams()
        {
            string folder = @"c:\temp";
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
            string compressedFilePath = Path.Combine(folder, "compressed.gz");
            byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();
            using (FileStream uncompressedFileStream = File.Create(uncompressedFilePath))
            {
                uncompressedFileStream.Write(dataToCompress, 0, dataToCompress.Length);
            }
            using (FileStream compressedFileStream = File.Create(compressedFilePath))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    compressionStream.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }

            FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
            FileInfo compressedFile = new FileInfo(compressedFilePath);

            Console.WriteLine(uncompressedFile.Length); // Displays 1048576 
            Console.WriteLine(compressedFile.Length); // Displays 1052
        }

        public static void ExampleStreamBuffer()
        {
            string path = @"c:\temp\bufferedStream.txt";

            using (FileStream fileStream = File.Create(path))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamWriter streamWriter = new StreamWriter(bufferedStream))
                    {
                        streamWriter.WriteLine("A line of text.");
                    }
                }
            }
        }

        public static String ExampleOfDefenciveProgramming()
        {
            string path = @"C:\temp\test.txt";

            try
            {
                return File.ReadAllText(path);
            }
            catch (DirectoryNotFoundException) { }
            catch (FileNotFoundException) { }
            return string.Empty;
        }
    }
}
