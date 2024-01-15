using FinexoMVC.Context;
using Microsoft.AspNetCore.Mvc;

namespace FinexoMVC.Controllers
{
    public class HomeController : Controller
    {
        FinexoDbContext _db { get; }

        public HomeController(FinexoDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Blogs.ToList());
        }
    }
}
