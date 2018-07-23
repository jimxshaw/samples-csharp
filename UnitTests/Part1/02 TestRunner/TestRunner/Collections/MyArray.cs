using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
  public class MyArray
  {
    private int[] Data { get; }

    public MyArray(IEnumerable<int> values)
    {
      Data = values.ToArray();
    }

    public int Maximum()
    {
      // Assume this.data.Length > 0
      int max = Data[0];

      for (var i = 1; i < Data.Length; i++)
      {
        if (Data[i] > max)
        {
          max = Data[i];
        }
      }

      return max;
    }

  }
}
