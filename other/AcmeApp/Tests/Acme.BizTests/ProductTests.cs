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
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductId = 1;
            currentProduct.ProductName = "Hammer";
            currentProduct.Description = "A sturdy tool";
            currentProduct.ProductVendor.CompanyName = "XYZ Corporation";

            var expected = "Hello Hammer (1): A sturdy tool";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ParamterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Hammer", "A sturdy tool");

            var expected = "Hello Hammer (1): A sturdy tool";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_ObjectInitializer()
        {
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Hammer",
                Description = "A sturdy tool"
            };

            var expected = "Hello Hammer (1): A sturdy tool";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}