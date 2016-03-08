<Query Kind="Statements" />

// Title: Skip and Select Elements in a String Array using LINQ
// Link: http://www.devcurry.com/2010/06/skip-and-select-elements-in-string.html
  
string[] arr = {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight"};

arr.Skip(2).Take(3).Dump();