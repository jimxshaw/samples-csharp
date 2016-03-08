<Query Kind="Program" />

// Title: Inner Join Example in LINQ and C#
// Link: http://www.devcurry.com/2011/01/join-example-in-linq-and-c.html

void Main()
{

  List<Book> bookList = new List<Book>
  {
      new Book{BookID=1, BookNm="DevCurry.com Developer Tips"},
      new Book{BookID=2, BookNm=".NET and COM for Newbies"},
      new Book{BookID=3, BookNm="51 jQuery ASP.NET Recipes"},
      new Book{BookID=4, BookNm="Motivational Gurus"},
      new Book{BookID=5, BookNm="Spiritual Gurus"}
  };

  List<Order> bookOrders = new List<Order>{
      new Order{OrderID=1, BookID=1, PaymentMode="Cheque"},
      new Order{OrderID=2, BookID=5, PaymentMode="Credit"},
      new Order{OrderID=3, BookID=1, PaymentMode="Cash"},
      new Order{OrderID=4, BookID=3, PaymentMode="Cheque"},
      new Order{OrderID=5, BookID=5, PaymentMode="Cheque"},
      new Order{OrderID=6, BookID=4, PaymentMode="Cash"}
  };
  
  var orderForBooks = from bk in bookList
            join ordr in bookOrders
            on bk.BookID equals ordr.BookID
            select new
            {
                bk.BookID,
                Name = bk.BookNm,
                ordr.PaymentMode
            };

  orderForBooks.Dump();
}

public class Book
{
    public int BookID { get; set; }
    public string BookNm { get; set; }
}

public class Order
{
    public int OrderID { get; set; }
    public int BookID { get; set; }
    public string PaymentMode { get; set; }
}