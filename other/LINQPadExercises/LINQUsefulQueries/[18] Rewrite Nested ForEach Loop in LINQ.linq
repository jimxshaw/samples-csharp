<Query Kind="Statements" />

// Title: Rewrite Nested ForEach Loop in LINQ
// Link: http://www.devcurry.com/2010/11/rewrite-nested-foreach-loop-in-linq.html

string[] uCase = { "A", "B", "C" };
string[] lCase = { "a", "b", "c" };
var sb = new StringBuilder();

foreach (string s1 in uCase)
{
    foreach (string s2 in lCase)
    {
        sb.AppendLine(s1 + s2);
    }
}

sb.ToString().Dump("Nested foreach");
sb.Clear();

var ul = uCase.SelectMany(
    uc => lCase, (uc, lc) => (uc + lc));

foreach (string s in ul)
{
    sb.AppendLine(s);
}

sb.ToString().Dump("SelectMany");