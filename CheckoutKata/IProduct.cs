using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public interface IProduct
    {
        string SKU { get; set; }
        int Price { get; set; }
    }
}
