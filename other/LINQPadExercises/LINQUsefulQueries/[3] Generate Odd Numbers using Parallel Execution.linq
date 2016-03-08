<Query Kind="Statements" />

// Title: LINQ: Generate Odd Numbers using Parallel Execution
// Link: http://www.devcurry.com/2011/06/linq-generate-odd-numbers-using.html

var oddNums 
   = ((ParallelQuery<int>)ParallelEnumerable.Range(20, 2000))
.Where(x => x % 2 != 0)
.Select(i => i);

foreach (int n in oddNums) { Console.WriteLine(n); }