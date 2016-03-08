<Query Kind="Statements" />

// Title: Concatenate Unique Elements of two List<String> and Sort using LINQ
// Link: http://www.devcurry.com/2010/08/concatenate-unique-elements-of-two-list.html
  
List<string> lstOne = new List<string>() { "Jack", "Henry", "Amy" };
List<string> lstTwo = new List<string>() { "Hill", "Amy", "Anna" };
IEnumerable<string> lstNew = null;

// Concatenate Unique Elements of two List<string>
lstNew = lstOne.Concat(lstTwo)
  .Distinct()
  .OrderBy(x => x);

lstNew.Dump();