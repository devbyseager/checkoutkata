using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutTests
    {

        private ICheckout _checkout;

        [TestInitialize]
        public void Setup()
        {
            _checkout = new Checkout();
        }

        [TestMethod]
        public void Add_AddingItemToEmptyCheckout()
        {
            var item = new CheckoutItem { Sku = "A", Price = 50 };

            _checkout.Add(item);

            Assert.AreEqual(1, _checkout.Count);
        }

        [TestMethod]
        public void Add_AddingMultipleItemsToEmptyCheckout()
        {
            var item1 = new CheckoutItem { Sku = "C", Price = 20 };
            var item2 = new CheckoutItem { Sku = "D", Price = 15 };

            _checkout.Add(item1);
            _checkout.Add(item2);

            Assert.AreEqual(2, _checkout.Count);
        }

        [TestMethod]
        public void Add_AddingMultipleItemsInAnyOrder()
        {
            var item1 = new CheckoutItem { Sku = "C", Price = 20 };
            var item2 = new CheckoutItem { Sku = "D", Price = 15 };
            var item3 = new CheckoutItem { Sku = "C", Price = 20 };

            _checkout.Add(item1);
            _checkout.Add(item2);
            _checkout.Add(item3);

            Assert.AreEqual(3, _checkout.Count);
            Assert.AreEqual(55, _checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Add_AddMultipleSpecialItemsAndGetSpecialPrice()
        {
            var item1 = new CheckoutItem { Sku = "A", Price = 50 };
            var item2 = new CheckoutItem { Sku = "A", Price = 50 };
            var item3 = new CheckoutItem { Sku = "A", Price = 50 };


            _checkout.Add(item1);
            _checkout.Add(item2);
            _checkout.Add(item3);

            Assert.AreEqual(130, _checkout.GetTotalPrice());
        }

        [TestMethod]
        public void Add_AddingMultipleSpecialItemsInAnyOrder()
        {
            var item1 = new CheckoutItem { Sku = "A", Price = 50 };
            var item2 = new CheckoutItem { Sku = "D", Price = 15 };
            var item3 = new CheckoutItem { Sku = "A", Price = 50 };
            var item4 = new CheckoutItem { Sku = "A", Price = 50 };

            _checkout.Add(item1);
            _checkout.Add(item2);
            _checkout.Add(item3);
            _checkout.Add(item4);

            Assert.AreEqual(145, _checkout.GetTotalPrice());
        }
    }
}
