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
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void VariablesHoldAReference()
        {
            var g1 = new GradeBook();
            var g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Jim's Grade Book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
