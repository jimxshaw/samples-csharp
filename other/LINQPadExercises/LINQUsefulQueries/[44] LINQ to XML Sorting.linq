<Query Kind="Program" />

// Title: LINQ to XML Sorting
// Link: http://www.devcurry.com/2011/01/linq-to-xml-sorting.html
  
void Main()
{
  #region XML
  var xml = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiID8+DQo8Q3VzdG9tZXJzPg0KICA8Q3VzdG9tZXIgQ3VzdElkPSIxIiBOYW1lPSJNYXJrZSBadWVzIiAvPg0KICA8Q3VzdG9tZXIgQ3VzdElkPSIyIiBOYW1lPSJSaWNreSBTaGVsZCIgLz4NCiAgPEN1c3RvbWVyIEN1c3RJZD0iMyIgTmFtZT0iS2F0ZSBNb3NzIiAvPg0KICA8Q3VzdG9tZXIgQ3VzdElkPSI0IiBOYW1lPSJDaHJpcyBIYW5rZXIiIC8+DQogIDxDdXN0b21lciBDdXN0SWQ9IjUiIE5hbWU9IkFydmluZCBKYWluIiAvPg0KICA8Q3VzdG9tZXIgQ3VzdElkPSI2IiBOYW1lPSJNYWhlc2ggU2FiIiAvPg0KPC9DdXN0b21lcnM+";
  #endregion
  
  var data = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xml));
  
  var xelement = XDocument.Parse(data);

  var dict = (from element in xelement.Descendants("Customer")
              let name = (string)element.Attribute("Name")
              orderby name
              select new
              {
                  CustID = element.Attribute("CustId").Value,
                  CustName = name
              })
              .ToDictionary(c => c.CustID, c => c.CustName);
  
  dict.Dump();
}