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

    public List<Person> GetPeople()
    {
      var people = new List<Person>();

      people.Add(new Person() { FirstName = "James", LastName = "Madison" });
      people.Add(new Person() { FirstName = "George", LastName = "Washington" });
      people.Add(new Person() { FirstName = "John", LastName = "Kennedy" });

      return people;
    }

    public List<Person> GetSupervisors()
    {
      var people = new List<Person>();

      people.Add(CreatePerson("James", "Madison", true ));
      people.Add(CreatePerson("Thomas", "Jefferson", true));

      return people;
    }
  }
}
