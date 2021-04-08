using Strategy.Models;
using Strategy.Services;
using Strategy.Strategies.TaxServices;
using System;
using System.Collections.Generic;

namespace Strategy
{
    /// <summary>
    ///  Usages: Use the Strategy pattern when you want to use different variants of an algorithm within an object and be able to switch from one algorithm to another during runtime.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>();
            var order1 = new Order()
            {
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Product = new Product("Harry Potter 1", 39.9m, ProductType.Book),
                        Quantity = 1
                    },
                    new Item()
                    {
                        Product = new Product("Coca Cola", 1, ProductType.Food),
                        Quantity = 1
                    }
                },
                ShippingDetails = new ShippingDetails(Country.VN, Country.US),
                TaxStrategy = new UsaSaleTaxCalculationStrategy()
            };
            var order2 = new Order()
            {
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Product = new Product("Iphone 12 Pro Max 256GB",1499, ProductType.ElectronicDevice),
                        Quantity = 1
                    }
                },
                ShippingDetails = new ShippingDetails(Country.VN, Country.VN),
                TaxStrategy = new VietnamSaleTaxStrategy()
            };
            orders.Add(order1);
            orders.Add(order2);
            for (var i = 0; i < orders.Count; i++)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("Order {0}:", i + 1);
                //Console.WriteLine("Product\t\t\t\tType\t\t\t\tPrice\tQuantity\tValue");
                foreach (var item in orders[i].Items)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", item.Product.Name, item.Product.ProductType.ToString(), item.Product.Price,
                        item.Quantity, (item.Quantity * item.Product.Price));
                }
                Console.WriteLine("Ship from {0} to {1}", orders[i].ShippingDetails.OriginCountry.ToString(), orders[i].ShippingDetails.DestinationCountry.ToString());
                Console.WriteLine("Tax for order {0} is {1}", i + 1, orders[i].GetTax());
                if(orders[i].ShippingDetails.DestinationCountry == Country.US)
                {
                    Console.WriteLine("Tax for order {0} is {1}", i + 1, orders[i].GetTax());
                }
                else
                {
                    Console.WriteLine("Tax for order {0} is {1}", i + 1, orders[i].GetTax());
                }
                Console.WriteLine("========================================================================");
            }
        }
    }
}
