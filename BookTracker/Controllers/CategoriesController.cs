using BookTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Controllers
{
    public class CategoriesController : Controller
    {
        public BookTrackerContext _DbContext { get; set; }
        public CategoriesController(BookTrackerContext bookTrackerContext)
        {
            _DbContext = bookTrackerContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _DbContext.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            var categoryTypes = _DbContext.CategoryTypes.ToList();
            categoryTypes.Insert(0, new CategoryType { Name = "Select", Type = 0 });
            ViewBag.CategoryTypes = categoryTypes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Categories.Add(category);
                _DbContext.SaveChanges();
                TempData["SuccessMsg"] = "Category added successfully.";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? categoryId)
        {
            var category = _DbContext.Categories.Find(categoryId);
            var categoryTypes = _DbContext.CategoryTypes.ToList();
            categoryTypes.Insert(0, new CategoryType { Name = "Select", Type = 0 });
            ViewBag.CategoryTypes = categoryTypes;

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Categories.Update(category);
                _DbContext.SaveChanges();
                TempData["SuccessMsg"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? categoryId)
        {
            var category = _DbContext.Categories.Find(categoryId);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? categoryId)
        {
            var category = _DbContext.Categories.Find(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _DbContext.Categories.Remove(category);
            _DbContext.SaveChanges();
            TempData["SuccessMsg"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
