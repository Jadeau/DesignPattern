using Strategy.Strategies.TaxServices;
using System.Collections.Generic;

namespace Strategy.Models
{
    public class Order
    {
        public ShippingDetails ShippingDetails { get; set; }
        public ISaleTaxStrategy TaxStrategy { get; set; }
        public List<Item> Items { get; set; }

        public decimal GetTax()
        {
            if(TaxStrategy == null)
            {
                return 0;
            }
            return TaxStrategy.GetTax(this);
        }
    }

    public class ShippingDetails
    {
        public ShippingDetails(Country origin, Country destination)
        {
            OriginCountry = origin;
            DestinationCountry = destination;
        }
        public Country OriginCountry { get; set; }
        public Country DestinationCountry { get; set; }
    }

    public class Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public Product(string name, decimal price, ProductType type)
        {
            Name = name;
            Price = price;
            ProductType = type;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        Service,          // VN 20%    US 10%
        Book,             // VN 10%    US 5% 
        Food,             // VN 5%     US 20%
        ElectronicDevice  // VN 40%    US 50% 
    }
    public enum Country
    {
        VN,               //10%
        US                //15%
    }
}
