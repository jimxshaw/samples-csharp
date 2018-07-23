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
      IEnumerable<int> numbers = ReadData();

      while (numbers.Any())
      {
        var array = new MyArray(numbers);

        Console.WriteLine($"Max = {array.Maximum()}");

        numbers = ReadData();
      }
    }

    static IEnumerable<int> ReadData()
    {
      Console.Write("Enter elements: ");

      string line = Console.ReadLine() ?? string.Empty;

      string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

      return parts.Select(int.Parse).ToList();
    }
  }
}
