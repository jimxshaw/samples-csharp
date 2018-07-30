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
  public class CollectionAssertClassTest
  {
    [TestMethod]
    [Owner("Lincoln")]
    public void AreCollectionsEqualWithComparerTest()
    {
      var manager = new PersonManager();
      var peopleExpected = new List<Person>();
      var peopleActual = new List<Person>();

      peopleExpected.Add(new Person() { FirstName = "James", LastName = "Madison" });
      peopleExpected.Add(new Person() { FirstName = "George", LastName = "Washington" });
      peopleExpected.Add(new Person() { FirstName = "John", LastName = "Kennedy" });

      peopleActual = manager.GetPeople();

      CollectionAssert.AreEqual(peopleExpected, peopleActual,
        Comparer<Person>.Create((ex, ac) =>
          ex.FirstName == ac.FirstName && ex.LastName == ac.LastName ? 0 : 1));
    }

    [TestMethod]
    [Owner("Lincoln")]
    public void IsCollectionOfTypeTest()
    {
      var manager = new PersonManager();
      var peopleActual = new List<Person>();

      peopleActual = manager.GetSupervisors();

      CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
    }

  }
}
