using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void RetrieveAllTest()
        {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>()
            {
                new Vendor()
                {
                    VendorId = 10, CompanyName = "Amazon", Email = "amazon@amazon.net"
                },
                new Vendor()
                {
                    VendorId = 69, CompanyName = "ESPN", Email = "espn@espn.net"
                },
                new Vendor()
                {
                    VendorId = 82, CompanyName = "Uber", Email = "uber@uber.net"
                }
            };

            // Actual
            var vendors = repository.RetrieveAll();

            //var vendorQuery = from v in vendors
            //                  where v.Email.Contains(".net")
            //                  orderby v.CompanyName
            //                  select v;

            // LINQ methods such as Where takes in a delegate as the argument. The delegate 
            // must be in the form of Func<Vendor, bool>, where Vendor is the parameter and 
            // bool is the return type. To test this, we wrote a private method called 
            // FilterCompanies and inserted into LINQ's Where method.  
            var vendorQuery = vendors.Where(FilterCompanies)
                            .OrderBy(OrderCompaniesByName);

            // Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        // Since this method's body consists of 1 line, the return statement, we can use 
        // C# 6's lambda fat arrow syntax.  
        private bool FilterCompanies(Vendor v) => v.Email.Contains(".net");

        private string OrderCompaniesByName(Vendor v) => v.CompanyName;

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