using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private IEnumerable<IProduct> _products;
        private IEnumerable<IDiscount> _discounts;
        private List<string> _scannedItems;
       

        public Checkout(IEnumerable<IProduct> products, IEnumerable<IDiscount> discounts, List<string> scannedItems)
        {
            _products = products;
            _discounts = discounts;
            _scannedItems = scannedItems;
        }

        public int GetTotalPrice()
        {
            int total = 0;
            int totalDiscount = 0;

            total = _scannedItems.Sum(item => PriceFor(item));
            totalDiscount = _discounts.Sum(discount => CalculateDiscount(discount, _scannedItems));
            return total - totalDiscount;
        }

        public void Scan(string item)
        {
           if(!string.IsNullOrEmpty(item) && _products.Any(p => p.SKU == item))
            {
                _scannedItems.Add(item);
            }
        }

        private int PriceFor(string sku)
        {
            return _products.Single(p => p.SKU == sku).Price;
        }

        private int CalculateDiscount(IDiscount discount, List<string> checkout)
        {
            int itemCount = checkout.Count(item => item == discount.SKU);
            return (itemCount / discount.Quantity) * discount.Value;
        }

    }
}
