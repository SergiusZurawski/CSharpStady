using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SystemIOPackage
{
    public class DirrectoryInfo
    {
        public static void Example()
        {
            if (Directory.Exists(@"C:\Temp\ProgrammingInCSharp\Directory"))
            {
                Directory.Delete(@"C:\Temp\ProgrammingInCSharp\Directory");
            }

            var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete();
            }

        }

        public static void ExampleGraningAccess()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("TestDirectory");
            directoryInfo.Create();
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);

        }

        public static void ExampleSerchingForDirrectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files"); ListDirectories(directoryInfo, "*a*", 5, 0);

        }

        public static void ExampleMovingDirrectory()
        {
            Directory.Move(@"C:\source", @"c:\destination");
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Source");
            directoryInfo.MoveTo(@"C:\destination");
        }


        //Directory.GetFiles(string path)  -  function returns an array of strings, 
        //DirectoryInfo.GetFiles()         -  returns an array of FileInfo objects. 
        public static void ExampleRetrivingFiles()
        {
            foreach (string file in Directory.GetFiles(@"C:\Windows"))
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("-----------------------");
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                Console.WriteLine(fileInfo.FullName);
            }

        }

        public static void ExampleDelitingFiles()
        {
            string path = @"c:\temp\test.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

        }

        public static void ExampleMovingFiles()
        {
            string path = @"c:\temp\test.txt";
            string destPath = @"c:\temp\destTest.txt";

            File.CreateText(path).Close();
            File.Move(path, destPath);

            FileInfo fileInfo = new FileInfo(path);
            fileInfo.MoveTo(destPath);

        }

        private static void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }

            string indent = new string('-', currentLevel);

            try
            {
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // You don't have access to this folder. 
                Console.WriteLine(indent + "Can't access: " + directoryInfo.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                // The folder is removed while iterating
                Console.WriteLine(indent + "Can't find: " + directoryInfo.Name);
                return;
            }
        }
    }
}
