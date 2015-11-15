using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Person
    {
        // Objects should hide their implementation detail and reveal what they can do through method but
        // should not reveal how they do what they're supposed to do through their fields.

        private DateTime _birthdate;

        public void SetBirthdate(DateTime birthdate)
        {
            _birthdate = birthdate;
        }

        public DateTime GetBirthdate()
        {
            return _birthdate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();

            person.SetBirthdate(new DateTime(1994, 2, 1));
            Console.WriteLine(person.GetBirthdate());

            Console.ReadLine();
        }
    }
}
