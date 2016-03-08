<Query Kind="Statements" />

// Title: List all Files in .NET 4.0 Based on the Creation Date
// Link: http://www.devcurry.com/2010/07/list-all-files-in-net-40-based-on.html
  
var DirInfo = new DirectoryInfo(Path.GetTempPath());
var dt1 = DateTime.Now.AddMonths(-1);
var dt2 = DateTime.Now;

var files = from file in DirInfo.EnumerateFiles()
            where file.CreationTimeUtc > dt1 & file.CreationTimeUtc < dt2                       
            select new { file.Name, file.CreationTimeUtc };

files.Dump();