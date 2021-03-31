using MvcMovie.NLayerApp.DAL.Entities;
using System;


namespace MvcMovie.NLayerApp.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Movie> Movies { get; }
        void Save();
    }
}
