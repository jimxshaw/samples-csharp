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

      // Arrange
      MyArray array = new MyArray(new[] { 5 });

      // Act
      int max = array.Maximum();

      // Assert
      Assert(max == 5, "Single element not recognized as greatest.");
    }


    public void Maximum_GreatestElementFirst_ReturnsThatElement()
    {
      MyArray array = new MyArray(new[] { 5, 1, 2, 3, 4 });

      int max = array.Maximum();

      Assert(max == 5, "First element not recognized as greatest.");
    }


    public void Maximum_GreatestElementInTheMiddle_ReturnsThatElement()
    {
      MyArray array = new MyArray(new[] { 1, 2, 3, 5, 4 });

      int max = array.Maximum();

      Assert(max == 5, "Middle element not recognized as greatest.");
    }


    public void Maximum_GreatestElementLast_ReturnsThatElement()
    {
      MyArray array = new MyArray(new[] { 1, 2, 3, 4, 5 });

      int max = array.Maximum();

      Assert(max == 5, "Last element not recognized as greates.");
    }


    private static void Assert(bool condition, string message)
    {
      if (!condition)
      {
        throw new Exception(message);
      }
    }
  }
}
