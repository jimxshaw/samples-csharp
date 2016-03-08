<Query Kind="Statements" />

// Title: Filter a Type in .NET inside the For-Each Loop
// Link: http://www.devcurry.com/2010/09/filter-type-in-net-inside-for-each-loop.html

ArrayList arr = new ArrayList();

arr.Add(15);
arr.Add(25.35);
arr.Add(10);
arr.Add(20);
arr.Add(25);
arr.Add(20.2);

foreach (var num in arr.OfType<int>().Where(x => x > 10))
{
  Console.WriteLine(num);
}