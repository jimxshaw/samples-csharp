using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEntity.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }
    }
}