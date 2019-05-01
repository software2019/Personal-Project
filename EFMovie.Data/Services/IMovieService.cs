using System.Collections.Generic;
using EFMovie.Data.Models;


namespace EFMovie.Data.Services
{
    //This interface describes the operations for a MovieDbService
    public interface IMovieService
    {
        //void Initialise();
        IList<Movie> GetAllMovies(string orderBy = null);
        Movie GetMovieById(int id);
        bool DeleteMovie(int id);
        bool UpdateMovie(Movie m);
        Movie AddMovie(Movie m); 
        Review GetReviewById(int id);
        Review AddReview(Review r);
        bool DeleteReview(int id); 
    
    }
}