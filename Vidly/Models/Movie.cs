﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter the Movie Name.")]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        
        [Required(ErrorMessage = "Please select a Genre.")]
        public byte GenreId { get; set; }
        
        [Required(ErrorMessage = "Please enter the Release Date.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public DateTime DateAdded { get; set; }
        
        [Required(ErrorMessage = "This field is required.")]
        [Range(minimum:1, maximum:20, ErrorMessage = "The Stock Number must be between 1 and 20.")]
        [Display(Name = "Number in Stock")]
        public short NumbInStock { get; set; }

    }
}