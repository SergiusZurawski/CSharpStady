using System;
using System.Collections;
///  System.Collections - All collections Non Generic
///  System.Collections.Generic - All collections  Generic
///  System.Collections.Concurrent - All Concurent Collections
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class CollectionFramework
    {
        //Anonimus Types
        public static void ExampleAnonimusTypes()
        {
            var a = new { Name = "a", Age="1"};
            var b = new {Name = "c", Age = "2"};
            a = b;
            var z = new {Age = "1", Name = "z"};
            //a = z; 
            
            //Not strongly type
            var x = new {Age = "1", Skils = new ArrayList()
                            {
                                new Tuple<string, string>("", ""),
                                new {SkillName = "Programming", Efficenty = "Good"},
                                new {SkillName = "Programming", Efficenty = "Good"},
                                new {Skillrate = 1, Somehting = "Good"}
                                    
                            }
                        };
            
            //Strongly typed
//            var s = new 
//            { 
//                 Name= "sergii",  SkillSet = new List<Tuple<String,String>>()
//                {
//                    new Tuple<String,String>("", ""),
//                    new Tuple<String,int("", 1),
//                    new {SkillName = "Programming", Efficenty = "Good"},
//                }
//            };
        }
        
        // Arrays Initialization
        public static void ExampleOfArrays()
        {
            String[] array1 = new String[10];
            array1 = new String[11];
            array1 = new String[] { "", "2", "3" };
            String[][] array2 = new String[2][];
            array2 = new String[2][]
            {
                new String[]{"1","",""},
                new String[]{"2", "", ""}
                
            };
            // jaggedArray  arrays
            
            String[][] array3 = {
                new String[]{"1","",""},
                new String[]{"2", "", ""}
                
            };
            
            // Matrix
            String[,] array4 = new string[2,3];

            String[,] array5 =
            {
                new String[] {"1", "", ""},
                new String[] {"2", "", ""}
            };


        }

    }
}
