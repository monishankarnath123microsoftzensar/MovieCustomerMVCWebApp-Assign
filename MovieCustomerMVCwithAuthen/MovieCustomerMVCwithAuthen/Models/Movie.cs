using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVCwithAuthen.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string MovieName { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}