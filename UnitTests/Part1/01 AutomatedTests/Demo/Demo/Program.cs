using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        // Test automation in its bare form means the testing
        // application will instantiate the test class and invoke
        // the test declared in it.
        new MyArrayTests().Maximum_ArrayContainsOneValue_ReturnsThatValue();
        Console.WriteLine("Test passed");
      }
      catch
      {
        Console.WriteLine("Test failed");
      }


      Console.WriteLine("Press ENTER to continue... ");
      Console.ReadLine();
    }

  }
}
