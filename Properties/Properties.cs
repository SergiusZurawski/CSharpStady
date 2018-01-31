using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Properties
{
   public class ProductC1
    {
    //Public getters , means public setters
    string name;
    public string Name { get { return name; } }

    decimal price;
    public decimal Price { get { return price; } }
    
    public ProductC1(string name, decimal price)
    {
        this.name = name;
        this.price = price;
        }
        public static ArrayList GetSampleProducts()
        {
            //ArrayList is not Parametrised. YOu can add anything
            ArrayList list = new ArrayList();
            list.Add(new ProductC1("West Side Story", 9.99m));
            list.Add(new ProductC1("Assassins", 14.99m));
            list.Add(new ProductC1("Frogs", 13.99m));
            list.Add(new ProductC1("Sweeney Todd", 10.99m));
            return list;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }

    public class ProductC2
    {
        // Properties, getters public , setters private
        // if you don’t specify anything, the default is to give the getter or setter the same access as the overall property itself.
        // You can’t declare the property itself to be private and make the getter public—you can only make a particular getter or setter more private than the property.
        // you can’t specify an access modifier for both the getter and the setter—that. (you could declare the property itself to be whichever is the more public of the two modifiers.)
        string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        decimal price;
        public decimal Price
        {
            get { return price; }
            private set { price = value; }
        }

        public ProductC2(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static List<ProductC2> GetSampleProducts()
        {
            //Strongly typed collections
            List<ProductC2> list = new List<ProductC2>();
            list.Add(new ProductC2("West Side Story", 9.99m));
            list.Add(new ProductC2("Assassins", 14.99m));
            list.Add(new ProductC2("Frogs", 13.99m));
            list.Add(new ProductC2("Sweeney Todd", 10.99m));
            return list;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }

    class ProductC3
    {
        //Automatically implemented properties
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public ProductC3(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        ProductC3() {}

        public static List<ProductC3> GetSampleProducts()
        {
            //simpler initialization
            return new List<ProductC3>
            {
                new ProductC3 { Name="West Side Story", Price = 9.99m },
                new ProductC3 { Name="Assassins", Price=14.99m },
                new ProductC3 { Name="Frogs", Price=13.99m },
                new ProductC3 { Name="Sweeney Todd", Price=10.99m}
            };
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", Name, Price);
        }
    }

    public class ProductC4
    {
        readonly string name;
        public string Name { get { return name; } }
        
        readonly decimal price;
        public decimal Price { get { return price; } }
        
        public ProductC4(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public static List<ProductC4> GetSampleProducts()
        {
            return new List<ProductC4>
            {
                //Named arguments
                new ProductC4( name: "West Side Story", price: 9.99m),
                new ProductC4( name: "Assassins", price: 14.99m),
                new ProductC4( name: "Frogs", price: 13.99m),
                new ProductC4( name: "Sweeney Todd", price: 10.99m)
            };
        }
        
        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }
}
