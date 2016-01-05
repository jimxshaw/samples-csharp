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
            var vender = new Vendor();
            var product = new Product(1, "Hammer", "");
            var expected = new OperationResult(true,
                                "Order from ACME, Inc\nProduct: Tools-1\nQuantity: 1");

            // Act
            var actual = vender.PlaceOrder(product, 1);

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderTest_NullProduct_Exception()
        {
            // Arrange
            var vender = new Vendor();

            // Act
            var actual = vender.PlaceOrder(null, 12);

            // Assert
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrderTest_ImproperQuantity_Exception()
        {
            // Arrange
            var vender = new Vendor();

            // Act
            var actual = vender.PlaceOrder(new Product(1, "Hammer", ""), 0);

            // Assert
        }

        [TestMethod()]
        public void PlaceOrder_3Parameters()
        {
            // Arrange
            var vender = new Vendor();
            var product = new Product(1, "Hammer", "");
            var expected = new OperationResult(true,
                            "Order from ACME, Inc\nProduct: Tools-1\nQuantity: 1" +
                            "\nInstructions: standard delivery");

            // Act
            var actual = vender.PlaceOrder(product, 1, instructions: "standard delivery");

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Hammer", "");
            var expected = new OperationResult(true, "Test with Address");

            // Act
            var actual = vendor.PlaceOrder(product, 12,
                                            Vendor.IncludeAddress.Yes,
                                            Vendor.SendCopy.No);

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "XYZ Corp";

            var expected = "Vendor: XYZ Corp";

            // Act
            var actual = vendor.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}