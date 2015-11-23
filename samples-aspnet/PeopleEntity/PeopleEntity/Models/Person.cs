using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleEntity.Models
{
    public class Person
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }
    }
}