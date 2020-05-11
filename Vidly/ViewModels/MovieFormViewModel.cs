using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter the Movie Name.")]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select a Genre.")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Please enter the Release Date.")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The Stock Number must be between 1 and 20.")]
        [Display(Name = "Number in Stock")]
        public short? NumbInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumbInStock = movie.NumbInStock;
        }
    }
}