using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
  [TestClass]
  public class AssertClassTest
  {
    [TestMethod]
    [Owner("Jefferson")]
    public void IsInstanceOfTypeTest()
    {
      var manager = new PersonManager();
      Person person;

      person = manager.CreatePerson("John", "Duncan", true);

      Assert.IsInstanceOfType(person, typeof(Supervisor));
    }

    [TestMethod]
    [Owner("Jefferson")]
    public void IsNullTest()
    {
      var manager = new PersonManager();
      Person person;

      person = manager.CreatePerson("", "Duncan", true);

      Assert.IsNull(person);
    }
  }
}
