using Microsoft.AspNetCore.Mvc;
using PDP._7_Modul.Vazifa_1.Models;
using PDP._7_Modul.Vazifa_1.Service;

namespace PDP._7_Modul.Vazifa_1.Controllers
{
    
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            var categories=  _categoryService.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int id, string name, string description)
        {
            var category = new Category(id, name, description);
            _categoryService.Create(id,name,description);

            return RedirectToAction("Details","Categories",new {id = id });
        }
        public IActionResult Details(int id)
        {
            var category = _categoryService.GetById(id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);

            if(category is null) { return NotFound(); }

            _categoryService.Delete(id);

            return RedirectToAction("Index","Categories");
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);

            if(category is null) { return NotFound(); };

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(int id, string name, string description)
        {
            var category = new Category(id, name, description);
            _categoryService.Update(category);

            return RedirectToAction("Details", "Categories", new { id = category.Id });
        }
    }
}
 