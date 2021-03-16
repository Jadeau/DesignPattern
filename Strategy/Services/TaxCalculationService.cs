using Strategy.Models;

namespace Strategy.Services
{
    public class TaxCalculationService
    {
        public decimal GetTax(Order order)
        {
            decimal result = 0;

            //VAT
            switch (order.ShippingDetails.DestinationCountry)
            {
                case Country.VN:
                    foreach (var item in order.Items)
                    {
                        switch (item.Product.ProductType)
                        {
                            case ProductType.Book:
                                result += (item.Quantity * item.Product.Price * 0.1m);
                                break;
                            case ProductType.Service:
                                result += (item.Quantity * item.Product.Price * 0.2m);
                                break;
                            case ProductType.ElectronicDevice:
                                result += (item.Quantity * item.Product.Price * 0.4m);
                                break;
                            case ProductType.Food:
                                result += (item.Quantity * item.Product.Price * 0.05m);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case Country.US:
                    foreach (var item in order.Items)
                    {
                        switch (item.Product.ProductType)
                        {
                            case ProductType.Book:
                                result += (item.Quantity * item.Product.Price * 0.05m);
                                break;
                            case ProductType.Service:
                                result += (item.Quantity * item.Product.Price * 0.1m);
                                break;
                            case ProductType.ElectronicDevice:
                                result += (item.Quantity * item.Product.Price * 0.5m);
                                break;
                            case ProductType.Food:
                                result += (item.Quantity * item.Product.Price * 0.2m);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            //Import Tax
            switch (order.ShippingDetails.DestinationCountry)
            {
                case Country.VN:
                    if(order.ShippingDetails.DestinationCountry != order.ShippingDetails.OriginCountry)
                    {
                        result += (GetOrderValue(order) * 0.1m);
                    }
                    break;
                case Country.US:
                    if (order.ShippingDetails.DestinationCountry != order.ShippingDetails.OriginCountry)
                    {
                        result += (GetOrderValue(order) * 0.15m);
                    }
                    break;
                default:
                    break;
            }

            return result;
        }

        private decimal GetOrderValue(Order order)
        {
            decimal result = 0;
            foreach(var item in order.Items)
            {
                result += (item.Quantity * item.Product.Price);
            }
            return result;
        }
    }
}
