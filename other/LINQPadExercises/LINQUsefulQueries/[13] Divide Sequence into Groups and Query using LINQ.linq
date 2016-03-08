<Query Kind="Statements" />

// Title: Divide Sequence into Groups and Query using LINQ
// Link: http://www.devcurry.com/2011/02/divide-sequence-into-groups-and-query.html

var sequence = Enumerable.Range(200, 200).Select(x => x / 10f);

var grps = from x in sequence.Select((i, j) => new { i, Grp = j / 10 })
            group x.i by x.Grp into y
            select new { Min = y.Min(), Max = y.Max() };

foreach(var grp in grps)
  Console.WriteLine("Min: " + grp.Min + " Max:" + grp.Max);