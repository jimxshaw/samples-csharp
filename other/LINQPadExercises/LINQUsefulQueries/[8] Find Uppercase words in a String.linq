<Query Kind="Statements" />

// Title: Find Uppercase words in a String using C#
// Link: http://www.devcurry.com/2011/03/find-uppercase-words-in-string-using-c.html

var strwords = "THIS is A very STRANGE string".Split(' ')
  .Where(s => String.Equals(s, s.ToUpper(), StringComparison.Ordinal));

foreach (string str in strwords) Console.WriteLine(str);