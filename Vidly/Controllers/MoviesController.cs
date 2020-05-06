using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieDb.DateAdded = DateTime.Now;
                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.GenreId = movie.GenreId;
                movieDb.NumbInStock = movie.NumbInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var movie = _context.Movies.Single(m => m.Id == id);

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //return View(movie);
            //return Content("Hello World!")
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});

            return View(viewModel);

        }

        // movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre);

            return View(movies);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public ActionResult Detail(int? id)
        {
            if (id.HasValue)
            {
                var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(n => n.Id == id);

                if (movie != null)
                {
                    return View(movie);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}