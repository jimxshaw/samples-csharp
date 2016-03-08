<Query Kind="Statements" />

// Title: Create a XML Tree from a String
// Link: http://www.devcurry.com/2010/04/create-xml-tree-from-string.html
  
string str = @"<?xml version=""1.0""?>
<Country name=""India"">
<Capital>New Delhi</Capital>
</Country>";

var doc = XDocument.Parse(str);

doc.Dump();
