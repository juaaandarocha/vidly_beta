using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }

        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(movies);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = this._context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        // POST api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);

            this._context.Movies.Add(movie);
            this._context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movieDto);
        }

        // PUT api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = this._context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            Mapper.Map(movieDto, movie);

            this._context.SaveChanges();

            return Ok();
        }

        // DELETE api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = this._context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            this._context.Movies.Remove(movie);
            this._context.SaveChanges();

            return Ok();
        }
    }
}
