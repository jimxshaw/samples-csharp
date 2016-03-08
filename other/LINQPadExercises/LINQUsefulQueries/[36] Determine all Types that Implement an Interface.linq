<Query Kind="Statements" />

// Title: Determine all Types that Implement an Interface
// Link: http://www.devcurry.com/2009/11/determine-all-types-that-implement.html

var t = typeof(IEnumerable);

AppDomain.CurrentDomain
  .GetAssemblies().Where(r => !r.FullName.StartsWith("LINQPad")) // note: linqpad does some trickery so ignore those
  .SelectMany(typ => typ.GetTypes())
  .Where(x => t.IsAssignableFrom(x))
  .Select(r => r.FullName)
  .Dump();
     