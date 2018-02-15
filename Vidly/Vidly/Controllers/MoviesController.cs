using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
            var movies = this.GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Avatar" },
                new Movie { Id = 2, Name = "King Kong" }
            };
        }

        /**********************************
         * 
         * Exemplos

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