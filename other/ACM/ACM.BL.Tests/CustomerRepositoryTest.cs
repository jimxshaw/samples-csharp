using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveExisting()
        {
            // Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "samwisegamgee@hobbiton.me",
                FirstName = "Samwise",
                LastName = "Gamgee"
            };

            // Act
            var actual = customerRepository.Retrieve(1);

            // Assert
            //We cannot compare to two objects because each is a distinct instance.
            //Assert.AreEqual(expected, actual);

            //Each object's property value is compared instead.
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
        }
    }
}
