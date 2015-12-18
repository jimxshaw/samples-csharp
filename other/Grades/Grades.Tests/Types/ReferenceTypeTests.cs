using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;


namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;

            IncrementNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            var book1 = new GradeBook();
            var book2 = book1;

            GiveBookAName(book2);
            Assert.AreNotEqual("A Grade Book", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book = new GradeBook();
            book.Name = "A Grade Book";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Jim";
            string name2 = "jim";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void VariablesHoldAReference()
        {
            var g1 = new GradeBook();
            var g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Jim's Grade Book";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }
    }
}
