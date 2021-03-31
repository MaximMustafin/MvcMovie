using MvcMovie.NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;

namespace MvcMovie.NLayerApp.BLL.Interfaces
{
    public interface IOrderService: IDisposable
    {
        MovieDTO GetMovie(int? id);
        IEnumerable<MovieDTO> GetMovies();
        void CreateMovie(MovieDTO movie);
        void UpdateMovie(MovieDTO movie);
        void DeleteMovie(int id);
        void Dispose();
    }
}
