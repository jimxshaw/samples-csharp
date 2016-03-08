<Query Kind="Statements" />

// Title: List all .NET Attributes in the Loaded Assemblies
// Link: http://www.devcurry.com/2010/11/list-all-net-attributes-in-loaded.html

var attributes = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                 from exptype in assembly.GetExportedTypes()
                 where typeof(Attribute).IsAssignableFrom(exptype)
                 select exptype;

attributes
  .Select(r => new { r.Name, r.FullName })
  .Dump();