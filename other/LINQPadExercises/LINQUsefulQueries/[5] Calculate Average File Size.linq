<Query Kind="Statements" />

// Title: LINQ: Calculate Average File Size in C#
// Link: http://www.devcurry.com/2011/06/linq-c-average-file-size.html

var dirfiles = Directory.GetFiles(Path.GetTempPath());            
var avg = dirfiles.Select(file => new FileInfo(file).Length).Average();

avg = Math.Round(avg/1000000, 1);

Console.WriteLine("The Average file size is {0} MB", avg);