using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the Movie Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a Genre.")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Please enter the Release Date.")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "The Stock Number must be between 1 and 20.")]
        public short NumbInStock { get; set; }
    }
}