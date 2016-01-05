using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            var actual = 2 * Product.InchesPerMeter;

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

        [TestMethod()]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = " Hedgeclipper ";

            var expected = "Hedgeclipper";

            //Act
            var actual = currentProduct.ProductName;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "ax";

            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Cruel Colossus Blade of the Whale";

            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_JustRight()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Scissors";

            string expected = "Scissors";
            string expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void Category_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();

            string expected = "Tools";


            //Act
            var actual = currentProduct.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Category_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";

            string expected = "Garden";


            //Act
            var actual = currentProduct.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sequence_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();

            int expected = 1;


            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Category = "Smithing";
            currentProduct.SequenceNumber = 3;

            var expected = "Smithing-3";
            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            //Arrange
            var currentProduct = new Product(1, "Hammer", "");
            currentProduct.Cost = 100m;

            var expected = 110m;

            //Act
            var actual = currentProduct.CalculateSuggestedPrice(10);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}