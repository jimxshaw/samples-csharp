using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.Library.Test
{
    [TestClass]
    public class ListBuilderTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildIntegerListTest()
        {
            // Arrange
            ListBuilder listBuilder = new ListBuilder();

            // Act
            var result = listBuilder.BuildIntegerList();

            // Analyze
            result.ForEach(i=>
             TestContext.WriteLine(i.ToString()));
     
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildStringListTest()
        {
            // Arrange
            ListBuilder listBuilder = new ListBuilder();

            // Act
            var result = listBuilder.BuildStringList();

            // Analyze
            result.ForEach(s =>
             TestContext.WriteLine(s));

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CompareListTest()
        {
            // Arrange
            ListBuilder listBuilder = new ListBuilder();

            // Act
            var result = listBuilder.CompareLists();

            // Analyze
            result.ForEach(i =>
             TestContext.WriteLine(i.ToString()));

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
