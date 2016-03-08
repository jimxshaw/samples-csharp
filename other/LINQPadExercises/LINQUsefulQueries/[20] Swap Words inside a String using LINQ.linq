<Query Kind="Statements" />

// Title: Swap Words inside a String using LINQ
// Link: http://www.devcurry.com/2010/10/swap-words-inside-string-using-linq.html

string name = "Suprotim, Agarwal";
name = string.Join(", ", name.Split(',').Reverse()).Trim();

Console.WriteLine(name);