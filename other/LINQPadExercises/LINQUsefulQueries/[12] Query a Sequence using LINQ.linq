<Query Kind="Statements" />

// Title: Query a Sequence using LINQ
// Link: http://www.devcurry.com/2011/02/query-sequence-using-linq.html

var rng = Enumerable.Range(200, 200).Select(x => x / 10f);

//Find First Number in the Sequence
var frstNo = rng.First();
Console.WriteLine("First Number: {0}", frstNo);

// Find Last number in the Sequence
var lastNo = rng.Last();
Console.WriteLine("Last Number: {0}", lastNo);

// Find First number in a Filtered Sequence
var frstFiltered = rng.Where(n => n > 20).FirstOrDefault();
Console.WriteLine("First Number Greater than 20: {0}", frstFiltered);

// Find Last number in a Filtered Sequence
var lastFiltered = rng.Where(n => n < 22).LastOrDefault();
Console.WriteLine("Last Number Lesser than 22: {0}", lastFiltered);

// Find Number at a Specified Index
var numIndex = rng.ElementAtOrDefault(15);
Console.WriteLine("Element at index 15: {0}", numIndex);