<Query Kind="Expression" />

// Title: Using LINQ to Find Top 5 Processes that are Consuming Memory
// Link: http://www.devcurry.com/2009/10/using-linq-to-find-top-5-processes-that.html

System.Diagnostics.Process.GetProcesses()
  .OrderByDescending(r => r.PrivateMemorySize64)
  .Take(5)
  .Select(r => r.ProcessName)