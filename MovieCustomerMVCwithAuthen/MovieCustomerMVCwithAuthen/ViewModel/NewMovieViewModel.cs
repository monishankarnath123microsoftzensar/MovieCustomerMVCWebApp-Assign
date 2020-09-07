using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieCustomerMVCwithAuthen.Models;

namespace MovieCustomerMVCwithAuthen.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        //public Movie Movie { get; set; }
        public int? Id { get; set; }
        [Required(ErrorMessage = "Movie Name is required.")]
        public string MovieName { get; set; }
        public int? GenreId { get; set; }
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        [Required(ErrorMessage = "Number in Stock is required.")]
        [Range(1, 20)]
        public int InStock { get; set; }

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            MovieName = movie.MovieName;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            InStock = movie.InStock;
        }
    
    }
}