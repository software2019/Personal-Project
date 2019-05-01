using System;
using EFMovie.Data.Models;

namespace EFMovie.Data.Services
{
    public static class MovieDbServiceSeeder
    {
        public static void Seed(IMovieService svc)
        {
            //re-initialise the database then populate with seed data
            //svc.Initialise();

            //Create four movies with related fields
            //var m1 = svc.AddMovie(new Movie 
            //{Title = "Shazam!", Year = 2019, Director = "David F. Sandberg", Duration  = 132, Cast = "Bill Parker,C.C. Beck ",  Budget = 8.0, PosterUrl = "https://image.tmdb.org/t/p/w1280/xnopI5Xtky18MPhK40cZAGAOVeV.jpg", Plot ="A boy is given the ability to become an adult superhero in times of need with a single magic word. " });

           // var m2 = svc.AddMovie(new Movie 
            //{Title = "Glass", Year = 2019, Director = "M. Night Shyamalan", Duration  = 130, Cast = "Kevin Wendell Crumb / Patricia / Dennis / Hedwig / The Beast / Barry / Heinrich / Jade / Ian / Mary Reynolds / Norma / Jalin / Kat / B. T. / Mr. Pritchard / Felida / Luke / Goddard / Samuel / Polly", Budget = 20.0, PosterUrl = "https://image.tmdb.org/t/p/w1280/svIDTNUoajS8dLEo7EosxvyAsgJ.jpg", Plot ="In a series of escalating encounters, security guard David Dunn uses his supernatural abilities to track Kevin Wendell Crumb, a disturbed man who has twenty-four personalities. Meanwhile, the shadowy presence of Elijah Price emerges as an orchestrator who holds secrets critical to both men. " });

           // var m3 = svc.AddMovie(new Movie 
           // {Title = "Logan", Year = 2017, Director = "James Mangold", Duration  = 137, Cast = "John Romita, Sr., Chris Claremont,Len Wein", Budget = 97.0, PosterUrl = "https://image.tmdb.org/t/p/w1280/gGBu0hKw9BGddG8RkRAMX7B6NDB.jpg", Plot ="In the near future, a weary Logan cares for an ailing Professor X in a hideout on the Mexican border. But Logan's attempts to hide from the world and his legacy are upended when a young mutant arrives, pursued by dark forces. " });
           
            //var m4 = svc.AddMovie(new Movie 
            //{Title = "Thor", Year = 2011, Director = "Kenneth Branagh", Duration  = 115, Cast = "Chris Hemsworth, Natalie Portman", Budget = 150.0, PosterUrl = "https://image.tmdb.org/t/p/w1280/9zDwvsISU8bR15R2yN3kh1lfqve.jpg", Plot ="Against his father Odin's will, The Mighty Thor - a powerful but arrogant warrior god - recklessly reignites an ancient war. Thor is cast down to Earth and forced to live among humans as punishment. Once here, Thor learns what it takes to be a true hero when the most dangerous villain of his world sends the darkest forces of Asgard to invade Earth." });
           
            //    //Create three reviews 
           // var r1 = svc.AddReview (new Review{Name = "Michael", CreatedOn = new DateTime (2017, 05, 10), Comment = "Not Too Bad", Rating = 2});
        
           //    var r2 = svc.AddReview (new Review{Name = "David", CreatedOn = new DateTime (2018, 09, 19), Comment = "Good, sos so", Rating = 1});

        }
    }
}