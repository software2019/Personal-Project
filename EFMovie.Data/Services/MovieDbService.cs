using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


using EFMovie.Data.Models;
using EFMovie.Data.Repositories;

namespace EFMovie.Data.Services 
{
    public class MovieDbService:IMovieService
    {
        private readonly MovieDbContext db; 

        public MovieDbService () 
        {
            db = new MovieDbContext();
           // Initialise();
        }

        public void Initialise()
        {
           // db.Initialise();
        }

        /* MovieDbService class defines the IMovieService interface which has only method signatures. 
           This layer (services) uses the MovieDbContext in the repository to render the following data management functions:
         */
        
        
        //Get a List of movies (optionally ordered by title, director or year)
        public IList<Movie> GetAllMovies(string orderby = null )
        {
            if (orderby == "title")
            {
                return db.Movies
                                .Include (s => s.Reviews)
                                .OrderBy(m => m.Title)
                                .ToList();

            } else if (orderby == "year")
            {
                return db.Movies
                                .Include (s => s.Reviews)
                                .OrderBy(m => m.Year)
                                .ToList();

            } else if (orderby == "director")
            {
                return db.Movies
                                .Include (s => s.Reviews)
                                .OrderBy(m => m.Director)
                                .ToList();

            } else if (orderby=="genre")
            {
                return db.Movies
                                .Include (s => s.Reviews)
                                .OrderBy(m => m.Genre)
                                .ToList();
            }
            else 
            {
                return db.Movies
                                .Include (s => s.Reviews)
                                .ToList();
            }
            
            
        }


        // Get a Movie given its id
        public Movie GetMovieById(int id)
        {
            return db.Movies.Include(e => e.Reviews)
                            .FirstOrDefault (e => e.Id == id);
        }

        // Delete a Movie given its id
        public bool DeleteMovie(int id)
        {
            //check movie exists 
            var m = db.Movies.FirstOrDefault(s => s.Id == id);
              if (m == null) 
              {
                  return false;//cannot delete, movie does not exist
              }

            db.Movies.Remove(m);
            db.SaveChanges();
            return true;
        }

        // Update a Movie
        public bool UpdateMovie(Movie m)
        {
            //check that this movie exists 
            var u =  db.Movies.Include(s => s.Reviews)
                              .FirstOrDefault(s => s.Id == m.Id);
                              
            if ( u == null)
            {
                return false; 
            };

            //disconnecting entity from EF so that the new entity can be updated without any clash
            db.Entry(u).State = EntityState.Detached;

            //to show that this entity has changed
            db.Movies.Update(m);
            db.SaveChanges();

            return true; 
        }

        // Add a new Movie
       public  Movie AddMovie(Movie m)
        {
            db.Movies.Add(m);
            db.SaveChanges();

            return m; 
        }

        // Retrieve a Review given its id
        public Review GetReviewById(int id)
        {
            return db.Reviews.FirstOrDefault( e => e.Id == id);
        }

        // Add a new Review to a movie 
        public Review AddReview(Review r)
        {
            //Verify the movie exists 
            var exist = GetMovieById(r.MovieId);
            if (exist == null)
            {
                return null; 
            }
            //if movie exists, add the review to the movie
            db.Reviews.Add(r);
            db.SaveChanges();
            return r;
        }

        // Delete a Review given its id
        public bool DeleteReview(int id)
        { 

             var m = db.Reviews.FirstOrDefault(s => s.Id == id);
              if (m == null) 
              {
                  return false;
              }

            db.Reviews.Remove(m); 
            db.SaveChanges();
            return true;   
        }

        

        
    }


}