<Query Kind="Statements" />

// Title: LINQ: List Classes implementing the IEnumerable Interface
// Link: http://www.devcurry.com/2011/04/linq-list-classes-implementing.html

var t = typeof(IEnumerable); 
var typesIEnum = AppDomain.CurrentDomain
  .GetAssemblies().Where(r => !r.FullName.StartsWith("LINQPad")) // note: linqpad does some trickery so ignore those
  .SelectMany(x => x.GetTypes())
  .Where(x => t.IsAssignableFrom(x)); 

foreach (var types in typesIEnum) 
{
   Console.WriteLine(types.FullName); 
}