using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController() {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Movies" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movies = this._context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        // GET: Movies/Details/{id}
        public ActionResult Details(int id)
        {
            var movie = this._context.Movies
                         .Include(m => m.Genre)
                         .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movies/New
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies/Edit/{id}
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie.Id == 0)
                return HttpNotFound();
            
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel(movie) {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // POST: Movies/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) {
                _context.Movies.Add(movie);
            }
            else {
                var movieDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.DateAdded = movie.DateAdded;
                movieDb.GenreId = movie.GenreId;
                movieDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }

        /**********************************
         * 
         * Exemplos


        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Avatar" },
                new Movie { Id = 2, Name = "King Kong" }
            };
        }

        public ActionResult Edit(int id)
        {
            return Content($"id={id}");
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 1;
            sortBy = !string.IsNullOrEmpty(sortBy) ? sortBy : "Name";

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        ***********************************/
    }
}