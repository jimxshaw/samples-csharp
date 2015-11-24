using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstDemoEntities();
            var post = new Post()
            {
                PostID = 1,
                Title = "Entity Framework Database First Example",
                DatePublished = DateTime.Now,
                Body = "This is a sample app that demonstrates Entity Framework with the Database First approach."
            };

            context.Posts.Add(post);

            context.SaveChanges();
        }
    }
}
