using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace IOExamples
{
   
    public class SerializationToByte
    {
        private static string pathSourceFile = "source.dat"; 
        private static string pathHeaderFile = "header.dat"; 
        private static string pathBodyFile = "body.dat";

        public static void SericalizeTwoParts()
        {
            using (FileStream fsSource = File.OpenRead(pathSourceFile))
            using (FileStream fsHeaderFile = new FileStream(pathHeaderFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            using (FileStream fsBodyFile = new FileStream(pathBodyFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
            {
                byte [] header = new byte[20];
                byte [] body = new byte[fsSource.Length];
                fsSource.Read(header, 0, header.Length);
                fsHeaderFile.Write(header, 0, header.Length);
                fsSource.Read(body, 0, body.Length);
                fsBodyFile.Write(body, 99, body.Length-99);
            }
        }
    }

}