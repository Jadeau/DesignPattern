using Strategy.Models;
using System;

namespace Strategy.Strategies.TaxServices
{
    public class VietnamSaleTaxStrategy : ISaleTaxStrategy
    {
        private const decimal VATFoodTax = 0.05m;
        private const decimal VATElectronicDeviceTax = 0.4m;
        private const decimal VATBookTax = 0.1m;
        private const decimal VATServiceTax = 0.2m;
        private const decimal ImportTax = 0.1m;
        public decimal GetImportTax(Order order)
        {
            if (order.ShippingDetails.DestinationCountry != order.ShippingDetails.OriginCountry)
            {
                return (GetNetValue(order) * ImportTax);
            }
            return 0;
        }

        private decimal GetNetValue(Order order)
        {
            decimal result = 0;
            foreach (var item in order.Items)
            {
                result += (item.Quantity * item.Product.Price);
            }
            return result;
        }

        public decimal GetTax(Order order)
        {
            return GetVATTax(order) + GetImportTax(order);
        }

        public decimal GetVATTax(Order order)
        {
            decimal result = 0;
            foreach (var item in order.Items)
            {
                switch (item.Product.ProductType)
                {
                    case ProductType.Book:
                        result += (item.Quantity * item.Product.Price * VATBookTax);
                        break;
                    case ProductType.Service:
                        result += (item.Quantity * item.Product.Price * VATServiceTax);
                        break;
                    case ProductType.ElectronicDevice:
                        result += (item.Quantity * item.Product.Price * VATElectronicDeviceTax);
                        break;
                    case ProductType.Food:
                        result += (item.Quantity * item.Product.Price * VATFoodTax);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
