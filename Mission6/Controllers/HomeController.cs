using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Powers.Models;
using System.Diagnostics;


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

        public IActionResult EnterMovies() // takes the values in Categories and makes a list
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult EnterMovies(Movies results) // inputting a new movie into the database, POST 
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                return View(results);
            }

            _context.Movies.Add(results);
            _context.SaveChanges();

            TempData["Success"] = "Movie saved successfully!";
            return RedirectToAction("Index");
        }


        public IActionResult GetToKnowJoel() // 2nd page
        {
            return View();
        }

        public IActionResult DisplayMovies() // Taking info from the database, passing it to a new view (query)
        {
            //Link Query
            var movies = _context.Movies
                                    .Include(m => m.Category)
                                    .OrderBy(m => m.MovieID)
                                    .ToList();

            return View("DisplayMovies", movies); // view and model, MOST WE CAN DO! no more.
        }

        [HttpGet]
        public IActionResult Edit(int id) // NAME MUST MATCH ROUTE!!!!
        {
            var MovieToEdit = _context.Movies.Single(x => x.MovieID == id); // grab 1 record from movies db

            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View("EnterMovies", MovieToEdit); // need the viewbag, so we use it here too - same thing
        }

        [HttpPost]
        public IActionResult Edit(Movies movie)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("DisplayMovies"); // need to use the action, because the action pulls in db data
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var DeleteRecord = _context.Movies.Single(x => x.MovieID == id);

            return View(DeleteRecord); // it will pass the record to the Delete view
        }
        [HttpPost]
        public IActionResult Delete( Movies movie)
        {
            _context.Movies.Remove(movie); // make change
            _context.SaveChanges(); // confirm the change

            return RedirectToAction("DisplayMovies");
        }
    }
}
