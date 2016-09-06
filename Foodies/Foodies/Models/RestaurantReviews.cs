﻿namespace Foodies.Models
{
    public class RestaurantReviews
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
    }
}