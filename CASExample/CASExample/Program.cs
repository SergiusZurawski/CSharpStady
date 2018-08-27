using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;   //The System.Runtime.InteropServices namespace provides a wide variety of members that support COM interop and platform invoke services.
using System.Security;
using System.Security.Permissions;
using System.Net.NetworkCredentials;
using System.Text;
using System.Threading.Tasks;

namespace CASExample
{
    class Program
    {
		
		/*
			Code Access Security
				CAS policy – policy levels, code groups, and of course our old friend caspol.exe (CAS policy has been deprecate in v4)
				CAS enforcement – primarily the act of demanding and asserting permissions
				CAS permissions – granted by CAS policy or a host to set the level of operations that an application can perform
		*/
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
                //Marshal 	
                //Provides a collection of methods for allocating unmanaged memory, copying unmanaged memory blocks, and converting managed to unmanaged types, as well as other miscellaneous methods used when interacting with unmanaged code.
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
                finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }


        public static void ExampleOfConvertingToSecureStringAndBack()
        {
            string s = "pass";

            using (SecureString ss = new SecureString())
            {
                foreach (var a in s)
                {
                    ss.AppendChar(a);
                }


                IntPtr unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(ss);  //Copies the contents of a managed SecureString object into unmanaged memory
                var sback = Marshal.PtrToStringUni(unmanagedString);                    //Allocates a managed String and copies all characters up to the first null character from an unmanaged Unicode string into it.
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);                    //Frees an unmanaged string pointer that was allocated using the SecureStringToGlobalAllocUnicode(SecureString) method.

                Console.WriteLine(sback);
            }
        }

        public static void ExampleOfUsingNetworkCredentials()
        {
            SecureString theSecureString = new NetworkCredentials("", "myPass").SecurePassword;
            string theString = new NetworkCredential("", theSecureString).Password;
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
