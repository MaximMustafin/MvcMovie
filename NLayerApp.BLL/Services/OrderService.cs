using MvcMovie.NLayerApp.BLL.DTO;
using MvcMovie.NLayerApp.BLL.Interfaces;
using MvcMovie.NLayerApp.DAL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using MvcMovie.NLayerApp.DAL.Entities;
using MvcMovie.NLayerApp.BLL.Infrastructure;

namespace MvcMovie.NLayerApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Movie, MovieDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Movie>, List<MovieDTO>>(Database.Movies.GetAll());
        }

        public MovieDTO GetMovie(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id фильма", "");
            var movie = Database.Movies.Get(id.Value);
            if (movie == null)
                throw new ValidationException("Фильм не найден", "");

            return new MovieDTO { Id = movie.Id, Title = movie.Title, ReleaseDate = movie.ReleaseDate,
                                  Price = movie.Price, Genre = movie.Genre, Rating = movie.Rating,
                                  Quality = movie.Quality };
        }
        
        public void CreateMovie(MovieDTO movieDTO)
        {
            var movie = CreateMovieInstance(movieDTO);     
            Database.Movies.Create(movie);
            Database.Save();
        }

        public void UpdateMovie(MovieDTO movieDTO)
        {
            var movie = CreateMovieInstance(movieDTO);
            Database.Movies.Update(movie);
            Database.Save();
        }
        
        public void DeleteMovie(int id)
        {
            var movie = Database.Movies.Get(id);
            if (movie == null)
            {
                throw new ValidationException("Фильм не найден", "");
            }
            Database.Movies.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        private Movie CreateMovieInstance(MovieDTO movieDTO) => new Movie()
        {
            Id = movieDTO.Id,
            Title = movieDTO.Title,
            ReleaseDate = movieDTO.ReleaseDate,
            Price = movieDTO.Price,
            Genre = movieDTO.Genre,
            Rating = movieDTO.Rating,
            Quality = movieDTO.Quality
        };
    }
}
