<Query Kind="Program" />

// Title: Distinct OrderBy in LINQ
// Link: http://www.devcurry.com/2010/05/distinct-orderby-in-linq.html

void Main()
{
  Customer.GetCustomers()
    .Select(c => c.CustName)
    .Distinct()
    .OrderBy(x => x)
    .Dump();
}

class Customer
{
  public int OrderId { get; set; }
  public string CustName { get; set; }

  public static List<Customer> GetCustomers()
  {
    List<Customer> cust = new List<Customer>();
    
    cust.Add(new Customer() { OrderId = 1, CustName = "Zack" });
    cust.Add(new Customer() { OrderId = 2, CustName = "Harry" });
    cust.Add(new Customer() { OrderId = 3, CustName = "Jill" });
    cust.Add(new Customer() { OrderId = 4, CustName = "Zack" });
    cust.Add(new Customer() { OrderId = 5, CustName = "Martin" });
    cust.Add(new Customer() { OrderId = 6, CustName = "Jill" });
    
    return cust;
  }
}