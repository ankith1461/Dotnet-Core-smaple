using System;
using Newtonsoft.Json;

namespace MyAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Searialisation and desearialisation!");
            var json = DoSerialization();
            System.Console.WriteLine(json);
            System.Console.WriteLine("================");
            DoDeserialization(json);
            System.Console.WriteLine("================");
            DoDeserialization1(json);
        }

        public static string DoSerialization() 
        {
                Product[] products = {
                new Product{ ID = 0, Name = "NASA", Price=7.8},
                new Product{ ID = 1, Name = "NASA1", Price=8.8},
                new Product{ ID = 2, Name = "NASA2", Price=9.8},
            };
            var json = JsonConvert.SerializeObject(products);
            return json;
        }

        // Deserialize a JSON string back to a Product array
        public static void DoDeserialization(string json) 
        {
            var products = JsonConvert.DeserializeObject<Product[]>(json);
            foreach (var r in products) 
            {
                System.Console.WriteLine($"ID:{r.ID} Name:{r.Name} Price:{r.Price} ");
            }
        }
        // Deserialize a JSON string back to a MiniProduct array
        public static void DoDeserialization1(string json) 
        {
            var products = JsonConvert.DeserializeObject<MiniProduct[]>(json);
            foreach (var r in products) 
            {
                System.Console.WriteLine($"ID:{r.ID} Name:{r.Name}");
            }
        }
    }
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class MiniProduct {
        public string ID { get; set; }
        public double Name { get; set; }
    }
}
