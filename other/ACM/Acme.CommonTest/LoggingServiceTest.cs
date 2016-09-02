using ACM.BL;
using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Acme.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            // Arrange
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                FirstName = "John",
                LastName = "Lennon",
                EmailAddress = "johnlennon@beatles.com",
                AddressList = null
            };

            var product = new Product()
            {
                ProductName = "Guitar",
                CurrentPrice = 399.99M,
                ProductDescription = "Gibson Les Paul"
            };

            changedItems.Add(customer as ILoggable);
            changedItems.Add(product as ILoggable);


            // Act
            LoggingService.WriteToFile(changedItems);

            // Assert
            // Nothing to assert in this case.
        }
    }
}
