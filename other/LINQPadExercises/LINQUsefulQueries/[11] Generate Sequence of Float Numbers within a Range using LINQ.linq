<Query Kind="Statements" />

// Title: Generate Sequence of Float Numbers within a Range using LINQ
// Link: http://www.devcurry.com/2010/10/generate-sequence-of-float-numbers.html

var rng = Enumerable.Range(200, 200).Select(x => x / 10f);

foreach (float n in rng)
{
  Console.WriteLine(n);
}