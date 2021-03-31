using Microsoft.EntityFrameworkCore;
using MvcMovie.NLayerApp.DAL.Entities;
using Microsoft.Extensions.Logging;

namespace MvcMovie.NLayerApp.DAL.EF
{
    public class MvcMovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information)
                  .AddConsole();
        });
    }
}
