using Microsoft.EntityFrameworkCore;
using MvcMovie.NLayerApp.DAL.EF;
using MvcMovie.NLayerApp.DAL.Entities;
using MvcMovie.NLayerApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.NLayerApp.DAL.Repositories
{
    public class MovieRepository:IRepository<Movie>
    {
        private readonly MvcMovieContext db;

        public MovieRepository(MvcMovieContext context)
        {
            this.db = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies;
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public void Create(Movie book)
        {
            db.Movies.Add(book);
        }

        public void Update(Movie book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Movie> Find(Func<Movie, Boolean> predicate)
        {
            return db.Movies.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Movie book = db.Movies.Find(id);
            if (book != null)
                db.Movies.Remove(book);
        }
    }
}
