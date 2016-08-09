using System;
using System.Collections.Generic;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Star Wars",
                    Rating = 9.3f,
                    Year = 1977
                },
                new Movie()
                {
                    Title = "Fellowship of the Ring",
                    Rating = 8.7f,
                    Year = 2001
                },
                new Movie()
                {
                    Title = "Star Trek II The Wrath of Khan",
                    Rating = 7.9f,
                    Year = 1983
                },
                new Movie()
                {
                    Title = "Batman Begins",
                    Rating = 8.1f,
                    Year = 2005
                },
                new Movie()
                {
                    Title = "American Beauty",
                    Rating = 8.3f,
                    Year = 1999
                },
                new Movie()
                {
                    Title = "Fear and Loathing in Las Vegas",
                    Rating = 7.7f,
                    Year = 1994
                },
                new Movie()
                {
                    Title = "Reservoir Dogs",
                    Rating = 7.9f,
                    Year = 1992
                },
                new Movie()
                {
                    Title = "Suicide Squad",
                    Rating = 6.3f,
                    Year = 2016
                }
            };

            // The Filter method is not part of LINQ but is our own custom implementation that behaves like
            // LINQ's Where method. It's implemented in our MyLinq class.
            var query = movies.Filter(m => m.Year > 1995);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
