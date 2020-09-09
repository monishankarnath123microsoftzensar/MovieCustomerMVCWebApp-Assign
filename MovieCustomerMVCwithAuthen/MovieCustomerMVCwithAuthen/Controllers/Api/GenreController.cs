using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuthen.Models;

namespace MovieCustomerMVCwithAuthen.Controllers.Api
{
    public class GenreController : ApiController
    {
        private ApplicationDbContext _context;
        public GenreController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Genre> GetGenre()
        {
            var genre = _context.Genres.ToList();
            return genre;

        }
    }
}
