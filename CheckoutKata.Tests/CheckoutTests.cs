﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutTests
    {

        private readonly ICheckout _checkout;

        public CheckoutTests(ICheckout checkout)
        {
            _checkout = checkout;
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
