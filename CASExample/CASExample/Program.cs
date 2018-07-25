using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CASExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public static void ExampleDeclarativeCAS()
        {     // Method body }

        }


        public static void ExampleImperitiveCAS()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try {
                f.Demand();
            } catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
        }


        /* Secure String
            ■ The string value can be moved around in memory by the garbage collector 
                    leaving multiple copies around. 
            ■■ The string value is not encrypted. If you run low on memory, 
                    it could be that your string is written as plain text to a page file on disk. 
                    The same could happen when your application crashes and a memory dump is made. 
            ■■ System.String is immutable. Each change will make a copy of the data, 
                    leaving multiple copies around in memory. 
            ■■ It’s impossible to force the garbage collector to remove all copies of your 
                    string from memory. 
        */
        public static void ExampleSecureString()
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Pleaseenterpassword:");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                        break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                ss.MakeReadOnly();
            }

        }

        // clearing string from memory as soon as possible
        public static void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
                finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        /* Methods for working with SecureString
            Decrypt method                   Clear memory method
            SecureStringToBSTR               ZeroFreeBSTR
            SecureStringToCoTaskMemAnsi      ZeroFreeCoTaskMemAnsi
            SecureStringToCoTaskMemUnicode   ZeroFreeCoTaskMemUnicode
            SecureStringToGlobalAllocAnsi    ZeroFreeGlobalAllocAnsi
            SecureStringToGlobalAllocUnicode ZeroFreeGlobalAllocUnicode 
         
         */

    }
}
