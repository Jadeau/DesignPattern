using Strategy.Models;

namespace Strategy.Strategies.TaxServices
{
    public interface ISaleTaxStrategy
    {
        public decimal GetTax(Order order);
    }
}
