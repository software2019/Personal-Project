using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace EFMovie.Data.Models
{
    // genre enumeration 
    public enum Genre { Action, Comedy, Family, Horror, Romance, SciFi, Thriller, Western, War}

    // Class representing a table in our database
    public class Movie {
      public Movie()
      {
        // initialise the Reviews relationship
        Reviews = new List<Review>();
      }

     // The auto property syntax
     // An int field named Id will by convention be used as primary key
      public int Id { get; set; } 
      
      [Required]
      [StringLength (100, ErrorMessage = "Maximum 100 characters allowed")]
      public string Title { get; set; }

      [Required]
      public int Year { get; set; }

      [Required]
      [StringLength (100, ErrorMessage = "Maximum 100 characters allowed")]
      public string Director { get; set; }

      [Required]
      [Range (1, 400, ErrorMessage = "Must be between 1 and 400")]
      public int Duration { get; set; }

      [Required]
      public string Cast { get; set; }

      [Required]
      [Range (0.0, 500.00, ErrorMessage = "Must be between 0.0 and 500.0")]
      public double Budget { get; set; }

      [Required]
      [StringLength (500, ErrorMessage = "Maximum 500 characters allowed")]
      public string Plot { get; set; } 
      
      [Required]
      public string PosterUrl { get; set; }
     
        //Read only property 
       public int ReviewsCount 
          { 
            get 
            {
              return Reviews.Count;
            }   
          } 
       public double Rating
       { 
         get {
           if(ReviewsCount > 0){
             var x = (Reviews.DefaultIfEmpty().Average(s=> s.Rating)*10);
             return x;
             }
             return 0.0;
             }
       }    

        // Navigation property 
        [Required]
         public Genre Genre { get; set; }
         public IList <Review> Reviews { get; set;} 
        
    
    }//class

}//namespace