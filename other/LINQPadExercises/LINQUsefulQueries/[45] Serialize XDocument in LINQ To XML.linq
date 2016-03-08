<Query Kind="Program" />

// Title: Serialize XDocument in LINQ To XML
// Link: http://www.devcurry.com/2010/12/serialize-xdocument-in-linq-to-xml.html
  
void Main()
{
  var file = Path.GetTempFileName().Replace(".tmp", ".xml");
  
  XNamespace empNM = "urn:lst-emp:emp";

  XDocument xDoc = new XDocument(
          new XDeclaration("1.0", "UTF-16", null),
           new XElement("Employees",
                  new XElement("Employee",
                      new XComment("DevCurry.com Employees"),
                      new XElement("EmpId", "1"),
                      new XElement("Name", "Kathy"),
                      new XElement("Sex", "Female")
                  )));

  using (var strW = new StringWriter())
  {
    using (var xmlW = XmlWriter.Create(strW))
    {
        xDoc.Save(xmlW);
        // Save to Disk
        xDoc.Save(file);
        Console.WriteLine("Saved");
    }
  }
  
  OpenFile(file);
}

private void OpenFile(string file)
{
  var p = new Process();
  
  p.StartInfo.Arguments = file;
  p.StartInfo.FileName = "notepad";
  
  p.Start();
}