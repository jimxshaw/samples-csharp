using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEntity.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        public int BookID { get; set; }

        public string ReviewText { get; set; }
    }
}