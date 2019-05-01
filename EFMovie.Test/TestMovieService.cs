using System;
//using System.Linq;
using EFMovie.Data.Models;
using EFMovie.Data.Services;
using Xunit;

namespace EFMovie.Test
{
    public class TestMovieService
    {
        private readonly IMovieService svc;

        public TestMovieService() /* This Constructor is called on execution of each test method  */
        {                
           //general arrangement 
           svc = new MovieDbService();
          // svc.Initialise();
        }

        [Fact]
        public void GetAllMovies_with2Added_Shouldreturn2 ()
        {
            //arrange
            svc.AddMovie(new Movie 
            {Title = "The Neon demon", Year = 2016, Director = "Nicolas Jon", Duration  = 120, Cast = "Mike Myers", Budget = 1.5, PosterUrl = "https://www.amazon.co.uk/Imaginaerum-Fra", Plot ="This film opens with the roar and echo of a stadium concert " });
            svc.AddMovie(new Movie 
            {Title = "A Star is Born", Year = 2018, Director = "John M Chau", Duration  = 130, Cast = "", Budget = 7.0, PosterUrl = "https://www.amazon.co.uk/Imaginaerum-Fra", Plot ="This film opens with the r " });
            
            //act
            var movies = svc.GetAllMovies();
            var count = movies.Count;
            //var count = svc.MovieCount();
            
            //assert
            Assert.Equal (2, count);
            
        }

         [Fact]
        public void GetAllMovies_withNoMovieAdded_Shouldreturn0 ()
        {
            //act
             var movies = svc.GetAllMovies();
            var count = movies.Count;

            //assert
            Assert.Equal(0, count);
            
        }


        [Fact]
        public void GetMovieById_NewDb_ShouldReturnNull ()
        {
            //act
            var movie = svc.GetMovieById(1);
            //assert
            Assert.Null(movie);
            
        }

         [Fact]
        public void GetMovieById_AddedToDb_ShouldExist ()
        {
            //act
            var m = svc.AddMovie(new Movie 
            {Title = "The Neon demon", Year = 2016, Director = "Nicolas Jon", Duration  = 120, Cast = "Mike Myers", Budget = 1.5, PosterUrl = "https://www.amazon.co.uk/Imaginaerum-Fra", Plot ="This film opens with the roar and echo of a stadium concert " });
            var movie = svc.GetMovieById(m.Id);
            //assert
            Assert.NotNull(movie);
            
        }
        
        [Fact]
        public void DeleteMovie_thatExists_ShouldWork()
        {
            //act
            var s = svc.AddMovie(new Movie 
            {Title = "A Star is Born", Year = 2016, Director = "John M Chau", Duration  = 130, Cast = "", Budget = 7.0, PosterUrl = "https://www.amazon.co.uk/Imaginaerum-Fra", Plot ="This film opens with the r " });

            var deleted = svc.DeleteMovie(s.Id);

            //assert
            Assert.True(deleted);
        }
        
        [Fact]
        public void DeleteMovie_thatDoesntExist_ShouldNotWork()
        {
            //act
            var deleted = svc.DeleteMovie(0);

            //assert
            Assert.False(deleted);
        }

        //Update method will go here
        [Fact]
         public void UpdateMovie_thatExists_ShouldWork()
        {
            //act
            var s = svc.AddMovie(new Movie 
            {Title = "A Star is Born", Year = 2016, Director = "John M Chau", Duration  = 130, Cast = "", Budget = 7.0, PosterUrl = "https://www.amazon.co.uk/Imaginaerum-Fra", Plot ="This film opens with the r " });
            var ms = svc.GetMovieById(s.Id);

            var Updated = svc.UpdateMovie(ms);

            //assert
            Assert.True(Updated);
        }

        [Fact]
         public void UpdateMovie_thatDoesntExist_ShouldntWork()
        {
            //act
        
            var Updated = svc.UpdateMovie(new Movie { Id = 0 });

            //assert
            Assert.False(Updated);
        }

        

        [Fact]
        public void AddMovie_NewDb_ShouldExist()
        {
           //act: add, retrieve/read, check
            var m = svc.AddMovie(new Movie 
            {Title = "A Star is Born", Year = 2018, Director = "John M Chau", Duration  = 130, Cast = "", Budget = 7.0, PosterUrl = "https://www.amazon.co.uk/Imaginaerum-Fra", Plot ="This film opens with the r " });
           var ms = svc.GetMovieById(m.Id);
           //assert
           Assert.Equal(m.Id, ms.Id);

        }

        [Fact]
        public void AddMovie_NotAddedToNewDb_ShouldReturnNull()
        {
           //act: add, retrieve/read, check
            
           var ms = svc.GetMovieById(0);
           //assert
           Assert.Null(ms);

        }

          [Fact]
        public void GetReviewById_NewDb_ShouldReturnNull ()
        {
            //act
            var review = svc.GetReviewById(3);
            //assert
            Assert.Null(review);
            
        }

        [Fact]
        public void AddReview_NewDb_ShouldExist ()
        {
            //act
            var r = svc.AddReview (new Review{Name = "Shidur", CreatedOn = new DateTime (2019, 04, 05), Comment = "Excellent movie", Rating = 3});
            var review = svc.GetReviewById(r.MovieId);
            

            //Assert
            Assert.Equal(r.Id, review.Id);

        } 

        [Fact]
        public void DeleteReview_ThatExists_ShouldWork()
        {
            //act
            var r = svc.AddReview ( new Review { Name = "Shidur", CreatedOn = new DateTime (2019, 04, 05), Comment = "Excellent movie", Rating = 3});

            
            var deleted = svc.GetReviewById(r.MovieId);
            var d = svc.DeleteReview (r.Id);

            //Assert
            Assert.True(d);
        }

        [Fact]
        public void DeleteReview_ThatDoesntExist_ShouldNotWork() //Passed!
        {
            //act
            var deleted = svc.DeleteReview(0);

            //Assert
           Assert.False(deleted);
       } 

    



            

    }
}