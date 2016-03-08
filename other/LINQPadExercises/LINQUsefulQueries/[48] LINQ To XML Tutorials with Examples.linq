<Query Kind="Program" />

// Title: LINQ To XML Tutorials with Examples
// Link: http://www.dotnetcurry.com/ShowArticle.aspx?ID=564
  
void Main()
{
  #region XML
  var xml = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiID8+DQo8RW1wbG95ZWVzPg0KIDxFbXBsb3llZT4NCiAgICA8RW1wSWQ+MTwvRW1wSWQ+DQogICAgPE5hbWU+U2FtPC9OYW1lPiAgIA0KICAgIDxTZXg+TWFsZTwvU2V4Pg0KICAgIDxQaG9uZSBUeXBlPSJIb21lIj40MjMtNTU1LTAxMjQ8L1Bob25lPg0KICAgIDxQaG9uZSBUeXBlPSJXb3JrIj40MjQtNTU1LTA1NDU8L1Bob25lPg0KICAgPEFkZHJlc3M+DQogICAgICA8U3RyZWV0PjdBIENveCBTdHJlZXQ8L1N0cmVldD4NCiAgICAgIDxDaXR5PkFjYW1wbzwvQ2l0eT4NCiAgICAgIDxTdGF0ZT5DQTwvU3RhdGU+DQogICAgICA8WmlwPjk1MjIwPC9aaXA+DQogICAgICA8Q291bnRyeT5VU0E8L0NvdW50cnk+DQogICAgPC9BZGRyZXNzPg0KIDwvRW1wbG95ZWU+DQogPEVtcGxveWVlPg0KICAgIDxFbXBJZD4yPC9FbXBJZD4NCiAgICA8TmFtZT5MdWN5PC9OYW1lPg0KICAgIDxTZXg+RmVtYWxlPC9TZXg+DQogICAgPFBob25lIFR5cGU9IkhvbWUiPjE0My01NTUtMDc2MzwvUGhvbmU+DQogICAgPFBob25lIFR5cGU9IldvcmsiPjQzNC01NTUtMDU2NzwvUGhvbmU+DQogICAgPEFkZHJlc3M+DQogICAgICA8U3RyZWV0Pkplc3MgQmF5PC9TdHJlZXQ+DQogICAgICA8Q2l0eT5BbHRhPC9DaXR5Pg0KICAgICAgPFN0YXRlPkNBPC9TdGF0ZT4NCiAgICAgIDxaaXA+OTU3MDE8L1ppcD4NCiAgICAgIDxDb3VudHJ5PlVTQTwvQ291bnRyeT4NCiAgICA8L0FkZHJlc3M+DQogPC9FbXBsb3llZT4NCiA8RW1wbG95ZWU+DQogICAgPEVtcElkPjM8L0VtcElkPg0KICAgIDxOYW1lPkthdGU8L05hbWU+DQogICAgPFNleD5GZW1hbGU8L1NleD4NCiAgICA8UGhvbmUgVHlwZT0iSG9tZSI+MTY2LTU1NS0wMjMxPC9QaG9uZT4NCiAgICA8UGhvbmUgVHlwZT0iV29yayI+MjMzLTU1NS0wNDQyPC9QaG9uZT4NCiAgICA8QWRkcmVzcz4NCiAgICAgIDxTdHJlZXQ+MjMgQm94ZW4gU3RyZWV0PC9TdHJlZXQ+DQogICAgICA8Q2l0eT5NaWxmb3JkPC9DaXR5Pg0KICAgICAgPFN0YXRlPkNBPC9TdGF0ZT4NCiAgICAgIDxaaXA+OTYxMjE8L1ppcD4NCiAgICAgIDxDb3VudHJ5PlVTQTwvQ291bnRyeT4NCiAgICA8L0FkZHJlc3M+DQogPC9FbXBsb3llZT4NCiA8RW1wbG95ZWU+DQogICAgPEVtcElkPjQ8L0VtcElkPg0KICAgIDxOYW1lPkNocmlzPC9OYW1lPg0KICAgIDxTZXg+TWFsZTwvU2V4Pg0KICAgIDxQaG9uZSBUeXBlPSJIb21lIj41NjQtNTU1LTAxMjI8L1Bob25lPg0KICAgIDxQaG9uZSBUeXBlPSJXb3JrIj40NDItNTU1LTAxNTQ8L1Bob25lPg0KICAgIDxBZGRyZXNzPg0KICAgICAgPFN0cmVldD4xMjQgS3V0YmF5PC9TdHJlZXQ+DQogICAgICA8Q2l0eT5Nb250YXJhPC9DaXR5Pg0KICAgICAgPFN0YXRlPkNBPC9TdGF0ZT4NCiAgICAgIDxaaXA+OTQwMzc8L1ppcD4NCiAgICAgIDxDb3VudHJ5PlVTQTwvQ291bnRyeT4NCiAgICA8L0FkZHJlc3M+DQogPC9FbXBsb3llZT4NCjwvRW1wbG95ZWVzPg==";
  #endregion
  
  #region Example 1
  var sb = new StringBuilder();
  var data = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xml));
  
  var doc = XDocument.Parse(data).Element("Employees");
  
  var employees = doc.Elements();
  
  //employees.Dump("Example 1");
  #endregion
  
  #region Example 2
  sb.AppendLine("List of all Employee Names :");
  
  foreach(var employee in employees)
  {
      sb.AppendLine(employee.Element("Name").Value);
  }
  
  //sb.ToString().Dump("Example 2");
  sb.Clear();
  #endregion

  #region Example 3
  sb.AppendLine("List of all Employee Names along with their ID:");
  
  foreach (var employee in employees)
  {
      sb.AppendLine(string.Format("{0} has Employee ID {1}",
          employee.Element("Name").Value,
          employee.Element("EmpId").Value));
  }
  
  //sb.ToString().Dump("Example 3");
  sb.Clear();
  #endregion

  #region Example 4
  var name = from nm in doc.Elements("Employee")
           where (string)nm.Element("Sex") == "Female"
           select nm;
  
  sb.AppendLine("Details of Female Employees:");
  
  foreach (var xEle in name)
      sb.AppendLine(xEle.ToString());
  
  //sb.ToString().Dump("Example 4");
  sb.Clear();
  #endregion
  
  #region Example 5
  var homePhone = from phoneno in doc.Elements("Employee")
                where (string)phoneno.Element("Phone").Attribute("Type") == "Home"
                select phoneno;
                
  sb.AppendLine("List HomePhone Nos.");
  
  foreach (var xEle in homePhone)
  {
    sb.AppendLine(xEle.Element("Phone").Value);
  }
  
  //sb.ToString().Dump("Example 5");
  sb.Clear();
  #endregion
  
  #region Example 6
  var addresses = from address in doc.Elements("Employee")
                where (string)address.Element("Address").Element("City") == "Alta"
               select address;
               
  sb.AppendLine("Details of Employees living in Alta City");
  foreach (XElement xEle in addresses)
      sb.AppendLine(xEle.ToString());
  
  //sb.ToString().Dump("Example 6");
  sb.Clear();
  #endregion
  
  #region Example 7
  sb.AppendLine("List of all Zip Codes");
  
  foreach (XElement xEle in doc.Descendants("Zip"))
  {
      sb.AppendLine((string)xEle);
  }
  
  //sb.ToString().Dump("Example 7");
  sb.Clear();
  #endregion
  
  #region Example 8
  var codes = from code in doc.Elements("Employee")
                            let zip = (string)code.Element("Address").Element("Zip")
                            orderby zip
                            select zip;
  
  sb.AppendLine("List and Sort all Zip Codes");
  
  foreach (string zp in codes)
      sb.AppendLine(zp);
  
  //sb.ToString().Dump("Example 8");
  sb.Clear();
  #endregion
  
  #region Example 9
  XNamespace empNM = "urn:lst-emp:emp";
 
  var xDoc = new XDocument(
              new XDeclaration("1.0", "UTF-16", null),
              new XElement(empNM + "Employees",
                  new XElement("Employee",
                      new XComment("Only 3 elements for demo purposes"),
                      new XElement("EmpId", "5"),
                      new XElement("Name", "Kimmy"),
                      new XElement("Sex", "Female")
                      )));
  
  var sw = new StringWriter();
  xDoc.Save(sw);
  sb.AppendLine(sw.ToString());
  
  //sb.ToString().Dump("Example 9");
  sb.Clear();
  #endregion
  
  #region Example 10
  empNM = "urn:lst-emp:emp";
 
  xDoc = new XDocument(
              new XDeclaration("1.0", "UTF-16", null),
              new XElement(empNM + "Employees",
                  new XElement("Employee",
                      new XComment("Only 3 elements for demo purposes"),
                      new XElement("EmpId", "5"),
                      new XElement("Name", "Kimmy"),
                      new XElement("Sex", "Female")
                      )));
  
  sw = new StringWriter();
  var xWrite = XmlWriter.Create(sw);
  xDoc.Save(xWrite);
  xWrite.Close();
  
  // Save to Disk
  var file = Path.GetTempFileName().Replace(".tmp", ".xml");
  xDoc.Save(file);
  sb.AppendFormat("Saved to: {0}", file);
  
  //sb.ToString().Dump("Example 10");
  sb.Clear();
  #endregion

  #region Example 11
  var xRead = XmlReader.Create(file);
  var xe = XElement.Load(xRead);
  sb.AppendLine(xe.ToString());
  xRead.Close();
  
  //sb.ToString().Dump("Example 11");
  sb.Clear();
  #endregion
  
  #region Example 12
  var emp = doc.Descendants("Employee").ElementAt(1);
  sb.AppendLine(emp.ToString());
  
  //sb.ToString().Dump("Example 12");
  sb.Clear();
  #endregion
  
  #region Example 13
  var emps = doc.Descendants("Employee").Take(2);
  
  foreach (var e13 in emps)
    sb.AppendLine(e13.ToString());
  
  //sb.ToString().Dump("Example 13");
  sb.Clear();
  #endregion

  #region Example 14
  var emps14 = doc.Descendants("Employee").Skip(1).Take(2);

  foreach (var emp14 in emps14)
    sb.AppendLine(emp14.ToString());
  
  //sb.ToString().Dump("Example 14");
  sb.Clear();
  #endregion

  #region Example 15
  var emps15 = doc.Descendants("Employee").Reverse().Take(2);
  
  foreach (var emp15 in emps15)
    sb.AppendLine(emp15.Element("EmpId").ToString() + " " + emp15.Element("Name").ToString());
  
  //sb.ToString().Dump("Example 15");
  sb.Clear();
  #endregion

  #region Example 16
  var stCnt = from address in doc.Elements("Employee")
            where (string)address.Element("Address").Element("State") == "CA"
            select address;

  sb.AppendFormat("No of Employees living in CA State are {0}", stCnt.Count());
  
  //sb.ToString().Dump("Example 16");
  sb.Clear();
  #endregion

  #region Example 17
  doc.Add(new XElement("Employee",
     new XElement("EmpId", 5),
     new XElement("Name", "George")));
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 17");
  sb.Clear();
  #endregion

  #region Example 18
  doc.AddFirst(new XElement("Employee",
        new XElement("EmpId", 5),
        new XElement("Name", "George")));
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 18");
  sb.Clear();
  #endregion

  #region Example 19
  doc.Add(new XElement("Employee",
        new XElement("EmpId", 5),
        new XElement("Phone", "423-555-4224", new XAttribute("Type", "Home"))));
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 19");
  sb.Clear();
  #endregion

  #region Example 20
  var countries = doc.Elements("Employee").Elements("Address").Elements("Country").ToList();
  
  foreach (var cEle in countries)
    cEle.ReplaceNodes("United States Of America");
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 20");
  sb.Clear();
  #endregion
  
  #region Example 21
  var phone = doc.Elements("Employee").Elements("Phone").ToList();
  
  foreach (var pEle in phone)
    pEle.RemoveAttributes();
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 21");
  sb.Clear();
  #endregion
  
  #region Example 22
  var addr = doc.Elements("Employee").ToList();
  
  foreach (var addEle in addr)
    addEle.SetElementValue("Address", null);
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 22");
  sb.Clear();
  #endregion

  #region Example 23
  var emps23 = doc.Descendants("Employee");
  
  emps23.Reverse().Take(2).Remove();
 
  sb.Append(doc.ToString());
  
  //sb.ToString().Dump("Example 23");
  sb.Clear();
  #endregion
  
  #region Example 24
  doc.Add(new XElement("Employee",
    new XElement("EmpId", 5),
    new XElement("Name", "George"),
    new XElement("Sex", "Male"),
    new XElement("Phone", "423-555-4224", new XAttribute("Type", "Home")),
    new XElement("Phone", "424-555-0545", new XAttribute("Type", "Work")),
    new XElement("Address",
        new XElement("Street", "Fred Park, East Bay"),
        new XElement("City", "Acampo"),
        new XElement("State", "CA"),
        new XElement("Zip", "95220"),
        new XElement("Country", "USA"))));
 
  doc.Save(file);
  sb.AppendLine(doc.ToString());         
  
  sb.ToString().Dump("Example 24");
  sb.Clear();
  #endregion
}