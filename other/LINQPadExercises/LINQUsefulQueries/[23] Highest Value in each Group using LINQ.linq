<Query Kind="Program" />

// Title: Highest Value in each Group using LINQ
// Link: http://www.devcurry.com/2010/09/highest-value-in-each-group-using-linq.html
  
void Main()
{
  List<Employees> emp = new List<Employees>();
  
  emp.Add(new Employees() { EmpId = 1, DeptId = 1, Salary = 20000 });
  
  var highest = from e in emp
                group e by e.DeptId into dptgrp
                  let topsal = dptgrp.Max(x => x.Salary)
                select new
                {
                    Dept = dptgrp.Key,
                    TopSal = dptgrp.First(y => y.Salary == topsal).EmpId,
                    MaximumSalary = topsal
                };
  
  highest.Dump();
}

     
class Employees
{
    public int EmpId { get; set; }
    public int DeptId { get; set; }
    public int Salary { get; set; }
}