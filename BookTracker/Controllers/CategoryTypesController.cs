using BookTracker.Models;
using BookTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Controllers
{
    public class CategoryTypesController : Controller
    {
        public BookTrackerContext _DbContext { get; }
        public CategoryTypesController(BookTrackerContext bookTrackerContext)
        {
            _DbContext = bookTrackerContext;
        }
        public IActionResult Index()
        {
            var categoryTypeList = _DbContext.CategoryTypes.ToList();
            return View(categoryTypeList);
        }

        public IActionResult Edit(int? categoryTypeId)
        {
            var categoryType = _DbContext.CategoryTypes.Find(categoryTypeId);

            if (categoryType == null)
            {
                return NotFound();
            }
            return View(categoryType);
        }

        public IActionResult Create(CategoryType categoryType)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Add(categoryType);
                _DbContext.SaveChanges();
                TempData["SuccessMsg"] = "Category type added successfully.";
                return RedirectToAction("Index");
            }
            return View(categoryType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryType categoryType)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Update(categoryType);
                _DbContext.SaveChanges();
                TempData["SuccessMsg"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(categoryType);
        }
        public IActionResult Delete(int? categoryTypeId)
        {
            var categoryType = _DbContext.CategoryTypes.Find(categoryTypeId);

            if (categoryType == null)
            {
                return NotFound();
            }
            return View(categoryType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryType(int? categoryTypeId)
        {
            var categoryType = _DbContext.CategoryTypes.Find(categoryTypeId);
            if (categoryType == null)
            {
                return NotFound();
            }
            _DbContext.Remove(categoryType);
            _DbContext.SaveChanges();
            TempData["SuccessMsg"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
