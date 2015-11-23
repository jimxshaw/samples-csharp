using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookEntity
{
    public class BooksDbContext : DbContext
    {
        // This context class can perform CRUD operations on the Book and 
        // Review models since it has the DbSet defined for both of them. 
        public DbSet<Models.ModelGroup.Book> Books { get; set; }
        public DbSet<Models.ModelGroup.Review> Reviews { get; set; }
    }
}