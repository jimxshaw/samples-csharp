using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
  public class MyArrayTests
  {
    // Method under test.
    // Scenario that is tested.
    // Expected behavior, state, result, etc.
    public void Maximum_ArrayContainsOneValue_ReturnsThatValue()
    {
      // MyArray class's Maximum method called on an array that contains
      // one value will return that value.

      // Arrange.
      var array = new MyArray(new[] { 4 });

      // Act.
      int max = array.Maximum();

      // Assert.
      if (max != 4)
      {
        throw new Exception();
      }
    }
  }
}
