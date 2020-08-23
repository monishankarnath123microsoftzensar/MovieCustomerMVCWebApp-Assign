using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCustomerMVCwithAuthen.Models;

namespace MovieCustomerMVCwithAuthen.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}