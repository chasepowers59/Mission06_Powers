using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Mission06_Powers.Models;


namespace Mission6.Controllers
{
   
    public class HomeController : Controller
    {
        private Mission06Context _context; // whenever the HomeController is made, create instance of database
        public HomeController(Mission06Context DataInstance) // constructor for home controller
        {
            _context = DataInstance;
        }
        public IActionResult Index() //main page
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies() // get move review
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(Application results) //post/submit movie review
        {
            _context.Applications.Add(results); // add the result/record to the database
            _context.SaveChanges();
            return View("Index", results);
        }
        public IActionResult GetToKnowJoel() // 2nd page
        {
            return View();
        }
    }
}
