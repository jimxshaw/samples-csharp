using System.Collections.Generic;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // The purpose of adding virtual in front of any reference type is so that during runtime,
        // our collection of reviews gets loaded. Reference types such as collections don't get
        // loaded by the Entity Framework by default. By adding virtual, the Entity Framework will
        // issue a query to pull the restaurant data and then issue a second query to pull the 
        // collection of reviews data. 
        public virtual ICollection<RestaurantReview> Reviews { get; set; }
    }
}