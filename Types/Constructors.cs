using System;
using System.Collections.Generic;
using System.Linq;

namespace Types
{
    ///   By default, each class has an empty constructor that can be called. 
    ///   You can also define your own constructors. You do this for two reasons: 
    ///   ■■ To initialize the type with data 
    ///   ■■ To run some initialization code 

    public class Constructors
    {

        /*
         
        good practices when designing your constructors are these: 
        ■■ Explicitly declare the public default construct in classes if such a constructor is required. 
        ■■ Ensure that your constructor takes as few parameters as possible. 
        ■■ Map constructor parameters to properties in your class. 
        ■■ Throw exceptions from instance constructors if appropriate. 
        ■■ Do not call virtual members from an object inside its constructor
          
         */

        private int _p;

        public Constructors() : this(3) { }
        public Constructors(int p) { this._p = p; }

        public static void Example()
        {
            //Optional parameters
           

        }
    }

}
