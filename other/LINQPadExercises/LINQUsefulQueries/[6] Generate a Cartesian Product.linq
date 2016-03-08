<Query Kind="Statements" />

// Title: LINQ: Compare two Sequences
// Link: http://www.devcurry.com/2011/04/linq-generate-cartesian-product.html

var listA = new string[] { "A", "B", "C" };
var listB = new string[] { "1", "2", "3" };
var cartesianLst = listA.SelectMany(a => listB.Select(b => a + b + ' '));

foreach(var lst in cartesianLst)
{
  Console.Write(lst);
}