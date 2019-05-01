using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFMovie.Web.ViewModels;


namespace EFMovie.Web.Controllers
{
    public class HomeController : Controller
    {
        //Action method
        public IActionResult Index() 
        {
            return View();//calling view method which uses a view template to generate an HTML RESPONSE
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}