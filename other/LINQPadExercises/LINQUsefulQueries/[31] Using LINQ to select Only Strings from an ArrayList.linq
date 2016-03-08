<Query Kind="Statements" />

// Title: Using LINQ to select Only Strings from an ArrayList
// Link: http://www.devcurry.com/2010/05/using-linq-to-select-only-strings-from.html

var al = new ArrayList { "Hello", 200, "World", false, 100 };

al.OfType<string>().Dump("Dumping only strings");