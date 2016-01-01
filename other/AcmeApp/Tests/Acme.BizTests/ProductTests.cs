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

            var expected = "Hello Hammer (1): A sturdy tool" +
                           " Available on: ";

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

            var expected = "Hello Hammer (1): A sturdy tool" +
                           " Available on: ";

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

            var expected = "Hello Hammer (1): A sturdy tool" +
                           " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName; //If null then null; if not then dot.

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            //Arrange
            var expected = 78.74; //number of inches in 2 meters.

            //Act
            var actual = 2*Product.InchesPerMeter;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .95m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //Arrange
            var currentProduct = new Product(1, "Bulk tools", "");
            var expected = 7.75m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}