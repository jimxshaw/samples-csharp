using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            // Arrange
            var source = "CrossLugWrench";
            var expected = "Cross Lug Wrench";

            var stringHandler = new StringHandler();

            // Act
            var actual = stringHandler.InsertSpaces(source);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
