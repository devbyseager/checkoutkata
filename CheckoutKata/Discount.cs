using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Discount : IDiscount
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
    }
}
