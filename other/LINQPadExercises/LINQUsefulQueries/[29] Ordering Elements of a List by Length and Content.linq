<Query Kind="Statements" />

// Title: Ordering Elements of a List<String> by Length and Content
// Link: http://www.devcurry.com/2010/06/ordering-elements-of-list-by-length-and.html
  
var strList = new List<string>()
{
    "Jane", "Bandy", "Ram", "Fiddo", "Carol"
};

strList.OrderBy(x => x.Length)
  .ThenByDescending(x => x)
  .Dump();