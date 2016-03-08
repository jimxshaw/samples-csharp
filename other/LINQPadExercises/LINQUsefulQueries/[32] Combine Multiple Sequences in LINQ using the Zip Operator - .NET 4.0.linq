<Query Kind="Statements" />

// Title: Combine Multiple Sequences in LINQ using the Zip Operator - .NET 4.0
// Link: http://www.devcurry.com/2010/05/combine-multiple-sequences-in-linq.html

var bldgNum = new string[] {"A5", "A2", "A1" };
var flatNum = new int[] {104, 109, 25, 200 };
var streetNm = new string[] {"Baker Street", "Cross Street", "Hu Street" };
var city = new string[] { "CO", "WA", "AU", "CA" };

bldgNum
    .Zip(flatNum, (bl, fl) => bl + ", " + fl.ToString())
    .Zip(streetNm, (fl, st) => fl + " , " + st)
    .Zip(city, (st, ct) => st + ", " + ct)
    .Dump();