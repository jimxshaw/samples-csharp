using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                                     "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12);

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceOrder_3Parameters()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                "\r\nDeliver By: 10/25/2018" +
                "\r\nInstructions: standard delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                new DateTimeOffset(2018, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_Exception()
        {
            // Arrange
            var vendor = new Vendor();

            // Act
            var actual = vendor.PlaceOrder(null, 12);

            // Assert
            // Expected exception
        }

        [TestMethod()]
        public void PlaceOrder_NoDeliveryDate()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult<bool>(true,
                        "Order from Acme, Inc\r\nProduct: Saw\r\nQuantity: 12" +
                        "\r\nInstructions: Deliver to Suite 42");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                                instructions: "Deliver to Suite 42");

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp (1)";

            // Act
            var actual = vendor.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestList()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendors = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: IBM",
                "Message sent: Important message for: GE"
            };
            Console.WriteLine(vendors.Count);

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestCollectionList()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.RetrieveCollection();
            var expected = new List<string>()
            {
                "Message sent: Important message for: IBM",
                "Message sent: Important message for: GE"
            };
            var vendors = vendorsCollection.ToList();
            Console.WriteLine(vendors.Count);

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestAdd()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.RetrieveCollection(); // Collection has 2 items.
            vendorsCollection.Add(new Vendor() {CompanyName = "NBC", Email = "nbc@nbc.com", VendorId = 25});

            // The returned collection is MUTABLE, meaning after we add a new vendor to the vendorRepository 
            // and then retrieve the same collection, that collection would have increased by 1. 
            var vendorsCollectionMaster = vendorRepository.RetrieveCollection(); // Collection now has 3 items. 

            // Prevent changes to the collection, .RetrieveCollection() would need to return IEnumerable<T> 
            // instead of ICollection<T>. IEnumerable<T> collections can only be enumerated, not modified 
            // because they're readonly.

            var expected = new List<string>()
            {
                "Message sent: Important message for: IBM",
                "Message sent: Important message for: GE",
                "Message sent: Important message for: NBC",
            };
            var vendors = vendorsCollection.ToList();
            Console.WriteLine(vendors.Count);

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestArray()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendors = vendorRepository.RetrieveArray();
            var expected = new List<string>()
            {
                "Message sent: Important message for: Disney",
                "Message sent: Important message for: Google"
            };
            Console.WriteLine(vendors.Length);

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestCollectionArray()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.RetrieveCollection();
            var expected = new List<string>()
            {
                "Message sent: Important message for: IBM",
                "Message sent: Important message for: GE"
            };
            // Since .RetrieveCollection() returns an ICollection<Vendor>, we 
            // must cast it in order for us to use vendorsCollection as an Array.
            var vendors = vendorsCollection.ToArray();
            Console.WriteLine(vendors.Length);

            // Act
            var actual = Vendor.SendEmail(vendors, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestDictionary()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendors = vendorRepository.RetrieveWithKeys();
            var expected = new List<string>()
            {
                "Message sent: Important message for: JP Morgan",
                "Message sent: Important message for: Lockheed Martin"
            };

            // Act
            var actual = Vendor.SendEmail(vendors.Values, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestCollectionDictionary()
        {
            // Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.RetrieveCollection();
            var expected = new List<string>()
            {
                "Message sent: Important message for: IBM",
                "Message sent: Important message for: GE"
            };
            // When casting a collection to a dictionary, we must give .ToDictionary() 
            // a key-selector function argument to extract the keys for the dictionary. 
            // In this case, we want to use the company name as the key. The lambda 
            // expression says for every item v in the collection, use the company name 
            // as the key.  
            var vendors = vendorsCollection.ToDictionary(v => v.CompanyName);

            // Act
            var actual = Vendor.SendEmail(vendors.Values, "Test Message");

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}