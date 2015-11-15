using System;

namespace Properties
{
    public class Person
    {
        public string Name { get; set; }
        public string Username { get; set; }
        // A private set access means it is readonly. It cannot
        // be changed. It must be set in the constructor.
        public DateTime Birthdate { get; private set; }

        public Person(DateTime birthdate)
        {
            Birthdate = birthdate;
        }

        public int Age
        {
            get
            {
                var timeSpan = DateTime.Today - Birthdate;
                var years = timeSpan.Days / 365;

                return years;
            }
        }
    }
}