using Microsoft.AspNetCore.Mvc;
using zadanie2.Models;

namespace zadanie2.Controllers
{
    public class MovieController : Controller
    {
        private static IList<MovieModel> films = new List<MovieModel>
        {
            new MovieModel(){Id = 1, Name = "Film1", Description = "opis filmu1", Price=3},
            new MovieModel(){Id = 2, Name = "Film2", Description = "opis filmu2", Price=5},
            new MovieModel(){Id = 3, Name = "Film3", Description = "opis filmu3", Price=3},
        };
        
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                films.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = films.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MovieModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var movieToUpdate = films.FirstOrDefault(x => x.Id == movie.Id);
                    var index = films.IndexOf(movieToUpdate);
                    films[index] = movie;
                }
                catch
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = films.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = films.FirstOrDefault(x => x.Id == id);
            if(movie != null)
                films.Remove(movie);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(films);
        }
    }
}
