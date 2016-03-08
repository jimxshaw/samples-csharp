<Query Kind="Statements" />

// Title: Using LINQ to Find the Sum of a MultiDimensional Array
// Link: http://www.devcurry.com/2009/08/using-linq-to-find-sum-of.html

var myArray = new int[,]
{
    { 1, 2 },
    { 3, 4 },
    { 5, 6 }
};

(from int val in myArray select val).Sum().Dump();