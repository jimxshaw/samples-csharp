using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookEntity.Models
{
    public class ModelGroup
    {
        [Table("Books")] // Table name
        public class Book
        {
            [Key] // Primary key
            public int BookID { get; set; }

            public string BookName { get; set; }

            public string ISBN { get; set; }

            // This is to maintain the many reviews associated with a book entity
            public virtual ICollection<Review> Review { get; set; } 
        }

        [Table("Reviews")] // Table name
        public class Review
        {
            [Key]
            public int ReviewID { get; set; }

            [ForeignKey("Book")]
            public int BookID { get; set; }

            public string ReviewText { get; set; }

            // This will keep track of the book of which this particular review belongs
            public virtual Book Book { get; set; }
        }
    }
}