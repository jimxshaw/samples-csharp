<Query Kind="Program" />

// Title: Implementing Paging in a Generic List using LINQ
// Link: http://www.devcurry.com/2009/02/implementing-paging-in-generic-list.html
  
void Main()
{
  var empList = new List<Employee>();

  empList.Add(new Employee() { ID = 1, FName = "John",  DOB = DateTime.Parse("12/11/1971")});
  empList.Add(new Employee() { ID = 2, FName = "Mary",  DOB = DateTime.Parse("01/17/1961")});
  empList.Add(new Employee() { ID = 3, FName = "Amber", DOB = DateTime.Parse("12/23/1971")});
  empList.Add(new Employee() { ID = 4, FName = "Kathy", DOB = DateTime.Parse("11/15/1976")});
  empList.Add(new Employee() { ID = 5, FName = "Lena",  DOB = DateTime.Parse("05/11/1978")});

  var records = from emp in empList
                select emp;
  var pgNo = 1;
  var pgRec = 2;
  
  records.Skip((pgNo - 1) * pgRec).Take(pgRec).Select(r => r.FName).Dump();
}

class Employee
{
  public int ID { get; set; }
  public string FName { get; set; }
  public DateTime DOB { get; set; }
}