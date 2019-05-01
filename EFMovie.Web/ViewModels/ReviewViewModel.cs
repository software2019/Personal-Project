using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFMovie.Web.Controllers;

namespace EFMovie.Web.ViewModels 
{
    public class ReviewViewModel 
    {
    
        public int Id { get; set; }
        public SelectList Movies { set; get; }
        public int MovieId { get; set;}
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        
    }
}