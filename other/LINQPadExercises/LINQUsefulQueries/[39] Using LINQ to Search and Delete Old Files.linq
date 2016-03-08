<Query Kind="Statements" />

// Title: Using LINQ to Search and Delete Old Files
// Link: http://www.devcurry.com/2009/08/using-linq-to-search-and-delete-old.html

var files = from o in Directory.GetFiles(Path.GetTempPath(), "*.*", SearchOption.AllDirectories)
let x = new FileInfo(o)
where x.CreationTime <= DateTime.Now.AddMonths(-6)
select o;

foreach (var item in files)
{
  item.Dump();
  // File.Delete(item);
}