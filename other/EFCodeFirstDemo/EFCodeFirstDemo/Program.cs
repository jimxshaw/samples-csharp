using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    // Db Context class is an abstraction over the database that
    // is used to load or save data.
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
