using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Mission06_Powers.Models;
using System.Diagnostics;
using System.Text;

namespace Mission06_Powers.Controllers
{
    public class HomeController : Controller
    {
        private Mission06Context _context;

        public HomeController(Mission06Context DataInstance)
        {
            _context = DataInstance;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies() 
        {
            ViewBag.Categories = _context.Categories // ViewBag packages up a list of values that we can use to display - great for dropdowns like we will use
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(Movies results)
        {
            Console.WriteLine("=== POST REQUEST RECEIVED ===");
            Console.WriteLine($"Title: {results?.Title}");
            Console.WriteLine($"Year: {results?.Year}");
            Console.WriteLine($"Edited: {results?.Edited}");
            Console.WriteLine($"CopiedToPlex: {results?.CopiedToPlex}");
            Console.WriteLine($"CategoryId: {results?.CategoryId}");
            Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");

            if (results == null)
            {
                ModelState.AddModelError("", "Movie data is missing.");
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                return View(results);
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("=== MODEL STATE ERRORS ===");
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    if (state != null && state.Errors.Count > 0)
                    {
                        Console.WriteLine($"Field: {key}");
                        foreach (var error in state.Errors)
                        {
                            Console.WriteLine($"  Error: {error.ErrorMessage}");
                        }
                    }
                }

                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                return View(results);
            }

            try
            {
                if (results.MovieID == 0)
                {
                    // Adding new movie
                    _context.Movies.Add(results);
                }
                else
                {
                    // Updating existing movie
                    _context.Movies.Update(results);
                }

                int recordsSaved = _context.SaveChanges();
                Console.WriteLine($"=== SUCCESS: {recordsSaved} record(s) saved ===");
                TempData["Success"] = results.MovieID == 0
                    ? "Movie added successfully!"
                    : "Movie updated successfully!";
                return RedirectToAction("DisplayMovies");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== DATABASE ERROR ===");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                ModelState.AddModelError("", $"Unable to save changes: {ex.Message}");
                ViewBag.Categories = _context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();
                return View(results);
            }
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        public IActionResult DisplayMovies()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.MovieID)
                .ToList();
            return View("DisplayMovies", movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var MovieToEdit = _context.Movies.Single(x => x.MovieID == id);
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("EnterMovies", MovieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies movie)
        {
            Console.WriteLine($"=== EDIT POST RECEIVED for MovieID: {movie.MovieID} ===");

            try
            {
                _context.Update(movie);
                int recordsSaved = _context.SaveChanges();
                Console.WriteLine($"=== EDIT SUCCESS: {recordsSaved} record(s) updated ===");
                return RedirectToAction("DisplayMovies");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== EDIT ERROR: {ex.Message} ===");
                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var DeleteRecord = _context.Movies.Single(x => x.MovieID == id);
            return View(DeleteRecord);
        }

        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            Console.WriteLine($"=== DELETE POST RECEIVED for MovieID: {movie.MovieID} ===");

            try
            {
                _context.Movies.Remove(movie);
                int recordsSaved = _context.SaveChanges();
                Console.WriteLine($"=== DELETE SUCCESS: {recordsSaved} record(s) deleted ===");
                return RedirectToAction("DisplayMovies");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== DELETE ERROR: {ex.Message} ===");
                throw;
            }
        }
    }
}
