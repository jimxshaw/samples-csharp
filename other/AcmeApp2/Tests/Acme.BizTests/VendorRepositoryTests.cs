﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueIntTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = 42;

            // Act
            var actual = repository.RetrieveValue<int>("Select...", 42);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = "default value";

            // Act
            var actual = repository.RetrieveValue("Select...", "default value");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            expected.Add(new Vendor() { CompanyName = "IBM", Email = "news@ibm.com", VendorId = 12345 });
            expected.Add(new Vendor() { CompanyName = "GE", Email = "investorservices@ge.com", VendorId = 54321 });

            // Act
            var actual = repository.Retrieve();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTestCollection()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            expected.Add(new Vendor() { CompanyName = "IBM", Email = "news@ibm.com", VendorId = 12345 });
            expected.Add(new Vendor() { CompanyName = "GE", Email = "investorservices@ge.com", VendorId = 54321 });

            // Act
            var actual = repository.RetrieveCollection();

            // Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveTestIterator()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();

            expected.Add(new Vendor() { CompanyName = "IBM", Email = "news@ibm.com", VendorId = 12345 });
            expected.Add(new Vendor() { CompanyName = "GE", Email = "investorservices@ge.com", VendorId = 54321 });

            // Act
            var vendorIterator = repository.RetrieveWithIterator();

            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }

            var actual = vendorIterator.ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveWithKeysTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                { "JP Morgan", new Vendor() { CompanyName = "JP Morgan", VendorId = 8, Email = "publicrelations@jpmorgan.com"} },
                { "Lockheed Martin", new Vendor() { CompanyName = "Lockheed Martin", VendorId = 10, Email = "investorservices@lockheed.com"} }
            };

            // Act
            var actual = repository.RetrieveWithKeys();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        //// A generic constraint has been placed on RetrieveValue<T> where T : struct. 
        //// Therefore, the below test is not allowed by definition because Vendor is 
        //// a reference type. 
        //[TestMethod()]
        //public void RetrieveValueObjectTest()
        //{
        //    // Arrange
        //    var repository = new VendorRepository();
        //    var vendor = new Vendor();
        //    var expected = vendor;

        //    // Act
        //    var actual = repository.RetrieveValue<Vendor>("Select...", vendor);

        //    // Assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}