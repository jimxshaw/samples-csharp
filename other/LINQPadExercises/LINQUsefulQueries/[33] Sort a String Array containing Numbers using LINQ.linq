<Query Kind="Statements" />

// Title: Sort a String Array containing Numbers using LINQ
// Link: http://www.devcurry.com/2010/04/sort-string-array-containing-numbers.html

string[] arr = { "3", "1", "6", "10", "5", "13" };

arr.OrderBy(x => int.Parse(x)).Dump();
