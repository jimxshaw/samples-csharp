<Query Kind="Statements" />

// Title: Join Two String Arrays with Distinct values using LINQ
// Link: http://www.devcurry.com/2010/03/join-two-string-arrays-with-distinct.html

string[] arr1 = { "One", "Two", "Four", "Six" };
string[] arr2 = { "Three", "Two", "Six", "Five" };

arr1.Union(arr2).Dump();