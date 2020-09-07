using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuthen.Models;

namespace MovieCustomerMVCwithAuthen.Controllers.Api
{
    public class MovieApiController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MovieApiController()
        {
            _context = new ApplicationDbContext();
        }
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
