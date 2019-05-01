using System;
using System.ComponentModel.DataAnnotations;

namespace EFMovie.Data.Models
{
    public class Review 
    {
        // Properties 
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximum 100 characters allowed")]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

         [Required]
         [StringLength(250, ErrorMessage = "Maximum 250 characters allowed")]
        public string Comment { get; set; }

         [Required]
         [Range (1, 10, ErrorMessage = "Must be between 1 and 10")]
        public int Rating { get; set; }
        
        // Foreign key relating to movie
        public int MovieId { get; set; }
        // Navigation property to navigate to the movie
        public Movie Movie { get; set; }

    }

}