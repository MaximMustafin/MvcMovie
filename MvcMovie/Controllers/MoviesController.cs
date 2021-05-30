using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.NLayerApp.BLL.DTO;
using MvcMovie.NLayerApp.BLL.Interfaces;
using MvcMovie.NLayerApp.WEB.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        readonly IOrderService orderService;

        public MoviesController(IOrderService serv)
        {
            orderService = serv;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string movieQuality, int movieReleaseYear)
        {
            IEnumerable<MovieDTO> movies = orderService.GetMovies();

            IEnumerable<string> qualityQuery = movies.Select(x => x.Quality);

            IEnumerable<int> releaseYearQuery = movies.Select(x => x.ReleaseDate.Year);

            if (!string.IsNullOrEmpty(movieQuality))
            {
                movies = movies.Where(x => x.Quality == movieQuality);
            }

            if (movieReleaseYear != 0)
            {
                movies = movies.Where(x => x.ReleaseDate.Year == movieReleaseYear);
            }

            var movieQualityAndReleaseYearVM = new MovieQualityAndReleaseYearViewModel
            {
                ReleaseYears = new SelectList(releaseYearQuery.Distinct().OrderByDescending(x => x).ToList()),
                Qualities = new SelectList(qualityQuery.Distinct().ToList()),
                Movies = movies.ToList()
            };

            return View(movieQualityAndReleaseYearVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = orderService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Quality")] MovieDTO movie)
        {
            if (ModelState.IsValid)
            {
                orderService.CreateMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = orderService.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Quality")] MovieDTO movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderService.UpdateMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = orderService.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            orderService.DeleteMovie(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return orderService.GetMovies().Any(e => e.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}
