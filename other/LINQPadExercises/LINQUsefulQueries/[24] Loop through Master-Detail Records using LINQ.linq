<Query Kind="Program" />

// Title: Loop through Master-Detail Records using LINQ
// Link: http://www.devcurry.com/2010/08/loop-through-master-detail-records.html
  
void Main()
{
  var emps = new List<Employee>();
  
  emps.Add(new Employee { EmpID = 1, EmpNm = "Barney Rubble", Address = Guid.NewGuid().ToString() });
  emps.Add(new Employee { EmpID = 2, EmpNm = "George Jetson", Address = Guid.NewGuid().ToString() });
  emps.Add(new Employee { EmpID = 3, EmpNm = "Wilma Flintsone", Address = Guid.NewGuid().ToString() });
  
  var dept = new List<Department>();
  
  dept.Add(new Department
  {
    DeptID = 1,
    DeptNm = "Bedrock",
    Employees = emps
  });
  
  var lst = from d in dept
            from e in d.Employees
            select new { d, e };
                    
  foreach (var rec in lst)
  {
      Console.WriteLine("{0}, {1}", rec.d.DeptNm, rec.e.EmpNm);
  }
}

     
class Department
{
  public int DeptID { get; set; }
  public string DeptNm { get; set; }
  public IList<Employee> Employees = new List<Employee>();
}

class Employee
{
  public int EmpID { get; set; }
  public string EmpNm { get; set; }
  public string Address { get; set; }
}