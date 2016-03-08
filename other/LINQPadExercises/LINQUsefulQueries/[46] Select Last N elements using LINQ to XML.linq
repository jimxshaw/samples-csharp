<Query Kind="Program" />

// Title: Select Last N elements using LINQ to XML
// Link: http://www.devcurry.com/2011/03/select-last-n-elements-using-linq-to.html
  
void Main()
{
  #region XML
  var xml = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiID8+DQo8U2Nob29sPg0KICA8Q2xhc3MgU2VjdGlvbj0iMSIgTmFtZT0iQ2xhc3MgQSI+DQogICAgPFN0dWRlbnQ+MjM8L1N0dWRlbnQ+DQogICAgPE5hbWU+R292aW5kPC9OYW1lPg0KICA8L0NsYXNzPg0KICA8Q2xhc3MgU2VjdGlvbj0iMiIgTmFtZT0iQ2xhc3MgQiI+DQogICAgPFN0dWRlbnQ+MjY8L1N0dWRlbnQ+DQogICAgPE5hbWU+SGFyaTwvTmFtZT4NCiAgPC9DbGFzcz4NCiAgPENsYXNzIFNlY3Rpb249IjMiIE5hbWU9IkNsYXNzIEMiPg0KICAgIDxTdHVkZW50PjI5PC9TdHVkZW50Pg0KICAgIDxOYW1lPk1hcms8L05hbWU+DQogIDwvQ2xhc3M+DQo8L1NjaG9vbD4=";
  #endregion
  
  var data = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xml));
  
  var doc = XDocument.Parse(data);
  var students = doc.Descendants("Class").Reverse().Take(2);
  
  students.Select(r => new
  {
    ID = r.Element("Student").Value,
    Name = r.Element("Name").Value
  })
  .Dump();
}