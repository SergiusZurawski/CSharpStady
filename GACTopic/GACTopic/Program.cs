using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACTopic
{
    class Program
    {
        /*
            In order to install in GAC use - Windows Installer 2.0.
            Localy -  Global Assembly Cache tool (Gacutil.exe). 

            View the content of your GAC 
            gacutil -l

            Asembly Versioning is done via two properties:
            [assembly: AssemblyVersion(“1.0.0.0”)] - AssemblyFileVersionAttribute is the one that should be incremented with each build.
            [assembly: AssemblyFileVersion(“1.0.0.0”)] -AssemblyFileVersionAttribute should be incremented manually
            (Manual Delploy in production).

             side-by-side hosting -multiple versions of an assembly are hosted together on one computer(GAC including).

            Three configuration files are used: 
                ■■ Application configuration files 
                ■■ Publisher policy files  (For example This file instructs the CLR to bind to version 2 of the assembly instead of version 1. )
                ■■ Machine configuration files 

        */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        
    }
}
