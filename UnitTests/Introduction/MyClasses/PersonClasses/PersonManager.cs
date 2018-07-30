using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
  public class PersonManager
  {
    public Person CreatePerson(string firstName, string lastName, bool isSupervisor)
    {
      Person result = null;

      if (!string.IsNullOrEmpty(firstName))
      {
        if (isSupervisor)
        {
          result = new Supervisor();
        }
        else
        {
          result = new Employee();
        }

        result.FirstName = firstName;
        result.LastName = lastName;
      }

      return result;
    }
  }
}
