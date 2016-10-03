using System;

namespace NewDatingSite.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }

        public Profile Profile { get; set; }
    }
}
