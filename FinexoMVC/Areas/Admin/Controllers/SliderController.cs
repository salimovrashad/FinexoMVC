using FinexoMVC.Areas.Admin.ViewModels;
using FinexoMVC.Context;
using FinexoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinexoMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        FinexoDbContext _context {  get; }

        public SliderController(FinexoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateItemVM vm)
        {
            Blog blog = new Blog()
            {
                Description = vm.Description,
                Name = vm.Name,
            };
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var item = await _context.Blogs.FindAsync(id);
            return View(new SliderUpdateItemVM
            {
                Description = item.Description,
                Name = item.Name,
            });
        }

        [HttpPost]

        public async Task<IActionResult> Update(SliderUpdateItemVM vm, int id)
        {
            var item = await _context.Blogs.FindAsync(id);
            item.Description = vm.Description;
            item.Name = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) 
        {
            var item = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
