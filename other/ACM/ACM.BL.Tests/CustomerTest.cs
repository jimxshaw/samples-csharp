using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            // Arrange
            var customer = new Customer();
            customer.FirstName = "Thomas";
            customer.LastName = "Jefferson";

            var expected = "Jefferson, Thomas";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FirstNameTestValid()
        {
            // Arrange
            var customer = new Customer();
            customer.FirstName = "Thomas";

            var expected = "Thomas";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LastNameTestValid()
        {
            // Arrange
            var customer = new Customer();
            customer.LastName = "Jefferson";

            var expected = "Jefferson";

            // Act
            var actual = customer.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            // Arrange
            var c1 = new Customer();
            c1.FirstName = "James";
            Customer.InstanceCount += 1;

            var c2 = new Customer();
            c2.FirstName = "John";
            Customer.InstanceCount += 1;

            var c3 = new Customer();
            c3.FirstName = "George";
            Customer.InstanceCount += 1;

            var expected = 3;

            // Act
            var actual = Customer.InstanceCount;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
