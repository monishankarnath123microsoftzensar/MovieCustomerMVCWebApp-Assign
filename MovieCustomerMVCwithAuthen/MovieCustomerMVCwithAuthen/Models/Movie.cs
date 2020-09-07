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
        [Required(ErrorMessage = "Movie Name is required.")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime? ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        [Display(Name ="Number in Stock")]
        [Required(ErrorMessage = "Number in Stock is required.")]
        [Range(1,20)]
        public int InStock { get; set; }
    }
}