<Query Kind="Statements" />

// Title: LINQ: Compare two Sequences
// Link: http://www.devcurry.com/2011/06/linq-compare-two-sequences.html

var l1 = new List<int> { 1, 2, 3, 4, 5, 6 };
var l2 = new List<int> { 1, 2, 4, 5 };

var result = l1.SequenceEqual(l2);

Console.WriteLine("Are they equal? {0}", result);

// if not equal find the difference
if(!result)
{
  Console.WriteLine("Difference between 2 sequences");
  
  var diff = l1.Except(l2);
  
  Array.ForEach(diff.ToArray(), r => Console.WriteLine(r));
}