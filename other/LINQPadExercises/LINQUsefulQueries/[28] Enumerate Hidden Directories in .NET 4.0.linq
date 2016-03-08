<Query Kind="Expression" />

// Title: Enumerate Hidden Directories in .NET 4.0
// Link: http://www.devcurry.com/2010/06/enumerate-hidden-directories-in-net-40.html
  
new DirectoryInfo(@"C:\")
  .EnumerateDirectories()
  .Where(x => x.Attributes.HasFlag(FileAttributes.Hidden))
  .Select(x => x.Name)