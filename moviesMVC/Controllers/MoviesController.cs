using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moviesMVC.Data;

namespace moviesMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _db;
        public MoviesController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var movies = await _db.Movies
                                  .OrderBy(m => m.Title)
                                  .Take(10)
                                  .ToListAsync();
            return View(movies);
        }
    }
}
