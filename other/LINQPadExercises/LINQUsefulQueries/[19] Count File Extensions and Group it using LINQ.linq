<Query Kind="Statements" />

// Title: Count File Extensions and Group it using LINQ
// Link: http://www.devcurry.com/2010/10/count-file-extensions-and-group-it.html

 // Assuming the array with file names is returned via a service
string[] arr = {"abc1.txt", "abc2.TXT", "xyz.abc.pdf", "abc.PDF", "abc.xml", "zy.txt" };

var extGrp = arr.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
  .GroupBy(x => x,
    (ext, extCnt) =>
    new
      {
        Extension = ext,
         Count = extCnt.Count()
      });

// Print values
foreach (var a in extGrp)
    Console.WriteLine("{0} file(s) with {1} extension ", a.Count, a.Extension);