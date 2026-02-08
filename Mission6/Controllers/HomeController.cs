using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Powers.Models;


namespace Mission06_Powers.Controllers
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
        public IActionResult EnterMovies()
        {
            return View(new Application());
        }


        [HttpPost]
        public IActionResult EnterMovies(Application results)
        {
            if (!ModelState.IsValid)
                return View(results);

            _context.Applications.Add(results);
            _context.SaveChanges();

            TempData["Success"] = "Movie saved successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult GetToKnowJoel() // 2nd page
        {
            return View();
        }
    }
}
