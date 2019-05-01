using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using EFMovie.Data.Models;
using EFMovie.Data.Services;
using EFMovie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EFMovie.Web.Controllers
{
    
 public class MovieController : BaseController
    {
        
         private readonly MovieDbService svc;
          
         public MovieController()
         {
             svc = new MovieDbService();
             
         }

        // GET: Movies/Index     
        public ViewResult Index (string order = null)
        {
            var m = svc.GetAllMovies(order);
            return View (m); 
        }

        // GET: Movie/Details/5
        public IActionResult Details(int id)
        {
            var movie = svc.GetMovieById(id);
            if (movie == null)
            {
                Alert ("Movie Not Found", AlertType.warning);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        //// GET: Movie/Create
        public IActionResult Create()
        {
            //render blank form

            return View();
        }

        //// POST: Movie/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // add movie via service
                var m = svc.AddMovie(movie);  
                Alert("Movie created successfully",AlertType.success);    
                //redirect to newly created movie details view (not index)
                return RedirectToAction(nameof(Details), new { Id = m.Id});
            }
            //displaying the form for editing 
            return View(movie);
        }

        //// GET: Movie/Edit/5
        public IActionResult Edit(int id)
        { 
            var m = svc.GetMovieById(id);
           
           return View(m);
        }

        //// POST: Movie/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {

            if (ModelState.IsValid)
            {
                svc.UpdateMovie(movie);      
                //redirect to newly created movie details view (not index)
                return RedirectToAction(nameof(Index));
            }
            //displaying the form for editing 
            

           return View(movie);
        }

        //// GET: Movie/Delete/5
        public IActionResult Delete(int id)
        {
            var m = svc.GetMovieById(id);

            return View(m);
        }

        //// POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            svc.DeleteMovie(id); 

           return RedirectToAction(nameof(Index)); 
        }
      
  
        /// GET: Movie/AddReview/1 
        [HttpGet]
        public IActionResult AddReview(int id) 
        {
            var r = svc.GetMovieById(id);

             if(r == null)
             {
                 return NotFound(); 
             }

            var rvm = new Review { MovieId = id };

            return View(rvm);  
            //return View(r); 
        }
 
        /// POST: Movie/AddReview/1 
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult AddReview([Bind("CreatedOn,MovieId,Name,Comment,Rating")] Review review)
        public IActionResult AddReview(Review review)  
        {
            if (ModelState.IsValid)
            {
                review.CreatedOn=DateTime.Now;
                svc.AddReview(review);
                //return RedirectToAction(nameof(Details), new{ Id = review.MovieId});
                return RedirectToAction(nameof(Index)); 
            }

            return View(review);
        }
        
        /// GET: Movie/DeleteReview/1 
        public IActionResult DeleteReview(int id)

        {
            var r = svc.GetReviewById(id);
            if (r == null)
            {
                return NotFound(); 
            }

             return View(r);
        }
        
        /// POST: Movie/DeleteReview/1 
        [HttpPost]   
        [ValidateAntiForgeryToken]
        public IActionResult DeleteReviewConfirmed(int id)
        {
           if (ModelState.IsValid)
           {
            svc.DeleteReview(id);     
            
            return RedirectToAction(nameof(Index));   
           }
           return View(id); 
           
        }
    }
}