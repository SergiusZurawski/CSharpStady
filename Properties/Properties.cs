using System;
using System.Threading;
using System.Threading.Tasks;

namespace Properties
{
   public class ProductC1
    {
    //Public getters , means public setters
    string name;
    public string Name { get { return name; } }

    decimal price;
    public decimal Price { get { return price; } }
    
    public Product(string name, decimal price)
    {
        this.name = name;
        this.price = price;
        }
        public static ArrayList GetSampleProducts()
        {
            //ArrayList is not Parametrised. YOu can add anything
            ArrayList list = new ArrayList();
            list.Add(new Product("West Side Story", 9.99m));
            list.Add(new Product("Assassins", 14.99m));
            list.Add(new Product("Frogs", 13.99m));
            list.Add(new Product("Sweeney Todd", 10.99m));
            return list;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }

    public class ProductC2
    {
        //Properties, getters public , setters private
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

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public static List<Product> GetSampleProducts()
        {
            //Strongly typed collections
            List<Product> list = new List<Product>();
            list.Add(new Product("West Side Story", 9.99m));
            list.Add(new Product("Assassins", 14.99m));
            list.Add(new Product("Frogs", 13.99m));
            list.Add(new Product("Sweeney Todd", 10.99m));
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
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        Product() {}

        public static List<Product> GetSampleProducts()
        {
            //simpler initialization
            return new List<Product>
            {
                new Product { Name="West Side Story", Price = 9.99m },
                new Product { Name="Assassins", Price=14.99m },
                new Product { Name="Frogs", Price=13.99m },
                new Product { Name="Sweeney Todd", Price=10.99m}
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
        
        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                //Named arguments
                new Product( name: "West Side Story", price: 9.99m),
                new Product( name: "Assassins", price: 14.99m),
                new Product( name: "Frogs", price: 13.99m),
                new Product( name: "Sweeney Todd", price: 10.99m)
            };
        }
        
        public override string ToString()
        {
            return string.Format("{0}: {1}", name, price);
        }
    }
}
