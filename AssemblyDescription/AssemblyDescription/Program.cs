using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyDescription
{
    /*
        Assemblies are completely self-contained (no writting to regristry etc)
        Assemblies contain all the information they need to run(assembly’s manifest.)
        Assemblies is language-neutral(F# or Visual Basic). 
        assembly can be versioned(different versions of a specific assembly on one system without causing conflicts)

        

        Assembly contains 4 categoies of info:
            Assembly Manifest - The only mandatory. Describes what is inside. 
                                Makes assembly self-describing.
            Application Manifets - Provides info for the operating system.
                                   Deployment instructions and administrative elevation.
            Compiled Types - Compiled IL code of types. 
            Resourses - Images, Localizable txt, etc.
        
        types of assemblies: 
            strong-named assemblies 
            regular assemblies.
            
            both contain:
                metadata, 
                header, 
                manifest, 
                all the types that are in your assembly. 

        Strong-named assembly is signed with a public/private key pair 
                    that uniquely identifies the publisher of the assembly 
                    and the content of the assembly. 
                strong name consists:
                    simple text name of the assembly, 
                    its version number, 
                    culture information,
                    public key 
                    digital signature. 
        Benefits of strongly naming an assembly: 
                 Strong names guarantee uniqueness(Your unique private key is used to generate the name for your assembly).
                 Strong names protect your versioning lineage. ( you control the private key, you are the only one who can distribute updates to your assemblies.)
                 Strong names provide a strong integrity check. The .NET Framework sees whether a strong-named assembly has changed since the moment it was signed

        you have to generate  key pair (.snk extension that contains your public/private key information.)
        Developer Command prompt:
            sn -k myKey.snk
        Vs
            MyKeyGeneratedByVisualStudio.snk.pfx - password Qw123456
        
        !  strong-named assembly can reference only other assemblies that are also strongly named
                (So not signed assembly cannot change the behavoiur of strongly named assemblies). 
            

     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
