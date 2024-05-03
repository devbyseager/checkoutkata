using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutTests
    {

        private ICheckout _checkout;
        private IEnumerable<IProduct> _products;
        private IEnumerable<IDiscount> _discounts;
        List<string> _scanneditems;

        [TestInitialize]
        public void Setup()
        {
            _products = new List<Product>() { new() { SKU = "A", Price = 50 }, new() { SKU = "B", Price = 30 } , new() { SKU = "C", Price = 20 }, new() { SKU = "D", Price = 15 } };
            _discounts = new List<Discount>() { new() { SKU = "A", Quantity = 3, Value = 20 }, new() { SKU = "B", Quantity = 2, Value = 15 } };
            _scanneditems = new List<string>();

            _checkout = new Checkout(_products, _discounts, _scanneditems);
        }

        [TestMethod]
        public void Add_AddingItemToEmptyCheckout()
        {       
            _checkout.Scan("A");

            Assert.AreEqual(50, _checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Add_AddingMultipleItemsToEmptyCheckout()
        {
            _checkout.Scan("C");
            _checkout.Scan("D");

            Assert.AreEqual(35, _checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Add_AddingMultipleItemsInAnyOrder()
        {
            _checkout.Scan("C");
            _checkout.Scan("D");
            _checkout.Scan("C");

            Assert.AreEqual(55, _checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Add_AddMultipleSpecialItemsAndGetSpecialPrice()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("A");

            Assert.AreEqual(130, _checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Add_AddingMultipleSpecialItemsInAnyOrder()
        {
            _checkout.Scan("A");
            _checkout.Scan("A");
            _checkout.Scan("D");
            _checkout.Scan("A");

            Assert.AreEqual(145, _checkout.GetTotalPrice());
        }
    }
}
