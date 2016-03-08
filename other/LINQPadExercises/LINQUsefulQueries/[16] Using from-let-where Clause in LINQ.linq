<Query Kind="Statements" />

// Title: Using from-let-where Clause in LINQ
// Link: http://www.devcurry.com/2011/01/using-from-let-where-clause-in-linq.html

var arr = new[] { 5, 3, 4, 2, 6, 7 };
var sq = from int num in arr
         let square = num * num
         where square > 10
         select new { num, square };

sq.Dump();