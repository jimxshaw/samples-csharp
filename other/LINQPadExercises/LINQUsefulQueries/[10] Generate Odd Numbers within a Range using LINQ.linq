<Query Kind="Statements" />

// Title: Generate Odd Numbers within a Range using LINQ
// Link: http://www.devcurry.com/2010/03/generate-odd-numbers-within-range-using.html

foreach (int n in Enumerable.Range(20, 20).Where(x => x % 2 != 0))
{
  Console.WriteLine(n);
}