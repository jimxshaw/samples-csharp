using System;

namespace Amazon
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
}