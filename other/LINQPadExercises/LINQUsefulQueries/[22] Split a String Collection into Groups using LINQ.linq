<Query Kind="Program" />

// Title: Split a String Collection into Groups using LINQ
// Link: http://www.devcurry.com/2010/12/split-string-collection-into-groups.html
  
void Main()
{
  string[] email = {"One@devcurry.com", "Two@devcurry.com",
                      "Three@devcurry.com", "Four@devcurry.com",
                      "Five@devcurry.com", "Six@devcurry.com",
                      "Seven@devcurry.com", "Eight@devcurry.com"};

  var emailGrp = from i in Enumerable.Range(0, email.Length)
                 group email[i] by i / 3;

  foreach(var mail in emailGrp)
    SendEmail(string.Join(";", mail.ToArray()));
}

     
static void SendEmail(string email)
{
    // Assuming that you have code for sending mails here
    Console.WriteLine(email);
    Console.WriteLine("--Batch Processed--");
}