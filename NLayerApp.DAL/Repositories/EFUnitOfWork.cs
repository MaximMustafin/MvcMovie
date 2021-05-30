using MvcMovie.NLayerApp.DAL.EF;
using MvcMovie.NLayerApp.DAL.Entities;
using MvcMovie.NLayerApp.DAL.Interfaces;
using System;

namespace MvcMovie.NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private readonly MvcMovieContext db;
        private MovieRepository movieRepository;

        public EFUnitOfWork(MvcMovieContext _db)
        {
            db = _db;
        }
        public IRepository<Movie> Movies
        {
            get
            {
                if (movieRepository == null)
                    movieRepository = new MovieRepository(db);
                return movieRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
