using System;
using System.Collections.Generic;
using System.Linq;

namespace Types
{
    ///  

    public class ParametersOperation
    {
        public static void Example()
        {
            //Optional parameters
            ShowOptionalParameters();
            ShowOptionalParameters(3);
            //ShowOptionalParameters("string1");  //Exception
            ShowOptionalParameters(1, "string1");

            //Named arguments
            ShowOptionalParameters(i:3);
            ShowOptionalParameters(s:"string");
            ShowOptionalParameters(s: "string", i: 3);

        }

        public static void ShowOptionalParameters(int i = 1, string s = "")
        {
            //
        }
    }

    class Card
    {
    }

    class Deck
    {
        public ICollection<Card> Cards
        { get; private set; }

        public Card this[int index] { get { return Cards.ElementAt(index); } }
        
    }

}
