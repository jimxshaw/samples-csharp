<Query Kind="Program" />

// Title: LINQ: Query Comma Separated Value (CSV) files
// Link: http://www.devcurry.com/2011/02/linq-query-comma-separated-value-csv.html
  
void Main()
{
  IEnumerable<string> strCSV = File.ReadLines(GetFileName());
  
  var results = from str in strCSV
              let tmp = str.Split(',')
              .Skip(1)
              .Select(x => Convert.ToInt32(x))
              select new {
                  Max = tmp.Max(),
                  Min = tmp.Min(),
                  Total = tmp.Sum(),
                  Avg = tmp.Average()
              };

  // caching for performance
  var query = results.ToList();

  foreach (var x in query)
  {
      Console.WriteLine(
          string.Format("Maximum: {0}, " +
                        "Minimum: {1}, " +
                        "Total: {2}, " +
                        "Average: {3}",
                        x.Max, x.Min, x.Total, x.Avg));
  }
}

private string GetFileName()
{
  var file = Path.GetTempFileName();
  var sb = new StringBuilder();
  
  sb.AppendLine("1, 200, 122, 118, 154");
  sb.AppendLine("2, 142, 184, 191, 129");
  sb.AppendLine("3, 88, 34, 165, 166");
  sb.AppendLine("4, 83, 88, 113, 126");
  sb.AppendLine("5, 145, 172, 174, 167");
  
  File.WriteAllText(file, sb.ToString());
  
  return file;
}