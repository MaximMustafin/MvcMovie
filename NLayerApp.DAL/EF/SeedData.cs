﻿using MvcMovie.NLayerApp.DAL.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcMovie.NLayerApp.DAL.EF
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Quality = "Full HD",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "R",
                        Quality = "CAMRip",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "R+",
                        Quality = "TS",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Quality = "4K",
                        Price = 3.99M
                    },

                    new Movie
                    {
                        Title = "Genesis Code",
                        ReleaseDate = DateTime.Parse("2020-1-7"),
                        Genre = "Triller",
                        Rating = "R",
                        Quality = "SD",
                        Price = 4.99M
                    },

                    new Movie
                    {
                        Title = "The Warrant",
                        ReleaseDate = DateTime.Parse("2020-3-3"),
                        Genre = "Western",
                        Rating = "R-",
                        Quality = "4K",
                        Price = 4.99M
                    },

                    new Movie
                    {
                        Title = "Terminator",
                        ReleaseDate = DateTime.Parse("1986-10-26"),
                        Genre = "Action",
                        Rating = "R",
                        Quality = "FullHD",
                        Price = 14.99M
                    },

                    new Movie
                    {
                        Title = "Whiplash",
                        ReleaseDate = DateTime.Parse("2014-10-23"),
                        Genre = "Drama",
                        Rating = "R",
                        Quality = "FullHD",
                        Price = 17.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
