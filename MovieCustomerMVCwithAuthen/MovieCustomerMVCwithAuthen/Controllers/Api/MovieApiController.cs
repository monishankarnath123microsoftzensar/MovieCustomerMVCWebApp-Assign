using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuthen.Models;
using System.Data.Entity;

namespace MovieCustomerMVCwithAuthen.Controllers.Api
{
    public class MovieApiController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MovieApiController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Movie> GetMovie()
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList();
            return movie;
            //return _context.Customers.ToList();
        }
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movie;
        }
        //Post /api/customerapi
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }
        //Put /api/customerapi/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            var movieInDb = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movieInDb.MovieName = movie.MovieName;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.InStock = movie.InStock;
            _context.SaveChanges();
        }
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
